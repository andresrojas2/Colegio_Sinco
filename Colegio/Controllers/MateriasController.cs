using AutoMapper;
using Colegio.Dtos;
using Colegio.Logica.Repositorios;
using Colegio.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Controllers
{
    public class MateriasController : Controller
    {
        private IMateriaRepositorio _materia;
        private IMapper _mapper;

        public MateriasController(IMapper mapper, IMateriaRepositorio empleado)
        {
            _materia = empleado;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var empleado = await _materia.ObtenerTodosAsync();
            return View(_mapper.Map<List<MateriaDto>>(empleado));
        }

        public IActionResult Create()
        {

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var materia = await _materia.ObtenerAsync(Id);
            return View(_mapper.Map<MateriaDto>(materia));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await _materia.Eliminar(Id);

            var empleado = await _materia.ObtenerTodosAsync();
            return View("Index", _mapper.Map<List<MateriaDto>>(empleado));
        }


        [HttpPost]
        public async Task<IActionResult> Create(MateriaDto MateriaDto)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var empleado = _mapper.Map<Materium>(MateriaDto);
                    await _materia.Agregar(empleado);

                    var empleados = await _materia.ObtenerTodosAsync();
                    return View("Index", _mapper.Map<List<MateriaDto>>(empleados));
                }

                return View(MateriaDto);
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {

            var empleado = await _materia.ObtenerAsync(id);
            return View(_mapper.Map<MateriaDto>(empleado));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MateriaDto MateriaDto)
        {


            try
            {
                if (ModelState.IsValid)
                {

                    var empleado = _mapper.Map<Materium>(MateriaDto);
                    var resultado = await _materia.Actualizar(empleado);

                    var empleados = await _materia.ObtenerTodosAsync();
                    return View("Index", _mapper.Map<List<MateriaDto>>(empleados));

                }

                return View();

            }

            catch (Exception)
            {
                return View();
            }

        }
    }
}
