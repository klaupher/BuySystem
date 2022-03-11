using MediatR;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SolicitaAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly SolicitaAgg.ISolicitacaoCompraRepository compraRepository;
        public RegistrarCompraCommandHandler(SolicitaAgg.ISolicitacaoCompraRepository compraRepository,IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.compraRepository = compraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var compra = new SolicitaAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);
            this.compraRepository.RegistrarCompra(compra);

            Commit();
            PublishEvents(compra.Events);

            return Task.FromResult(true);
        }
    }
}
