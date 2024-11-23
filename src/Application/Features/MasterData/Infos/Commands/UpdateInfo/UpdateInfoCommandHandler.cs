using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Infos.Commands.UpdateInfo;

public class UpdateInfoCommandHandler : IRequestHandler<UpdateInfoCommand, RequestResponseMessage>
{

    private readonly IAsyncRepository<Info> _asyncRepository;
    private readonly IMapper _mapper;


    public UpdateInfoCommandHandler(
    IAsyncRepository<Info> asyncRepository,
    IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }


    public async Task<RequestResponseMessage> Handle(UpdateInfoCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        var req = new RequestResponseMessage();

        if (entity == null)
        {
            throw new NotFoundException(nameof(Info), request.Id);
        }

        _mapper.Map(request, entity, typeof(UpdateInfoCommand), typeof(Info));

        var succeed = await _asyncRepository.Update(entity, cancellationToken);

        if (succeed)
        {
            req.Message = "Info has been updated successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to update Info";
        req.Succeed = false;

        return req;
    }
}
