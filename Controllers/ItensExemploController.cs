using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EstAPI.Models.Enuns;

namespace EstAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class ItensExemploController : ControllerBase
    {
        private static List<Item> itens = new List<Item>()
        {
            //Modo de criação e inclusão de objetos de uma só vez na lista

            new Item() { Id = 1, Nome="Lapis", Qtd=5, Categoria=CategoriaEnum.Escolar},
            new Item() { Id = 2, Nome="Sabao", Qtd=4, Categoria=CategoriaEnum.Limpeza},
            new Item() { Id = 3, Nome="Carne", Qtd=7, Categoria=CategoriaEnum.Alimenticio},
            new Item() { Id = 4, Nome="Caneta", Qtd=15, Categoria=CategoriaEnum.Escolar},
            new Item() { Id = 5, Nome="Agua Sanitaria", Qtd=2, Categoria=CategoriaEnum.Limpeza},
            new Item() { Id = 6, Nome="Saco de Arroz", Qtd=3, Categoria=CategoriaEnum.Alimenticio}
        };

        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Item p = itens[0];
            return Ok(p);

        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(itens);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(itens.FirstOrDefault(pe => pe.Id == id));
        }

        [HttpPost]

        public IActionResult AddItem(Item novoItem)
        {
            itens.Add(novoItem);
            return Ok(itens);
        }
    }
}