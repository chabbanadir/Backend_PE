using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Oems.Commands.UpdateOem;

public class UpdateOemCommandHandler : IRequestHandler<UpdateOemCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Oem> _asyncRepository;
    private readonly IMapper _mapper;

    public UpdateOemCommandHandler(IAsyncRepository<Oem> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<RequestResponseMessage> Handle(UpdateOemCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.GetByIdAsync(request.Id, null, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Oem), request.Id);
        }

        var req = new RequestResponseMessage();


        var succeed = await _asyncRepository.Update(_mapper.Map<Oem>(request), cancellationToken);

        if (succeed)
        {
            req.Message = "Oem has been updated successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to update Oem";
        req.Succeed = false;

        return req;
    }
}
