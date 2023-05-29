using Backend.Application.Common.Exceptions;
using MediatR;

namespace Backend.Application.Features.MasterData.Infos.Commands.DeleteInfo;

public class DeleteInfoCommand : IRequest<RequestResponseMessage>
{
    public Guid? Id { get; set; }
}
