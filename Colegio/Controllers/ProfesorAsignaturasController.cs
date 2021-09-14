using AutoMapper;
using Colegio.Dtos;
using Colegio.Logica.Contratos;
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
    public class ProfesorAsignaturasController : Controller
    {
        private IProfesorRepositorio _profesor;
        private IMateriaRepositorio _materia;
        private IAlumnoRepositorio _alumno;
        private IMatriculaMateriaRepositorio _matriculaMateriaRepositorio;
        private IReporteCalificacionRepositorio _reporteCalificacionRepositorio;
        private IProfesorAsignaturaRepositorio  _profesorAsignaturaRepositorio;
        private IMapper _mapper;



        public ProfesorAsignaturasController(IMapper mapper, IProfesorRepositorio empleado, IMateriaRepositorio materia, IMatriculaMateriaRepositorio matriculaMateriaRepositorio, IAlumnoRepositorio alumno, IReporteCalificacionRepositorio reporteCalificacionRepositorio, IProfesorAsignaturaRepositorio profesorAsignaturaRepositorio)
        {
            _profesor = empleado;
            _materia = materia;
            _mapper = mapper;
            _alumno = alumno;
            _reporteCalificacionRepositorio = reporteCalificacionRepositorio;
            _matriculaMateriaRepositorio = matriculaMateriaRepositorio;
            _profesorAsignaturaRepositorio = profesorAsignaturaRepositorio;
        }

        public async Task cargarDatosAsync(int ProfesorId)
        {
            var profesor = await _profesor.ObtenerAsync(ProfesorId);
            ViewData["vwProfesorNombreFull"] = "Profesor: " + profesor.Identificacion.ToString() + " - " + profesor.Nombre + " " + profesor.Apellido;
        }

        private async Task CargarControlesAsync(int ProfesorId)
        {

            var materia = await _materia.ObtenerTodosAsync();
            var materiaDto = _mapper.Map<List<MateriaDto>>(materia);

            var profesor = await _profesor.ObtenerAsync(ProfesorId);
            var profesorDto = _mapper.Map<ProfesorDto>(profesor);
            List<ProfesorDto> profesorDtoList = new List<ProfesorDto>();
            profesorDtoList.Add(profesorDto);

            ViewData["MateriaId"] = new SelectList(materiaDto, "Id", "Nombre");

            ViewData["ProfesorId"] = new SelectList(profesorDtoList, "Id", "Nombre");

        }

        public async Task<IActionResult> Index(int ProfesorId)
        {
            await cargarDatosAsync(ProfesorId);
            ViewData["vwProfesorId"] = ProfesorId.ToString();
            var asignatura = await _profesorAsignaturaRepositorio.ObtenerXProfesorAsync(ProfesorId);
            return View(_mapper.Map<List<ProfesorAsignaturaDto>>(asignatura));

        }



        public async Task<IActionResult> Create(int ProfesorId)
        {
            ViewData["vwProfesorId"] = ProfesorId.ToString();
            await CargarControlesAsync(ProfesorId);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfesorAsignaturaDto AsignaturaDto)
        {
            try
            {

                ViewData["vwProfesorId"] = AsignaturaDto.ProfesorId.ToString();

                if (ModelState.IsValid)
                {

                    if (await _profesorAsignaturaRepositorio.ValidarMateria((int)AsignaturaDto.MateriaId))
                    {
                        await CargarControlesAsync((int)AsignaturaDto.ProfesorId);
                        ModelState.AddModelError("MateriaId", "La materia ya ha sido asignada");
                        return View(AsignaturaDto);
                    }

                    var asignatura = _mapper.Map<ProfesorAsignatura>(AsignaturaDto);
                    await _profesorAsignaturaRepositorio.Agregar(asignatura);

                    var matriculas = await _profesorAsignaturaRepositorio.ObtenerXProfesorAsync((int)AsignaturaDto.ProfesorId);
                    return View("Index", _mapper.Map<List<ProfesorAsignaturaDto>>(matriculas));
                }

                await CargarControlesAsync((int)AsignaturaDto.ProfesorId);

                return View(AsignaturaDto);
            }
            catch (Exception ex)
            {
                await CargarControlesAsync((int)AsignaturaDto.ProfesorId);
                return View();
            }
        }

        public async Task<IActionResult> Edit(int Id, int ProfesorId)
        {
            ViewData["vwProfesorId"] = ProfesorId.ToString();
            await CargarControlesAsync(ProfesorId);
            var asignatura = await _profesorAsignaturaRepositorio.ObtenerAsync(Id);
            return View(_mapper.Map<ProfesorAsignaturaDto>(asignatura));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfesorAsignaturaDto AsignaturaDto)
        {
            ViewData["vwProfesorId"] = AsignaturaDto.ProfesorId.ToString();

            try
            {
                if (ModelState.IsValid)
                {

                    if (await _profesorAsignaturaRepositorio.ValidarMateria((int)AsignaturaDto.MateriaId))
                    {
                        await CargarControlesAsync((int)AsignaturaDto.ProfesorId);
                        ModelState.AddModelError("MateriaId", "La materia ya ha sido asignada");
                        return View(AsignaturaDto);
                    }

                    var asignatura = _mapper.Map<ProfesorAsignatura>(AsignaturaDto);
                    var resultado = await _profesorAsignaturaRepositorio.Actualizar(asignatura);


                    var matriculas = await _profesorAsignaturaRepositorio.ObtenerXProfesorAsync((int)AsignaturaDto.ProfesorId);
                    return View("Index", _mapper.Map<List<ProfesorAsignaturaDto>>(matriculas));

                }
                await CargarControlesAsync((int)AsignaturaDto.ProfesorId);
                return View();

            }

            catch (Exception)
            {
                await CargarControlesAsync((int)AsignaturaDto.ProfesorId);
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id, int ProfesorId)
        {
            ViewData["vwProfesorId"] = ProfesorId;

            var asignatura = await _profesorAsignaturaRepositorio.ObtenerAsync(Id);
            return View(_mapper.Map<ProfesorAsignaturaDto>(asignatura));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id, int ProfesorId)
        {
            await _profesorAsignaturaRepositorio.Eliminar(Id);
            ViewData["vwProfesorId"] = ProfesorId;

            await cargarDatosAsync(ProfesorId);

            var asignatura = await _profesorAsignaturaRepositorio.ObtenerXProfesorAsync(ProfesorId);
            return View("Index", _mapper.Map<List<ProfesorAsignaturaDto>>(asignatura));
        }

        public async Task<IActionResult> ReporteNotas()
        {
            var reporte = await _reporteCalificacionRepositorio.ReporteCalificacion();
            return View(reporte);
        }
    }
}
