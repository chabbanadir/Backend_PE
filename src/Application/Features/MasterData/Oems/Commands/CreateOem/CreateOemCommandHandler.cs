using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;
namespace Backend.Application.Features.MasterData.Oems.Commands.CreateOem;


public class CreateOemCommandHandler : IRequestHandler<CreateOemCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Oem> _asyncRepository;
    private readonly IMapper _mapper;

    public CreateOemCommandHandler(IAsyncRepository<Oem> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<RequestResponseMessage> Handle(CreateOemCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.Create(_mapper.Map<Oem>(request), cancellationToken);
        var req = new RequestResponseMessage();


        if (entity != null)
        {
            req.Message = "Oem has been created successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to create Oem";
        req.Succeed = false;

        return req;
    }

}