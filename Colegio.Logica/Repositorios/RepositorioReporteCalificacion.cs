using Colegio.Dtos;
using Colegio.Logica.Contratos;
using Colegio.Logica.Repositorios;
using Colegio.Models.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Repositorios
{
    public class RepositorioReporteCalificacion : IReporteCalificacionRepositorio
    {
        private ColegioContext _context;
        private readonly string _connectionString;

        public RepositorioReporteCalificacion(ColegioContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public async Task<IEnumerable<ReporteCalificacionesDto>> ReporteCalificacion()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spReporteCalificacion", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cMensaje", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                    var response = new List<ReporteCalificacionesDto>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }


        private ReporteCalificacionesDto MapToValue(SqlDataReader reader)
        {
            return new ReporteCalificacionesDto()
            {
                Id = (int)reader["Id"],
                MateriaId = (int?)reader["MateriaId"],
                Periodo = (int?)reader["Periodo"],
                Nota = (double?)reader["Nota"],
                CodigoMateria = (int)reader["CodigoMateria"],
                NombreMateria = (string)reader["NombreMateria"],
                IdentificacionAlumno = (long)reader["IdentificacionAlumno"],
                NombreCompletoAlumno = (string)reader["NombreCompletoAlumno"],
                IdentificacionProfesor = Convert.IsDBNull(reader["IdentificacionProfesor"]) ? null : (long)reader["IdentificacionProfesor"],
                NombreCompletoProfesor = Convert.IsDBNull(reader["NombreCompletoProfesor"]) ? null : (string)reader["NombreCompletoProfesor"],
                Aprueba = (string)reader["Aprueba"]

            };
        }

       
    }
}
