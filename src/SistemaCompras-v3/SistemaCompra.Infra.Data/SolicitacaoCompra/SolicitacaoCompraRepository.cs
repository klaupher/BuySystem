using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository: SolicitacaoAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this.context = context;
        }

        public SolicitacaoAgg.SolicitacaoCompra ObtemCompra(Guid id)
        {
            return context.Set<SolicitacaoAgg.SolicitacaoCompra>().Where(c => c.Id == id).Single();
        }

        public void AtualizaCompra(SolicitacaoAgg.SolicitacaoCompra solicitacaoCompra)
        {
            context.Set<SolicitacaoAgg.SolicitacaoCompra>().Update(solicitacaoCompra);
        }

        public void ExcluirCompra(SolicitacaoAgg.SolicitacaoCompra solicitacaoCompra)
        {
            context.Set<SolicitacaoAgg.SolicitacaoCompra>().Remove(solicitacaoCompra); ;
        }

        public void RegistrarCompra(SolicitacaoAgg.SolicitacaoCompra solicitacaoCompra)
        {
            context.Set<SolicitacaoAgg.SolicitacaoCompra>().Add(solicitacaoCompra);
        }
    }
}
