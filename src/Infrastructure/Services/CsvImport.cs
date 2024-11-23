using System.Globalization;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services;

public class CsvImport<T, TClass> : ICsvImport<T, TClass> where TClass : ClassMap
{
    public IEnumerable<T> ReadInCSV(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName);
        IEnumerable<T> res = null;

        if (file.Length == 0 || file == null)
        {
            throw new BussinessException("No file has been selected", 400);
        }
        if (extension.Equals(".csv"))
        {
            using var streamReader = new StreamReader(file.OpenReadStream());
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            csvReader.Context.RegisterClassMap<TClass>();
            res = csvReader.GetRecords<T>().ToList();
        }
        else
        {
            throw new BussinessException("The csv file does not have a valid format", 400);
        }
        return res;
    }
}
