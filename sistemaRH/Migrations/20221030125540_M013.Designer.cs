﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sistemaRH.Models;

#nullable disable

namespace sistemaRH.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221030125540_M013")]
    partial class M013
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("sistemaRH.Models.Atividade", b =>
                {
                    b.Property<int>("IdAtividade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAtividade"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.HasKey("IdAtividade");

                    b.ToTable("Atividades");
                });

            modelBuilder.Entity("sistemaRH.Models.Trabalho", b =>
                {
                    b.Property<int>("IdTrabalho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTrabalho"), 1L, 1);

                    b.Property<int>("AtividadeId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("ValorHoraId")
                        .HasColumnType("int");

                    b.HasKey("IdTrabalho");

                    b.HasIndex("AtividadeId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("ValorHoraId");

                    b.ToTable("Trabalhos");
                });

            modelBuilder.Entity("sistemaRH.Models.Usuario", b =>
                {
                    b.Property<int>("IdCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCadastro"), 1L, 1);

                    b.Property<string>("ConfirmaSenha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCadastro");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("sistemaRH.Models.ValorHora", b =>
                {
                    b.Property<int>("IdValorHora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdValorHora"), 1L, 1);

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdValorHora");

                    b.ToTable("ValorHoras");
                });

            modelBuilder.Entity("sistemaRH.Models.Trabalho", b =>
                {
                    b.HasOne("sistemaRH.Models.Atividade", "Atividades")
                        .WithMany()
                        .HasForeignKey("AtividadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaRH.Models.Usuario", "Usuario")
                        .WithMany("Trabalhos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaRH.Models.ValorHora", "ValorHoras")
                        .WithMany("Trabalhos")
                        .HasForeignKey("ValorHoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atividades");

                    b.Navigation("Usuario");

                    b.Navigation("ValorHoras");
                });

            modelBuilder.Entity("sistemaRH.Models.Usuario", b =>
                {
                    b.Navigation("Trabalhos");
                });

            modelBuilder.Entity("sistemaRH.Models.ValorHora", b =>
                {
                    b.Navigation("Trabalhos");
                });
#pragma warning restore 612, 618
        }
    }
}
