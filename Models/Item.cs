using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstAPI.Models.Enuns;

namespace EstAPI.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public int Qtd { get; set; }

        public CategoriaEnum Categoria{ get; set; }
    }
}