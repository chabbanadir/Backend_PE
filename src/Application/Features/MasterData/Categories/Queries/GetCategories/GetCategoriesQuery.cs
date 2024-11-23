using MediatR;

namespace Backend.Application.Features.MasterData.Categories.Queries.GetCategories;

public class GetCategoriesQuery : IRequest<List<GetCategoriesResponse>>
{
}
