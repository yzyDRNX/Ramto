using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ramto.Infraestructura.Data;
using Ramto.Lib.Interfaces;
using Ramto.Modelos.Request;
using Ramto.Modelos.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ramto.Infraestructura.Repositories
{
    public class SeguridadService : ISeguridad
    {
        #region Propiedaedes
        readonly RamtoDataContext _ramtoDataContext;
        #endregion

        #region Constructor
        public SeguridadService(RamtoDataContext ramtoDataContext)
        {
            _ramtoDataContext = ramtoDataContext;
        }
        #endregion


        public async Task<Apiresponse<UsuarioResponse>> Login(UsuarioRequest usuario)
        {
            Apiresponse<UsuarioResponse> response = new();
            bool errors = false;
            string connectionString = _ramtoDataContext.Database.GetDbConnection().ConnectionString;

            using (var conexion = new SqlConnection(connectionString))
            {
                using var command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "[dbo].[Login]";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter exito = new SqlParameter();
                exito.ParameterName = "@Exito";
                exito.SqlDbType = SqlDbType.Bit;
                exito.Direction = ParameterDirection.Output;
                command.Parameters.Add(exito);

                SqlParameter mensaje = new SqlParameter();
                mensaje.ParameterName = "@Mensaje";
                mensaje.SqlDbType = SqlDbType.VarChar;
                mensaje.Size = int.MaxValue;
                mensaje.Direction = ParameterDirection.Output;
                command.Parameters.Add(mensaje);

                command.Parameters.AddWithValue("@Username", usuario.Username);
                command.Parameters.AddWithValue("@Password", usuario.Password);

                try
                {
                    await conexion.OpenAsync();

                    var reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        if (await reader.ReadAsync())
                        {
                            response.data = new UsuarioResponse
                            {
                                Id = reader["Id"] as int? ?? 0,
                                Username = reader["UserName"] as string,
                                
                             
                            };
                        }
                    }
                    else
                    {
                        response.Exito = false;
                        response.Mensaje = "Usuario o contraseña incorrectos";
                    }
                }
                catch (SqlException ex)
                {
                    errors = true;
                    response.Exito = false;
                    response.Mensaje = ex.Message;
                }
                catch (Exception e)
                {
                    errors = true;
                    response.Exito = false;
                    response.Mensaje = e.Message;
                }

                conexion.Close();

                if (!errors)
                {
                    response.Exito = (bool)exito.Value;
                    response.Mensaje = mensaje.Value.ToString();
                }
            }

            return response;
        }
    }
}
