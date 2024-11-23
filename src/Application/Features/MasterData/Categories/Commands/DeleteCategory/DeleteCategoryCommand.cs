using Backend.Application.Common.Exceptions;
using MediatR;

namespace Backend.Application.Features.MasterData.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<RequestResponseMessage>
{
    public string? Id { get; set; }
}
