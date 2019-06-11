using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.Perfil.Handlers
{
    public class CriarPerfilCommandHandler : CommandHandler ,IRequestHandler<CriarPerfilCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CriarPerfilCommandHandler(IMediator mediator, 
            IPerfilRepository perfilRepository, 
            IUnitOfWork unitOfWork) : base(mediator, unitOfWork)
        {
            _mediator = mediator;
            _perfilRepository = perfilRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CriarPerfilCommand request, CancellationToken cancellationToken)
        {
            if (!request.isValid())
            {
                //TODO: Implementar domain notification
                NotificarErros(request);
                return await Task.FromResult(false);
            };
            
            return await Task.FromResult(false);
        }
    }
}
