using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.UpdateComponent;

public class UpdateComponentCommandHandler : IRequestHandler<UpdateComponentCommand, RequestResponseMessage>
{

    private readonly IAsyncRepository<Component> _asyncRepository;
    private readonly IMapper _mapper;


    public UpdateComponentCommandHandler(
    IAsyncRepository<Component> asyncRepository,
    IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }


    public async Task<RequestResponseMessage> Handle(UpdateComponentCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        var req = new RequestResponseMessage();

        if (entity == null)
        {
            throw new NotFoundException(nameof(Component), request.Id);
        }

        _mapper.Map(request, entity, typeof(UpdateComponentCommand), typeof(Component));

        var succeed = await _asyncRepository.Update(entity, cancellationToken);

        if (succeed)
        {
            req.Message = "Component has been updated successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to update component";
        req.Succeed = false;

        return req;
    }
}
