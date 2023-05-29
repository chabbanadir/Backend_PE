using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Backend.Application.Features.DrawingGenerator.step4.GetCablesByOem;

public class GetCablesByOemQuery : IRequest<List<CablesByOemVm>>
{
    public string? oemId { get; set; }

}
