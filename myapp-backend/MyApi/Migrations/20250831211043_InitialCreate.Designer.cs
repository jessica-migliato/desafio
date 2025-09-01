using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApi.Domain;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250831211043_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyApi.Domain.Entities.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NumeroParcela")
                        .HasColumnType("integer");

                    b.Property<int>("TituloId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("TituloId");

                    b.ToTable("Parcelas");
                });

            modelBuilder.Entity("MyApi.Domain.Entities.Titulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CpfDevedor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeDevedor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumeroTitulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PercentualJuros")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PercentualMulta")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Titulos");
                });

            modelBuilder.Entity("MyApi.Domain.Entities.Parcela", b =>
                {
                    b.HasOne("MyApi.Domain.Entities.Titulo", null)
                        .WithMany("Parcelas")
                        .HasForeignKey("TituloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyApi.Domain.Entities.Titulo", b =>
                {
                    b.Navigation("Parcelas");
                });
#pragma warning restore 612, 618
        }
    }
}
