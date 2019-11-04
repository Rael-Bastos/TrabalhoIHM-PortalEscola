using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabalhoIHM.Data.Migrations
{
    public partial class AlterAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAluno",
                table: "Aluno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAluno",
                table: "Aluno",
                nullable: false,
                defaultValue: 0);
        }
    }
}
