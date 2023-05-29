using Backend.Application.Common.Exceptions;
using MediatR;

namespace Backend.Application.Features.MasterData.Configurations.Commands.DeleteConfiguration;

public class DeleteConfigurationCommand : IRequest<RequestResponseMessage>
{
    public string? Id { get; set; }
}
