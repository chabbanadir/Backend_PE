using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Common.Security;

public class FileValidator : AbstractValidator<IFormFile>
{
    public FileValidator()
    {

        RuleFor(x => x.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
            .WithMessage("File type is not allowed");
    }
}
