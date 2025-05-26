using ArticulosAPI.Dto;
using ArticulosAPI.Modelos;
using ArticulosAPI.Repositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArticulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ArticulosController(IArticuloRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloDto>>> GetArticulos()
        {
            var articulos = await _repositorio.ObtenerTodos();
            var articulosDto = _mapper.Map<IEnumerable<ArticuloDto>>(articulos);
            return Ok(articulosDto);
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloDto>> GetArticulo(int id)
        {
            var articulo = await _repositorio.ObtenerPorId(id);
            if (articulo == null)
                return NotFound();

            var dto = _mapper.Map<ArticuloDto>(articulo);
            return Ok(dto);
        }

        // POST: api/Articulos
        [HttpPost]
        public async Task<ActionResult<ArticuloDto>> PostArticulo(ArticuloDto dto)
        {
            var articulo = _mapper.Map<Articulo>(dto);
            await _repositorio.Crear(articulo);

            var creado = _mapper.Map<ArticuloDto>(articulo);
            return CreatedAtAction(nameof(GetArticulo), new { id = creado.Id }, creado);
        }

        // PUT: api/Articulos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(int id, ArticuloDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var articulo = _mapper.Map<Articulo>(dto);
            await _repositorio.Actualizar(articulo);

            return NoContent();
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var existente = await _repositorio.ObtenerPorId(id);
            if (existente == null)
                return NotFound();

            await _repositorio.Eliminar(id);
            return NoContent();
        }
    }
}
