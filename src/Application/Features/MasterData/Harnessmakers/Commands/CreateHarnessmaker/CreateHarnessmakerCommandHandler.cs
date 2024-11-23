using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Harnessmakers.Commands.CreateHarnessmaker;

public class CreateHarnessmakerCommandHandler : IRequestHandler<CreateHarnessmakerCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Harnessmaker> _asyncRepository;
    private readonly IMapper _mapper;
    public CreateHarnessmakerCommandHandler(IAsyncRepository<Harnessmaker> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }


    public async Task<RequestResponseMessage> Handle(CreateHarnessmakerCommand request, CancellationToken cancellationToken)
    {
        var Object = _mapper.Map<Harnessmaker>(request);
        var entity = await _asyncRepository.Create(Object, cancellationToken);
        var req = new RequestResponseMessage();


        if (entity != null)
        {
            req.Message = "HarnessMaker has been created successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to create HarnessMaker";
        req.Succeed = false;

        return req;
    }
}
