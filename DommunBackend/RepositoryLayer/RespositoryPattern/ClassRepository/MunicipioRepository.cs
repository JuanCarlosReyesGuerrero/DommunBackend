using DommunBackend.Common.Logs;
using DommunBackend.Data;
using DommunBackend.DomainLayer.DTOs;
using DommunBackend.DomainLayer.Models;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;
using Microsoft.EntityFrameworkCore;

namespace DommunBackend.RepositoryLayer.RespositoryPattern.ClassRepository
{
    public class MunicipioRepository : IMunicipioRepository, IDisposable
    {
        EnviarLog enviarLog = new EnviarLog();

        private bool disposed = false;

        private ApplicationDbContext context;

        public MunicipioRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<MunicipioDto> ObtenerMunicipioByDepartamento()
        {
            Result oRespuesta = new Result();

            List<MunicipioDto> objlista = new List<MunicipioDto>();

            try
            {
                var conn = context.Database.GetDbConnection();

                conn.Open();

                var command = conn.CreateCommand();

                string sqlQuery = "SELECT Municipios.Id, Municipios.Codigo, Municipios.Nombre, Municipios.DepartamentoId, Municipios.IsActive, Departamentos.Nombre AS DepartamentoNombre " +
                        "FROM Municipios " +
                        "INNER JOIN Departamentos ON Municipios.DepartamentoId = Departamentos.Id";

                command.CommandText = sqlQuery;
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    objlista.Add(new MunicipioDto()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Codigo = reader["Codigo"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        DepartamentoNombre = reader["DepartamentoNombre"].ToString(),
                        DepartamentoId = Convert.ToInt32(reader["DepartamentoId"].ToString()),
                        IsActive = Convert.ToBoolean(reader["IsActive"].ToString()),
                    });
                }

                conn.Close();

                return objlista;

            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                return null;
            }
        }
    }
}
