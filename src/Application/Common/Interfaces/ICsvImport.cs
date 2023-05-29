using Microsoft.AspNetCore.Http;

namespace Backend.Application.Common.Interfaces;

public interface ICsvImport<T, TClass>
{
    IEnumerable<T> ReadInCSV(IFormFile file);
}
