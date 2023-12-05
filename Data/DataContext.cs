using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EstAPI.Models;
using EstAPI.Models.Enuns;


namespace EstAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Item> TB_ITENS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData
            (
                new Item() { Id = 1, Nome="Lapis", Qtd=5, Categoria=CategoriaEnum.Escolar},
                new Item() { Id = 2, Nome="Sabao", Qtd=4, Categoria=CategoriaEnum.Limpeza},
                new Item() { Id = 3, Nome="Carne", Qtd=7, Categoria=CategoriaEnum.Alimenticio},
                new Item() { Id = 4, Nome="Caneta", Qtd=15, Categoria=CategoriaEnum.Escolar},
                new Item() { Id = 5, Nome="Agua Sanitaria", Qtd=2, Categoria=CategoriaEnum.Limpeza},
                new Item() { Id = 6, Nome="Saco de Arroz", Qtd=3, Categoria=CategoriaEnum.Alimenticio}
            );

            //Área para futuros inserts no banco
        }










    }
}