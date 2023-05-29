using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Application.Features.Drawings.Queries.GetDrawingDetail;
using Backend.Application.Features.MasterData.Cables.Queries.GetCableDetail;
using Backend.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Features.Drawings.Handlers
{
    public class GetDrawingDataDetailQueryHandler : IRequestHandler<GetDrawingDataDetailQuery, DrawingDataDetailVm>
    {
        private readonly IAsyncRepository<Backend.Domain.Entities.DrawingData> _repository;
        private readonly IMapper _mapper;

        public GetDrawingDataDetailQueryHandler(IAsyncRepository<Backend.Domain.Entities.DrawingData> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DrawingDataDetailVm> Handle(GetDrawingDataDetailQuery request, CancellationToken cancellationToken)
        {
          var drawing = await _repository.GetByIdAsync(new Guid(request.Id.ToString()), null, cancellationToken);

            
            return _mapper.Map<DrawingDataDetailVm>(drawing);
        }
    }
}
