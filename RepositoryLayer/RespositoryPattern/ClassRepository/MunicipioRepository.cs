using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.Interface;
using Common;
using Microsoft.Data.SqlClient;
using System.Data;
using DomainLayer.DTOs;
using Common.Logs;
using Microsoft.Extensions.Configuration;

namespace RepositoryLayer.RespositoryPattern.ClassRepository
{
    public class MunicipioRepository : IMunicipioRepository, IDisposable
    {
        public IConfiguration configuration;

        EnviarLog enviarLog = new EnviarLog();

        //readonly Parameters objParameters = new Parameters(IConfiguration _configuration);

        private ApplicationDbContext context;

        public MunicipioRepository(IConfiguration _configuration, ApplicationDbContext context)
        {
            this.configuration = _configuration;
            this.context = context;
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;

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

        public IEnumerable<Municipio> GetAll()
        {
            throw new NotImplementedException();
        }

        public Municipio GetByID(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Municipio entity)
        {
            throw new NotImplementedException();
        }

        public List<MunicipioDto> ObtenerMunicipioByDepartamento()
        {
            Result oRespuesta = new Result();

            //string cadenaconexion = objParameters.cadenaConexion();
            string cadenaconexion = configuration["ConnectionStrings:DefaultConnection"];

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaconexion))
                {
                    string sqlQuery = "";

                    sqlQuery = "SELECT Municipios.Id, Municipios.Codigo, Municipios.Nombre, Municipios.DepartamentoId, Municipios.IsActive, Departamentos.Nombre AS DepartamentoNombre " +
                        "FROM Municipios " +
                        "INNER JOIN Departamentos ON Municipios.DepartamentoId = Departamentos.Id";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout *= 3;

                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        List<MunicipioDto> listObj = new List<MunicipioDto>();
                        MunicipioDto objModel = null;

                        while (reader.Read())
                        {
                            objModel = new MunicipioDto();

                            objModel.Id = Convert.ToInt32(reader["Id"].ToString());
                            objModel.Codigo = reader["Codigo"].ToString();
                            objModel.Nombre = reader["Nombre"].ToString();
                            objModel.DepartamentoNombre = reader["DepartamentoNombre"].ToString();
                            objModel.DepartamentoId = Convert.ToInt32(reader["DepartamentoId"].ToString());
                            objModel.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());

                            listObj.Add(objModel);
                        }

                        con.Close();

                        return listObj;
                    }
                }

            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                return null;
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Municipio entity)
        {
            throw new NotImplementedException();
        }
    }
}
