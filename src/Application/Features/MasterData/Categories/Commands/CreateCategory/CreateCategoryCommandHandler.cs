using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Interfaces;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Entities.Tools;
using Backend.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Backend.Application.Features.MasterData.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, RequestResponseMessage>
{

    private readonly IAsyncRepository<Category> _asyncRepository;
    private readonly IMapper _mapper;

    private readonly IHelperImage _helperImage;
    private readonly IHostingEnvironment _hostingEnvironment;

    public CreateCategoryCommandHandler(
        IAsyncRepository<Category> asyncRepository,
        IMapper mapper,
        IHelperImage helperImage, 
        IHostingEnvironment hostingEnvironment)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
        _helperImage = helperImage;
        _hostingEnvironment = hostingEnvironment;
    }


    public async Task<RequestResponseMessage> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.Create(_mapper.Map<Category>(request), cancellationToken);

        var req = new RequestResponseMessage();


        if (entity != null)
        {
            req.Message = "Category has been created successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to create Category";
        req.Succeed = false;

        return req;
    }

}
