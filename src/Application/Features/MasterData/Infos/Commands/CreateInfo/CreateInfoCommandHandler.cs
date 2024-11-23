using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Interfaces;
using Backend.Application.Contracts.Persistence;
using Backend.Application.Features.MasterData.Infos.Commands.CreateInfo;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Entities.Tools;
using MediatR;
using Microsoft.AspNetCore.Hosting;


public class CreateInfoCommandHandler : IRequestHandler<CreateInfoCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Info> _asyncRepository;

    private readonly IMapper _mapper;

    private readonly IHostingEnvironment _hostingEnvironment;

    public CreateInfoCommandHandler(
        IAsyncRepository<Info> asyncRepository,
        IMapper mapper,
        IHostingEnvironment hostingEnvironment)
    {

        _asyncRepository = asyncRepository;
        _mapper = mapper;

       
        _hostingEnvironment = hostingEnvironment;
    }


    public async Task<RequestResponseMessage> Handle(CreateInfoCommand request, CancellationToken cancellationToken)
    {




        var req = new RequestResponseMessage();


        var succeed = await _asyncRepository.Create(_mapper.Map<Info>(request), cancellationToken);

        if (succeed != null)
        {
            req.Message = "Info has been created successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to create Info";
        req.Succeed = false;

        return req;
    }

}
