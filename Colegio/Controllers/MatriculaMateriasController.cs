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
    public class MatriculaMateriasController : Controller
    {

        private IProfesorRepositorio _profesor;
        private IMateriaRepositorio _materia;
        private IAlumnoRepositorio _alumno;
        private IMatriculaMateriaRepositorio _matriculaMateriaRepositorio;
        private IReporteCalificacionRepositorio _reporteCalificacionRepositorio;
        private IMapper _mapper;



        public MatriculaMateriasController(IMapper mapper, IProfesorRepositorio empleado, IMateriaRepositorio materia, IMatriculaMateriaRepositorio matriculaMateriaRepositorio, IAlumnoRepositorio alumno, IReporteCalificacionRepositorio reporteCalificacionRepositorio)
        {
            _profesor = empleado;
            _materia = materia;
            _mapper = mapper;
            _alumno = alumno;
            _reporteCalificacionRepositorio = reporteCalificacionRepositorio;
            _matriculaMateriaRepositorio = matriculaMateriaRepositorio;
        }

        public async Task cargarDatosAsync(int EstudianteId)
        {
            var alumno = await _alumno.ObtenerAsync(EstudianteId);
            ViewData["vwEstudianteNombreFull"] = "Alumno: " + alumno.Identificacion.ToString() + " - " + alumno.Nombre + " " + alumno.Apellido;
        }

        private async Task CargarControlesAsync(int EstudianteId)
        {

            var materia = await _materia.ObtenerTodosAsync();
            var materiaDto = _mapper.Map<List<MateriaDto>>(materia);


            var alumno = await _alumno.ObtenerAsync(EstudianteId);
            var alumnoDto = _mapper.Map<AlumnoDto>(alumno);
            List<AlumnoDto> alumndoDtoList = new List<AlumnoDto>();
            alumndoDtoList.Add(alumnoDto);

            ViewData["MateriaId"] = new SelectList(materiaDto, "Id", "Nombre");
            ViewData["AlumnoId"] = new SelectList(alumndoDtoList, "Id", "Nombre");



        }

        public async Task<IActionResult> Index(int EstudianteId)
        {
            await cargarDatosAsync(EstudianteId);
            ViewData["vwEstudianteId"] = EstudianteId.ToString();
            var matricula = await _matriculaMateriaRepositorio.ObtenerXAlumnoAsync(EstudianteId);
            return View(_mapper.Map<List<MatriculaMateriaDto>>(matricula));

        }



        public async Task<IActionResult> Create(int EstudianteId)
        {
            ViewData["vwEstudianteId"] = EstudianteId.ToString();
            await CargarControlesAsync(EstudianteId);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MatriculaMateriaDto MatriculaDto)
        {
            try
            {
                await cargarDatosAsync((int)MatriculaDto.AlumnoId);
                ViewData["vwEstudianteId"] = MatriculaDto.AlumnoId.ToString();

                if (ModelState.IsValid)
                {

                    if (await _matriculaMateriaRepositorio.ValidarMateriaPeriodo((int)MatriculaDto.AlumnoId, (int)MatriculaDto.MateriaId, (int)MatriculaDto.Periodo))
                    {
                        await CargarControlesAsync((int)MatriculaDto.AlumnoId);
                        ModelState.AddModelError("Periodo", "El estudiante ya tiene asignada la materia seleccionada para el perdiodo ingresado");
                        return View(MatriculaDto);
                    }

                    var matricula = _mapper.Map<MatriculaMaterium>(MatriculaDto);
                    await _matriculaMateriaRepositorio.Agregar(matricula);

                    var matriculas = await _matriculaMateriaRepositorio.ObtenerXAlumnoAsync((int)MatriculaDto.AlumnoId);
                    return View("Index", _mapper.Map<List<MatriculaMateriaDto>>(matriculas));
                }

                await CargarControlesAsync((int)MatriculaDto.AlumnoId);

                return View(MatriculaDto);
            }
            catch (Exception ex)
            {
                await CargarControlesAsync((int)MatriculaDto.AlumnoId);
                return View();
            }
        }

        public async Task<IActionResult> Edit(int Id, int EstudianteId)
        {
            ViewData["vwEstudianteId"] = EstudianteId.ToString();
            await CargarControlesAsync(EstudianteId);
            var matricula = await _matriculaMateriaRepositorio.ObtenerAsync(Id);
            return View(_mapper.Map<MatriculaMateriaDto>(matricula));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MatriculaMateriaDto MatriculaDto)
        {
            ViewData["vwEstudianteId"] = MatriculaDto.AlumnoId.ToString();
            await cargarDatosAsync((int)MatriculaDto.AlumnoId);
            try
            {
                if (ModelState.IsValid)
                {

                    if (await _matriculaMateriaRepositorio.ValidarMateriaPeriodo((int)MatriculaDto.AlumnoId, (int)MatriculaDto.MateriaId, (int)MatriculaDto.Periodo, MatriculaDto.Id))
                    {
                        await CargarControlesAsync((int)MatriculaDto.AlumnoId);
                        ModelState.AddModelError("Periodo", "El estudiante ya tiene asignada la materia seleccionada para el perdiodo ingresado");
                        return View(MatriculaDto);
                    }

                    var matricula = _mapper.Map<MatriculaMaterium>(MatriculaDto);
                    var resultado = await _matriculaMateriaRepositorio.Actualizar(matricula);


                    var matriculas = await _matriculaMateriaRepositorio.ObtenerXAlumnoAsync((int)MatriculaDto.AlumnoId);
                    return View("Index", _mapper.Map<List<MatriculaMateriaDto>>(matriculas));

                }
                await CargarControlesAsync((int)MatriculaDto.AlumnoId);
                return View();

            }

            catch (Exception)
            {
                await CargarControlesAsync((int)MatriculaDto.AlumnoId);
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id, int EstudianteId)
        {
            ViewData["vwEstudianteId"] = EstudianteId;

            var matricula = await _matriculaMateriaRepositorio.ObtenerAsync(Id);
            return View(_mapper.Map<MatriculaMateriaDto>(matricula));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id, int AlumnoId)
        {
            await _matriculaMateriaRepositorio.Eliminar(Id);
            ViewData["vwEstudianteId"] = AlumnoId;

            await cargarDatosAsync(AlumnoId);

            var matricula = await _matriculaMateriaRepositorio.ObtenerXAlumnoAsync(AlumnoId);
            return View("Index", _mapper.Map<List<MatriculaMateriaDto>>(matricula));
        }

        public async Task<IActionResult> ReporteNotas()
        {
            var reporte = await _reporteCalificacionRepositorio.ReporteCalificacion();
            return View(reporte);
        }

    }
}
