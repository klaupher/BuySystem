using System;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        SolicitacaoCompra ObtemCompra(Guid id);
        void RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
        void AtualizaCompra(SolicitacaoCompra solicitacaoCompra);
        void ExcluirCompra(SolicitacaoCompra solicitacaoCompra);
    }
}
