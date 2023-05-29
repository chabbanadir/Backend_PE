using Backend.Application.Common.Exceptions;
using MediatR;

namespace Backend.Application.Features.MasterData.Packages.Commands.DeletePackage;

public class DeletePackageCommand : IRequest<RequestResponseMessage>
{
    public string? Id { get; set; }

}
