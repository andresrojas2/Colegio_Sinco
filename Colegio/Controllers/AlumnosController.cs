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
    public class AlumnosController : Controller
    {
        private IAlumnoRepositorio _alumno;
        private IMapper _mapper;

        public AlumnosController(IMapper mapper, IAlumnoRepositorio empleado)
        {
            _alumno = empleado;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var empleado = await _alumno.ObtenerTodosAsync();
            return View(_mapper.Map<List<AlumnoDto>>(empleado));
        }

        public IActionResult Create()
        {

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var alumno = await _alumno.ObtenerAsync(Id);
            return View(_mapper.Map<AlumnoDto>(alumno));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await _alumno.Eliminar(Id);

            var empleado = await _alumno.ObtenerTodosAsync();
            return View("Index", _mapper.Map<List<AlumnoDto>>(empleado));
        }


        [HttpPost]
        public async Task<IActionResult> Create(AlumnoDto AlumnoDto)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var empleado = _mapper.Map<Alumno>(AlumnoDto);
                    await _alumno.Agregar(empleado);

                    var empleados = await _alumno.ObtenerTodosAsync();
                    return View("Index", _mapper.Map<List<AlumnoDto>>(empleados));
                }

                return View(AlumnoDto);
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {

            var empleado = await _alumno.ObtenerAsync(id);
            return View(_mapper.Map<AlumnoDto>(empleado));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AlumnoDto AlumnoDto)
        {


            try
            {
                if (ModelState.IsValid)
                {

                    var empleado = _mapper.Map<Alumno>(AlumnoDto);
                    var resultado = await _alumno.Actualizar(empleado);

                    var empleados = await _alumno.ObtenerTodosAsync();
                    return View("Index", _mapper.Map<List<AlumnoDto>>(empleados));

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
