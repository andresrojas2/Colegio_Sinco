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

        public ProfesoresController(IMapper mapper, IProfesorRepositorio empleado, IMateriaRepositorio materia)
        {
            _profesor = empleado;
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
            var empleado = await _profesor.ObtenerTodosAsync();
            return View(_mapper.Map<List<ProfesorDto>>(empleado));
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

            var empleado = await _profesor.ObtenerTodosAsync();
            return View("Index", _mapper.Map<List<ProfesorDto>>(empleado));
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProfesorDto ProfesorDto)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var empleado = _mapper.Map<Profesor>(ProfesorDto);
                    await _profesor.Agregar(empleado);

                    var empleados = await _profesor.ObtenerTodosAsync();
                    return View("Index", _mapper.Map<List<ProfesorDto>>(empleados));
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
            var empleado = await _profesor.ObtenerAsync(id);
            return View(_mapper.Map<ProfesorDto>(empleado));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfesorDto ProfesorDto)
        {


            try
            {
                if (ModelState.IsValid)
                {

                    var empleado = _mapper.Map<Profesor>(ProfesorDto);
                    var resultado = await _profesor.Actualizar(empleado);

                    var empleados = await _profesor.ObtenerTodosAsync();
                    return View("Index", _mapper.Map<List<ProfesorDto>>(empleados));

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
