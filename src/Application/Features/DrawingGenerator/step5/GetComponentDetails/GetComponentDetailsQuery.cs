using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Backend.Application.Features.DrawingGenerator.step5.GetComponentDetails;

public class GetComponentDetailsQuery : IRequest<ComponentDetailsVm>
{
    public string? Id { get; set; }
}
