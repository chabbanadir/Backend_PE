using Backend.Application.Common.Exceptions;
using MediatR;

namespace Backend.Application.Features.MasterData.Oems.Commands.DeleteOem;

public class DeleteOemCommand : IRequest<RequestResponseMessage>
{
    public string? Id { get; set; }
}
