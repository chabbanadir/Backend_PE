using MediatR;


namespace Backend.Application.Features.MasterData.Oems.Queries.GetComponents;

public class GetComponentsQuery: IRequest<ComponentsResponse>
{
    public string? oemId { get; set; }
}
