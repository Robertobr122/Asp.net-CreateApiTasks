using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDeTabelaTarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Tarefas",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Tarefas",
                newName: "Descricao");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Tarefas",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Tarefas",
                newName: "Nome");
        }
    }
}
