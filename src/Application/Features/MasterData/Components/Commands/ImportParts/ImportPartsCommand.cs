using Backend.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Features.MasterData.Components.Commands.ImportParts;

public class ImportPartsCommand : IRequest<ImportMessage>
{
    public IFormFile file { get; set; }
}