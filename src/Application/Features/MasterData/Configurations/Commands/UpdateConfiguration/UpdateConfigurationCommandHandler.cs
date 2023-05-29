using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Interfaces;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Entities.Tools;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Backend.Application.Features.MasterData.Configurations.Commands.UpdateConfiguration;

public class UpdateConfigurationCommandHandler : IRequestHandler<UpdateConfigurationCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Config> _asyncRepository;
    private readonly IAsyncRepository<Picture> _asyncPicRepository;

    private readonly IMapper _mapper;

    private readonly IHelperImage _helperImage;
    private readonly IHostingEnvironment _hostingEnvironment;


    public UpdateConfigurationCommandHandler(
        IAsyncRepository<Config> asyncRepository,
        IAsyncRepository<Picture> asyncPictureRepository,
        IMapper mapper,
        IHelperImage helperImage,
        IHostingEnvironment hostingEnvironment)
    {
        _asyncRepository = asyncRepository;
        _asyncPicRepository = asyncPictureRepository;
        _mapper = mapper;
        _helperImage = helperImage;
        _hostingEnvironment = hostingEnvironment;
    }

    public async Task<RequestResponseMessage> Handle(UpdateConfigurationCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.GetByIdAsync(request.Id, null, cancellationToken);

        var req = new RequestResponseMessage();

        if (entity == null)
        {
            throw new NotFoundException(nameof(Config), request.Id);
        }






        if (request.File != null)
        {
            string ImageUrl;
            Picture image;

            ImageUrl = await _helperImage.Upload(request.File, _hostingEnvironment.ContentRootPath, "configurations");
            image = new Picture { PicPath = ImageUrl, Name = request.File.FileName };
            var pic = await _asyncPicRepository.Create(image, cancellationToken);

            request.FK_PictureId = pic.Id;
        }
        else
        {
            request.FK_PictureId = entity.FK_PictureId ?? null;
        }








        var succeed = await _asyncRepository.Update(_mapper.Map<Config>(request), cancellationToken);

        if (succeed)
        {
            req.Message = "Configuration has been updated successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to update configuration";
        req.Succeed = false;

        return req;
    }
}