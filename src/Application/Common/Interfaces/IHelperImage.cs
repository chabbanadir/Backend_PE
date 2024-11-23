using Microsoft.AspNetCore.Http;

namespace Backend.Application.Common.Interfaces;

public interface IHelperImage
{
    Task<string> Upload(IFormFile file, string directory, string folder);
}
