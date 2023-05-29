using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Interfaces;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Entities.Tools;
using Backend.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Backend.Application.Features.MasterData.Harnessmakers.Commands.UpdateHarnessmaker;

public class UpdateHarnessmakerCommandHandler : IRequestHandler<UpdateHarnessmakerCommand, RequestResponseMessage>
{

    private readonly IAsyncRepository<Harnessmaker> _asyncRepository;
    private readonly IMapper _mapper;


    public UpdateHarnessmakerCommandHandler(IAsyncRepository<Harnessmaker> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<RequestResponseMessage> Handle(UpdateHarnessmakerCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.GetByIdAsync(request.Id, null, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Oem), request.Id);
        }

        var req = new RequestResponseMessage();


        var succeed = await _asyncRepository.Update(_mapper.Map<Harnessmaker>(request), cancellationToken);

        if (succeed)
        {
            req.Message = "HarnessMaker has been updated successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to update HarnessMaker";
        req.Succeed = false;

        return req;
    }
}
