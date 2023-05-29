using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Interfaces;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Entities.Tools;
using Backend.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Backend.Application.Features.MasterData.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, RequestResponseMessage>
{

    private readonly IAsyncRepository<Category> _asyncRepository;
    private readonly IMapper _mapper;


    public UpdateCategoryCommandHandler(IAsyncRepository<Category> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<RequestResponseMessage> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
     
        var entity = await _asyncRepository.GetByIdAsync(request.Id, null, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Oem), request.Id);
        }

        var req = new RequestResponseMessage();


        var succeed = await _asyncRepository.Update(_mapper.Map<Category>(request), cancellationToken);

        if (succeed)
        {
            req.Message = "Category has been updated successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to update Category";
        req.Succeed = false;

        return req;
    }
}
