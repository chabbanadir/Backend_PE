using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Oems.Queries.GetOemDetail;

// vm / dto
// view model (result) 
public class GetOemDetailQueryHandler : IRequestHandler<GetOemDetailQuery, OemDetailVm>
{
    private readonly IAsyncRepository<Oem> _asyncRepository;
    private readonly IMapper _mapper;

    public GetOemDetailQueryHandler(IAsyncRepository<Oem> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<OemDetailVm> Handle(GetOemDetailQuery request, CancellationToken cancellationToken)
    {

        var item = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null , cancellationToken);

        item.Components = item.Components.Where(x => !x.IsDeleted).ToList();

        if (item == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }


        return _mapper.Map<OemDetailVm>(item);

    }

}