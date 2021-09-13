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

        public MateriasController(IMapper mapper, IMateriaRepositorio materia)
        {
            _materia = materia;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var materia = await _materia.ObtenerTodosAsync();
            return View(_mapper.Map<List<MateriaDto>>(materia));
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

            var materia = await _materia.ObtenerTodosAsync();
            return View("Index", _mapper.Map<List<MateriaDto>>(materia));
        }


        [HttpPost]
        public async Task<IActionResult> Create(MateriaDto MateriaDto)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var materia = _mapper.Map<Materium>(MateriaDto);
                    await _materia.Agregar(materia);

                    var materias = await _materia.ObtenerTodosAsync();
                    return View("Index", _mapper.Map<List<MateriaDto>>(materias));
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

            var materia = await _materia.ObtenerAsync(id);
            return View(_mapper.Map<MateriaDto>(materia));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MateriaDto MateriaDto)
        {


            try
            {
                if (ModelState.IsValid)
                {

                    var materia = _mapper.Map<Materium>(MateriaDto);
                    var resultado = await _materia.Actualizar(materia);

                    var materias = await _materia.ObtenerTodosAsync();
                    return View("Index", _mapper.Map<List<MateriaDto>>(materias));

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
