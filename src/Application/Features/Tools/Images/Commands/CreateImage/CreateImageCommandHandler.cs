using AutoMapper;
using Backend.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;


namespace Backend.Application.Features.Tools.Images.Commands.CreateImage;

public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IHelperImage _helperImage;
    private readonly IHostingEnvironment _hostingEnvironment;

    public CreateImageCommandHandler(IApplicationDbContext context, IMapper mapper, IHelperImage helperImage, IHostingEnvironment hostingEnvironment)
    {
        _context = context;
        _mapper = mapper;
        _helperImage = helperImage;
        _hostingEnvironment = hostingEnvironment;

    }

    public async Task<string> Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {

        string ImageUrl = await _helperImage.Upload(request.Image, _hostingEnvironment.ContentRootPath, "");


        return ImageUrl;

        /*     
         *     var cable = new Cable
               {
                   OemId = new Guid(request.OemId),
                   Name = request.Name,
                   TE_PN = request.TE_PN,
                   Customer_PN = request.Customer_PN,
                   Description = request.Description,
                   Status = (Status) request.Status,
               };

               _context.Cables.Add(cable);

               await _context.SaveChangesAsync(cancellationToken);
        */

    }

}