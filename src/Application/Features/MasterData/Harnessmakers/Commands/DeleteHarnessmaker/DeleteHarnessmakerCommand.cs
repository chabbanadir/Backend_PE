using Backend.Application.Common.Exceptions;
using MediatR;

namespace Backend.Application.Features.MasterData.Harnessmakers.Commands.DeleteHarnessmaker;

public class DeleteHarnessmakerCommand : IRequest<RequestResponseMessage>
{
    public string? Id { get; set; }
}
