using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Category> _asyncRepository;

    public DeleteCategoryCommandHandler(IAsyncRepository<Category> asyncRepository)
    {
        _asyncRepository = asyncRepository;
    }


    public async Task<RequestResponseMessage> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        var req = new RequestResponseMessage();

        var res = false;


        req.Message = "Category has been deleted successfully";
        req.Succeed = true;


        if (entity != null)
        {
            res = await _asyncRepository.Delete(new Guid(request.Id), cancellationToken);
        }

        if (!res)
        {
            req.Message = "Unable to delete Category";
            req.Succeed = false;

        }

        return req;
    }
}
