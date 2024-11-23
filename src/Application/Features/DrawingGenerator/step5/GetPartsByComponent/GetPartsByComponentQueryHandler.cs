using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Interfaces;
using Backend.Application.Contracts.Persistence;
using Backend.Application.Features.DrawingGenerator.step5.GetPartsByComponent.Dtos;
using Backend.Domain.Entities.MasterData;
using MediatR;


namespace Backend.Application.Features.DrawingGenerator.step5.GetPartsByComponent;

public class GetPartsByComponentQueryHandler : IRequestHandler<GetPartsByComponentQuery, PartsByComponentsVm>
{
    private readonly IAsyncRepository<Component> _asyncRepository;
    private readonly IMapper _mapper;

    public GetPartsByComponentQueryHandler(IAsyncRepository<Component> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<PartsByComponentsVm> Handle(GetPartsByComponentQuery request, CancellationToken cancellationToken)
    {

        var component = await _asyncRepository.GetByIdAsync(new Guid(request.Id), new[] { "Picture" , "Parts", "Cables"/*, "Category", "Config","Config.Note", "Config.Picture", "Cables","Parts", "Parts.Part", "Parts.Part.Cables", "Parts.Part.Config", "Parts.Part.Config.Note"*/ }, cancellationToken);
        component.Parts = component.Parts.Where(x => !x.IsDeleted).ToList();

        if (component == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        return _mapper.Map<PartsByComponentsVm>(component);

    }
}
