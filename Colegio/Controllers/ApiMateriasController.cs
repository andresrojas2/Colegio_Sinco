using AutoMapper;
using Colegio.Dtos;
using Colegio.Logica.Contratos;
using Colegio.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiMateriasController : ControllerBase
    {
        private IMateriaRepositorio _materiaRepositorio;
        private readonly IMapper _mapper;

        public ApiMateriasController(IMateriaRepositorio usuariosRepositorio, IMapper mapper)
        {
            _materiaRepositorio = usuariosRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MateriaDto>>> Get()
        {
            try
            {
                var clientes = await _materiaRepositorio.ObtenerTodosAsync();
                return _mapper.Map<List<MateriaDto>>(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Materium>> Post(MateriaDto MateriaDto)
        {
            try
            {
                var materia = _mapper.Map<Materium>(MateriaDto);

                var nuevaCliente = await _materiaRepositorio.Agregar(materia);
                if (nuevaCliente == null)
                {
                    return BadRequest();
                }

                var nuevaOrdenDto = _mapper.Map<MateriaDto>(nuevaCliente);
                return CreatedAtAction(nameof(Post), new { id = nuevaOrdenDto.Id }, nuevaOrdenDto);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _materiaRepositorio.Eliminar(id);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception excepcion)
            {
                return BadRequest();
            }
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MateriaDto>> Put(int id, [FromBody] MateriaDto MateriaDto)
        {

            if (MateriaDto == null)
                return NotFound();

            var materia = _mapper.Map<Materium>(MateriaDto);
            materia.Id = id;
            var resultado = await _materiaRepositorio.Actualizar(materia);

            if (!resultado)
                return BadRequest();


            return MateriaDto;

        }
    }
}
