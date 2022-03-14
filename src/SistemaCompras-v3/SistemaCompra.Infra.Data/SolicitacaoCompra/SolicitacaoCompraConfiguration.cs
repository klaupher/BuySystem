using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SolicitaAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitaAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitaAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("Compra");
            builder.OwnsOne(c => c.TotalGeral, 
                            b => b.Property("Value")
                                    .HasColumnName("TotalGeral")
                                    .HasColumnType("decimal(5, 2)")
                           );
            builder.OwnsOne(c => c.CondicaoPagamento,
                            b => b.Property("Valor")
                                    .HasColumnName("CondicaoPagamento")
                           );
            builder.OwnsOne(c => c.NomeFornecedor,
                            b => b.Property("Nome")
                                    .HasColumnName("NomeFornecedor")
                           );
            builder.OwnsOne(c => c.UsuarioSolicitante,
                            b => b.Property("Nome")
                                    .HasColumnName("UsuarioSolicitante")
                           );
        }
    }
}
