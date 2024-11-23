using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Interfaces;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Entities.Tools;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Backend.Application.Features.MasterData.Components.Commands.CreateComponent;

public class CreateComponentCommandHandler : IRequestHandler<CreateComponentCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Oem> _asyncOemRepository;
    private readonly IAsyncRepository<Component> _asyncRepository;
    private readonly IAsyncRepository<Picture> _asyncPicRepository;

    private readonly IMapper _mapper;

    private readonly IHelperImage _helperImage;
    private readonly IHostingEnvironment _hostingEnvironment;

    public CreateComponentCommandHandler(
        IAsyncRepository<Oem> asyncOemRepository,
        IAsyncRepository<Component> asyncRepository,
        IAsyncRepository<Picture> asyncPictureRepository,
        IMapper mapper,
        IHelperImage helperImage,
        IHostingEnvironment hostingEnvironment)
    {
        _asyncRepository = asyncRepository;
        _asyncPicRepository = asyncPictureRepository;
        _asyncOemRepository = asyncOemRepository;
        _mapper = mapper;
        _helperImage = helperImage;
        _hostingEnvironment = hostingEnvironment;
    }

    public async Task<RequestResponseMessage> Handle(CreateComponentCommand request, CancellationToken cancellationToken)
    {
        var oemEntity = await _asyncOemRepository.GetByIdAsync(new Guid(request.FK_OemId), null, cancellationToken);

        var req = new RequestResponseMessage();

        if (oemEntity == null)
        {
            throw new NotFoundException("The specified OemId is not exists.");
        }

        if (request.File != null)
        {
            string ImageUrl;
            Picture image;

            ImageUrl = await _helperImage.Upload(request.File, _hostingEnvironment.ContentRootPath, "components");
            image = new Picture { PicPath = ImageUrl, Name = request.File.FileName };
            var pic = await _asyncPicRepository.Create(image, cancellationToken);

            request.FK_PictureId = pic.Id;
        }

        var succeed = await _asyncRepository.Create(_mapper.Map<Component>(request), cancellationToken);

        if (succeed != null)
        {
            req.Message = "Component has been created successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to create component";
        req.Succeed = false;

        return req;
    }
}
