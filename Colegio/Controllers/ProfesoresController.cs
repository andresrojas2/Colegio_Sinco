using AutoMapper;
using Colegio.Dtos;
using Colegio.Logica.Repositorios;
using Colegio.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Controllers
{
    public class ProfesoresController : Controller
    {
        private IProfesorRepositorio _profesor;
        private IMateriaRepositorio _materia;
        private IMapper _mapper;

        public ProfesoresController(IMapper mapper, IProfesorRepositorio profesor, IMateriaRepositorio materia)
        {
            _profesor = profesor;
            _materia = materia;
            _mapper = mapper;
        }

        private async Task CargarControlesAsync()
        {

            var materia = await _materia.ObtenerTodosAsync();
            var materiaDto = _mapper.Map<List<MateriaDto>>(materia);


            ViewData["MateriaId"] = new SelectList(materiaDto, "Id", "Nombre");


        }

        public async Task<IActionResult> Index()
        {
            var profesor = await _profesor.ObtenerTodosAsync();
            return View(_mapper.Map<List<ProfesorDto>>(profesor));
        }

        public async Task<IActionResult> Create()
        {
            await CargarControlesAsync();
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var profesor = await _profesor.ObtenerAsync(Id);
            return View(_mapper.Map<ProfesorDto>(profesor));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await _profesor.Eliminar(Id);

            var profesor = await _profesor.ObtenerTodosAsync();
            return View("Index", _mapper.Map<List<ProfesorDto>>(profesor));
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProfesorDto ProfesorDto)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var profesor = _mapper.Map<Profesor>(ProfesorDto);
                    await _profesor.Agregar(profesor);

                    var profesors = await _profesor.ObtenerTodosAsync();
                    return View("Index", _mapper.Map<List<ProfesorDto>>(profesors));
                }

                return View(ProfesorDto);
            }
            catch (Exception ex)
            {
                await CargarControlesAsync();
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            await CargarControlesAsync();
            var profesor = await _profesor.ObtenerAsync(id);
            return View(_mapper.Map<ProfesorDto>(profesor));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfesorDto ProfesorDto)
        {


            try
            {
                if (ModelState.IsValid)
                {

                    var profesor = _mapper.Map<Profesor>(ProfesorDto);
                    var resultado = await _profesor.Actualizar(profesor);

                    var profesors = await _profesor.ObtenerTodosAsync();
                    return View("Index", _mapper.Map<List<ProfesorDto>>(profesors));

                }
                await CargarControlesAsync();
                return View();

            }

            catch (Exception)
            {
                await CargarControlesAsync();
                return View();
            }
        }
    }
}
