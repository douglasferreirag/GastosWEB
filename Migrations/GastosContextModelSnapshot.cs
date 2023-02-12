﻿// <auto-generated />
using System;
using Gastos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gastos.Migrations
{
    [DbContext(typeof(GastosContext))]
    partial class GastosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gastos.Models.Catalogo", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodigoFornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    b.Property<string>("fornecedorCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("fornecedorCodigo");

                    b.ToTable("Catalogos");
                });

            modelBuilder.Entity("Gastos.Models.Despesa", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodigoPessoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<double>("Desconto")
                        .HasColumnType("float");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<string>("pessoaCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("pessoaCodigo");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("Gastos.Models.Fornecedor", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Gastos.Models.Item", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodigoCatalogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(1);

                    b.Property<string>("CodigoDespesa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(0);

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<string>("catalogoCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("despesaCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("catalogoCodigo");

                    b.HasIndex("despesaCodigo");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("Gastos.Models.Pessoa", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Gastos.Models.Catalogo", b =>
                {
                    b.HasOne("Gastos.Models.Fornecedor", "fornecedor")
                        .WithMany()
                        .HasForeignKey("fornecedorCodigo");

                    b.Navigation("fornecedor");
                });

            modelBuilder.Entity("Gastos.Models.Despesa", b =>
                {
                    b.HasOne("Gastos.Models.Pessoa", "pessoa")
                        .WithMany()
                        .HasForeignKey("pessoaCodigo");

                    b.Navigation("pessoa");
                });

            modelBuilder.Entity("Gastos.Models.Item", b =>
                {
                    b.HasOne("Gastos.Models.Catalogo", "catalogo")
                        .WithMany()
                        .HasForeignKey("catalogoCodigo");

                    b.HasOne("Gastos.Models.Despesa", "despesa")
                        .WithMany()
                        .HasForeignKey("despesaCodigo");

                    b.Navigation("catalogo");

                    b.Navigation("despesa");
                });
#pragma warning restore 612, 618
        }
    }
}
