using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public IList<string> Itens { get; set; }
        public string Data { get; set; }
        public decimal TotalGeral { get; set; }
        public string Situacao { get; set; }
    }
}
