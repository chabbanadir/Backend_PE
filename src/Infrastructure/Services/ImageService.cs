using Backend.Application.Common.Interfaces;
using Backend.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services;

public class ImageService : IHelperImage
{

    public async Task<string> Upload(IFormFile file, string directory, string folder)
    {

            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            var fileName = Guid.NewGuid().ToString() + extension;

            var path = Path.Combine(directory, $"wwwroot/images/{folder}/", fileName);

            var bits = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(bits);
            bits.Close();

        return $"{folder}\\{fileName}";
    }

}
