using AutoMapper;
using Colegio.Dtos;
using Colegio.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Profiles
{
    public class ColegioProfile : Profile
    {
        public ColegioProfile()
        {

            this.CreateMap<Alumno, AlumnoDto>()
            .ForMember(u => u.ValidacionDelete, p => p.MapFrom(m => m.MatriculaMateria.Any()))
            .ReverseMap();

            this.CreateMap<Materium, MateriaDto>()
            .ReverseMap();

            this.CreateMap<Profesor, ProfesorDto>()
            .ReverseMap();


            this.CreateMap<MatriculaMaterium, MatriculaMateriaDto>()
            .ReverseMap();

            this.CreateMap<ProfesorAsignatura, ProfesorAsignaturaDto>()
          .ReverseMap();
        }
    }
}
