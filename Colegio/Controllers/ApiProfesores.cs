using AutoMapper;
using Colegio.Dtos;
using Colegio.Logica.Contratos;
using Colegio.Logica.Repositorios;
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
    public class ApiProfesores : ControllerBase
    {
        private IProfesorRepositorio _profesor;
        private readonly IMapper _mapper;

        public ApiProfesores(IProfesorRepositorio usuariosRepositorio, IMapper mapper)
        {
            _profesor = usuariosRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfesorDto>>> Get()
        {
            try
            {
                var clientes = await _profesor.ObtenerTodosAsync();
                return _mapper.Map<List<ProfesorDto>>(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Profesor>> Post(ProfesorDto ProfesorDto)
        {
            try
            {
                var profesor = _mapper.Map<Profesor>(ProfesorDto);

                var nuevaCliente = await _profesor.Agregar(profesor);
                if (nuevaCliente == null)
                {
                    return BadRequest();
                }

                var nuevaOrdenDto = _mapper.Map<ProfesorDto>(nuevaCliente);
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
                var resultado = await _profesor.Eliminar(id);
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
        public async Task<ActionResult<ProfesorDto>> Put(int id, [FromBody] ProfesorDto ProfesorDto)
        {

            if (ProfesorDto == null)
                return NotFound();

            var profesor = _mapper.Map<Profesor>(ProfesorDto);
            profesor.Id = id;
            var resultado = await _profesor.Actualizar(profesor);

            if (!resultado)
                return BadRequest();


            return ProfesorDto;

        }
    }
}
