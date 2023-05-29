using MediatR;

namespace Backend.Application.Features.MasterData.Categories.Queries.GetCategoryDetail;

public class GetCategoryDetailQuery : IRequest<CategoryDetailVm>
{
    public string? Id { get; set; }

}
