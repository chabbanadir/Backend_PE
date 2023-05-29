using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Interfaces;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Entities.Tools;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Backend.Application.Features.MasterData.Configurations.Commands.CreateConfiguration;

public class CreateInfoCommandHandler : IRequestHandler<CreateInfoCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Config> _asyncRepository;
    private readonly IAsyncRepository<Picture> _asyncPicRepository;

    private readonly IMapper _mapper;

    private readonly IHelperImage _helperImage;
    private readonly IHostingEnvironment _hostingEnvironment;

    public CreateInfoCommandHandler(
        IAsyncRepository<Config> asyncRepository,
        IAsyncRepository<Picture> asyncPictureRepository,
        IHelperImage helperImage,
        IMapper mapper,
        IHostingEnvironment hostingEnvironment)
    {

        _asyncRepository = asyncRepository;
        _asyncPicRepository = asyncPictureRepository;
        _mapper = mapper;

        _helperImage = helperImage;
        _hostingEnvironment = hostingEnvironment;
    }


    public async Task<RequestResponseMessage> Handle(CreateInfoCommand request, CancellationToken cancellationToken)
    {

        if (request.File != null)
        {
            string ImageUrl;
            Picture image;


            ImageUrl = await _helperImage.Upload(request.File, _hostingEnvironment.ContentRootPath, "configurations");
            image = new Picture { PicPath = ImageUrl, Name = request.File.FileName };
            var pic = await _asyncPicRepository.Create(image, cancellationToken);

            request.FK_PictureId = pic.Id;
        }


        var req = new RequestResponseMessage();


        var succeed = await _asyncRepository.Create(_mapper.Map<Config>(request), cancellationToken);

        if (succeed != null)
        {
            req.Message = "Configuration has been created successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to create configuration";
        req.Succeed = false;

        return req;
    }

}
