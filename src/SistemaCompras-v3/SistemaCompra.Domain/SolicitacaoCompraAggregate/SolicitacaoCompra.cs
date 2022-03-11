using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (Itens.Count == 0) 
                throw new BusinessRuleException("Itens insuficientes nessa compra.!");

            var totalGeralCompra = ObtemTotalGeral();

            AddEvent(new CompraRegistradaEvent(Id,Itens,totalGeralCompra));
        }

        private decimal ObtemTotalGeral()
        {
            if (Itens.Count == 0)
                throw new BusinessRuleException("Itens insuficientes nessa compra.");

            decimal totalGeralTemporario = 0;
            foreach (var item in Itens)
            {
                totalGeralTemporario += item.Subtotal.Value;
            }

            return totalGeralTemporario;
        }

        public string ObtemCondicaoPagamento()
        {
            return ObtemTotalGeral() > 50000 ? "30 dias" : "A vista";
        }
    }
}
