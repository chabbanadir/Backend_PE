using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;


namespace Backend.Application.Features.DrawingGenerator.step5.GetComponentDetails;

public class GetComponentDetailsQueryHandler : IRequestHandler<GetComponentDetailsQuery, ComponentDetailsVm>
{
    private readonly IAsyncRepository<Component> _asyncRepository;
    private readonly IMapper _mapper;

    public GetComponentDetailsQueryHandler(IAsyncRepository<Component> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<ComponentDetailsVm> Handle(GetComponentDetailsQuery request, CancellationToken cancellationToken)
    {

        var component = await _asyncRepository.GetByIdAsync(new Guid(request.Id), new[] { "Picture", "Category", "Config","Config.Note", "Config.Picture", "Cables","Parts" }, cancellationToken);
        component.Parts = component.Parts.Where(x => !x.IsDeleted).ToList();

        if (component == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        return _mapper.Map<ComponentDetailsVm>(component);

    }
}
