using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstAPI.Data;
using Microsoft.AspNetCore.Mvc;
using EstAPI.Models;
using Microsoft.EntityFrameworkCore;
using EstAPI.Models.Enuns;



namespace EstAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ItensController : ControllerBase
    {
        private readonly DataContext _context; //Declaração do atributo

        public ItensController(DataContext context)
        {
            //Inicialização de um atributo a partir de um parâmetro
            _context = context;
        }

        [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Item p = await _context.TB_ITENS
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                if (p == null)
                {
                    return NotFound();
                }

                return Ok(p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")] //Buscar todos
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Item> lista = await _context.TB_ITENS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost] //Adicionar novo Item
        public async Task<IActionResult> Add(Item novoItem)
        {
            try
            {
                if (novoItem.Qtd < 0)
                {
                    throw new Exception("Quantidade não pode ser menor que zero");
                }
                await _context.TB_ITENS.AddAsync(novoItem);
                await _context.SaveChangesAsync();

                return Ok(novoItem.Id);
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut] //Atualizar um Item
        public async Task<IActionResult> Update(Item novoItem)
        {
            try
            {
                if (novoItem.Qtd < 0)
                {
                    throw new Exception("Quantidade não pode ser menor que zero");
                }
                _context.TB_ITENS.Update(novoItem);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")] //Deletar um item por Id
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Item pRemover = await _context.TB_ITENS.FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_ITENS.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }//Fim da classe tipo controller
}