using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Categories.Queries.GetCategoryDetail;

public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDetailVm>
{
    private readonly IAsyncRepository<Category> _asyncRepository;
    private readonly IMapper _mapper;

    public GetCategoryDetailQueryHandler(IAsyncRepository<Category> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDetailVm> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
    {


        var item = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }


        return _mapper.Map<CategoryDetailVm>(item);

    }

}
