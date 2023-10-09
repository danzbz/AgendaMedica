﻿// <auto-generated />
using System;
using AgendaMedica.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace AgendaMedica.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgendaMedica.Models.AgendamentoMOD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtAgendamento")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("MedicoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("AgendaMedica.Models.MedicoMOD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("AgendaMedica.Models.PacienteMOD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DtCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP(7)")
                        .HasDefaultValue(new DateTime(2023, 10, 8, 22, 49, 30, 460, DateTimeKind.Local).AddTicks(9125));

                    b.Property<DateTime?>("DtNascimento")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.HasKey("Id");

                    b.ToTable("AGM_Paciente", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "1234567897",
                            DtCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DtNascimento = new DateTime(2001, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "DANILO DE PAULA VIEIRA"
                        });
                });

            modelBuilder.Entity("AgendaMedica.Models.AgendamentoMOD", b =>
                {
                    b.HasOne("AgendaMedica.Models.MedicoMOD", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgendaMedica.Models.PacienteMOD", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
