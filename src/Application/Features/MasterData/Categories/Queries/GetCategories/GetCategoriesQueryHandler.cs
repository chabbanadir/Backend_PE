using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<GetCategoriesResponse>>
{
    private readonly IAsyncRepository<Category> asyncRepository;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(IAsyncRepository<Category> asyncRepository, IMapper mapper)
    {
        this.asyncRepository = asyncRepository;
        _mapper = mapper;
    }


    public async Task<List<GetCategoriesResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {

        var query = await asyncRepository.GetAllAsync(new[] { "Picture" }, cancellationToken);


        return _mapper.Map<List<GetCategoriesResponse>>(query);

    }

}