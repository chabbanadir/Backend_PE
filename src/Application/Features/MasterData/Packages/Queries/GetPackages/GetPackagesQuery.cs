using MediatR;

namespace Backend.Application.Features.MasterData.Packages.Queries.GetPackages;


public class GetPackagesQuery : IRequest<List<PackagesResponse>>
{

}