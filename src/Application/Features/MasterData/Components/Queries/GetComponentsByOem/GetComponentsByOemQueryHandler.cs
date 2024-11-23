using System.Linq.Expressions;
using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Application.Features.Common;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using LinqKit;
using MediatR;


namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentsByOem;

public class GetComponentsByOemQueryHandler : IRequestHandler<GetComponentsByOemQuery, List<ComponentsByOemVm>>
{
    private readonly IAsyncRepository<Component> _asyncRepository;
    private readonly IMapper _mapper;

    public GetComponentsByOemQueryHandler(IAsyncRepository<Component> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<ComponentsByOemVm>> Handle(GetComponentsByOemQuery request, CancellationToken cancellationToken)
    {

        /*        
          var component = await _asyncRepository.GetByIdAsync(new Guid(request.oemId),null, cancellationToken);
          component.Parts = component.Parts.Where(x => !x.IsDeleted).ToList();
        */
        #region Predicate 
       var predicate = PredicateBuilder.New<Component>(m => m.Oem.Id == new Guid(request.oemId) && m.Status == Status.Active);
       

        if (!string.IsNullOrEmpty(request.categoryId))
        {
            predicate.And(m => m.FK_CategoryId == new Guid(request.categoryId));
        }
        if (!string.IsNullOrEmpty(request.cableId))
        {
            predicate.And(m => m.Cables.Any(a=> a.FK_CableId == new Guid(request.cableId)));
        }
        #endregion

        var Components = await _asyncRepository.GetByAsync(predicate, null, cancellationToken);
        return _mapper.Map<List<ComponentsByOemVm>>(Components);



        /*
        if (component == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        return _mapper.Map<ComponentsByOemResponse>(component);*/

    }
}
