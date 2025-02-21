//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Logging;
//using Microsoft.Reporting.NETCore;
//using Ramto.Infraestructura.Data;
//using Ramto.Lib.Interfaces;
//using Ramto.Modelos.Custom;
//using Ramto.Modelos.Request;
//using Ramto.Modelos.Response;
//using System;
//using System.Data;



//namespace Ramto.Infraestructura.Repositories
//{
//    public class PersonaService : IPersona
//    {
//        #region Propiedaedes
//        readonly MigrantesDataContext _migrantesDataContext;
//        private readonly IHostEnvironment environment;
//        #endregion

//        #region Constructor
//        public PersonaService(MigrantesDataContext migrantesDataContext, IHostEnvironment environment)
//        {
//            _migrantesDataContext = migrantesDataContext;
//            this.environment = environment;
//        }


//        #endregion

//        public async Task<SimpleResponse> AgregarPersona(PersonaRequest persona)
//        {
//            SimpleResponse response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                persona.IdPersona = Guid.NewGuid();

//                if (persona.FotoPerfil != "")
//                {
//                    var ImagenPerfilGuardado = await GuardarArchivo(persona.FotoPerfil, persona.IdPersona.ToString(), 2);
//                }

//                if (persona.FotoIdentificacion != "")
//                {
//                    var ImagenDocumentoGuardado = await GuardarArchivo(persona.FotoIdentificacion, "Frente_" + persona.IdPersona.ToString(), 1);

//                }
//                if (persona.FotoIdentificacionReverso != "")
//                {
//                    var ImagenDocumentoGuardado = await GuardarArchivo(persona.FotoIdentificacionReverso, "Reverso_" + persona.IdPersona.ToString(), 1);
//                }


//                command.Parameters.AddWithValue("@OP", "AgregarPersona");
//                command.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
//                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
//                command.Parameters.AddWithValue("@ApellidoPaterno", persona.ApellidoPaterno);
//                command.Parameters.AddWithValue("@ApellidoMaterno", persona.ApellidoMaterno);
//                command.Parameters.AddWithValue("@TieneIdentificacion", persona.TieneIdentificacion);
//                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
//                command.Parameters.AddWithValue("@ClaveIdentificacion", persona.ClaveIdentificacion);
//                command.Parameters.AddWithValue("@FotoIdentificacion", persona.FotoIdentificacion != "" ? $"Documentos/Identificacion/Frente_{persona.IdPersona}.png" : "");
//                command.Parameters.AddWithValue("@FotoIdentificacionReverso", persona.FotoIdentificacionReverso != "" ? $"Documentos/Identificacion/Reverso_{persona.IdPersona}.png" : "");
//                command.Parameters.AddWithValue("@Genero", persona.Genero);
//                command.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
//                command.Parameters.AddWithValue("@CorreoElectronico", persona.CorreoElectronico);
//                command.Parameters.AddWithValue("@FotoPerfil", persona.FotoPerfil != "" ? $"Documentos/FotosPerfil/{persona.IdPersona}.png" : "");
//                command.Parameters.AddWithValue("@Telefono", persona.Telefono);
//                command.Parameters.AddWithValue("@IdCapturo", persona.IdCapturo);
//                try
//                {

//                    await conexion.OpenAsync();

//                    await command.ExecuteNonQueryAsync();
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.IdPersona = persona.IdPersona;
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();

//                }
//            }

//            return response;
//        }

//        public async Task<SimpleResponse> AgregarResidenciaPersona(ResidenciaPersonaRequest persona)
//        {
//            SimpleResponse response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);




//                command.Parameters.AddWithValue("@OP", "AgregarResidencia");
//                command.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
//                command.Parameters.AddWithValue("@EstadoExtranjero", persona.EstadoExtranjero);
//                command.Parameters.AddWithValue("@LocalidadExtranjero", persona.LocalidadExtranjero);
//                command.Parameters.AddWithValue("@MunicipioChiapas", persona.MunicipioChiapas);
//                command.Parameters.AddWithValue("@ColoniaChiapas", persona.ColoniaChiapas);
//                command.Parameters.AddWithValue("@Ocupacion", persona.Ocupacion);
//                command.Parameters.AddWithValue("@AspiraAlgunEmpleo", persona.AspirasAlgunEmpleo);
//                command.Parameters.AddWithValue("@ExperienciaLaboral", persona.ExperienciaLaboral);

//                try
//                {

//                    await conexion.OpenAsync();

//                    await command.ExecuteNonQueryAsync();
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.IdPersona = persona.IdPersona;
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();

//                }
//            }

//            return response;
//        }
//        public async Task<SimpleResponse> AgregarFamiliar(FamiliarRequest persona)
//        {
//            SimpleResponse response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);


//                Guid IdFamiliar = Guid.NewGuid();

//                if (persona.Foto != "")
//                {
//                    var ImagenPerfilGuardadoF = await GuardarArchivo(persona.Foto, IdFamiliar.ToString(), 3);
//                }

//                command.Parameters.AddWithValue("@OP", "AgregarFamiliar");
//                command.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
//                command.Parameters.AddWithValue("@NombreFamiliar", persona.Nombre);
//                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
//                command.Parameters.AddWithValue("@Parentesco", persona.IdParentesco);
//                command.Parameters.AddWithValue("@FechaNacimientoFamiliar", persona.FechaNacimiento);
//                command.Parameters.AddWithValue("@ViajaConFamiliares", persona.ViajaConFamiliares);
//                command.Parameters.AddWithValue("@ViajaConMenores", persona.ViajaConMenores);
//                command.Parameters.AddWithValue("@IdFamiliar", IdFamiliar);
//                command.Parameters.AddWithValue("@FotoFamiliar", persona.Foto != "" ? $"Documentos/Familiares/{IdFamiliar}.png" : "");


//                var ImagenPerfilGuardado = await GuardarArchivo(persona.Foto, IdFamiliar.ToString(), 3);



//                try
//                {

//                    await conexion.OpenAsync();

//                    await command.ExecuteNonQueryAsync();
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.IdPersona = persona.IdPersona;
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();

//                }
//            }

//            return response;
//        }
//        public async Task<Apiresponse<List<FamiliarRequest>>> ObtenerListaFamiliar(Guid IdPersona)
//        {
//            Apiresponse<List<FamiliarRequest>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);




//                command.Parameters.AddWithValue("@OP", "ObtenerFamiliares");
//                command.Parameters.AddWithValue("@IdPersona", IdPersona);

//                try
//                {

//                    await conexion.OpenAsync();

//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new FamiliarRequest()
//                            {
//                                Nombre = reader["Nombre"].ToString(),
//                                Apellidos = reader["Apellidos"].ToString(),
//                                Parentesco = reader["Parentesco"].ToString(),
//                                FechaNacimiento = (DateTime)reader["FechaNacimiento"]

//                            });
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();

//                }
//            }

//            return response;
//        }
//        public async Task<SimpleResponse> GuardarArchivo(string Base64, string Nombre, int TipoDocumento)
//        {
//            SimpleResponse apiCreacionArchivoResponse = new SimpleResponse();
//            //Convertir a Bytes
//            var base64Data = Base64.Split(',');

//            var t = Convert.FromBase64String(base64Data[1]);

//            MemoryStream archivoStream = new MemoryStream(t);
//            FormFile archivoRecibido = new FormFile(archivoStream, 0, archivoStream.Length, null, Nombre);

//            //string Fecha = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
//            string NuevoArchivo = $"{Nombre}.png";
//            string DirectoryPath = Path.Combine(environment.ContentRootPath, "Documentos", TipoDocumento == 1 ? "Identificacion" : TipoDocumento == 2 ? "FotosPerfil" : "Familiares");
//            string FilePath = Path.Combine(DirectoryPath, NuevoArchivo);
//            Directory.CreateDirectory(DirectoryPath);
//            try
//            {
//                using (var fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
//                {
//                    await archivoStream.CopyToAsync(fileStream);
//                }
//                apiCreacionArchivoResponse.Exito = true;
//                apiCreacionArchivoResponse.Mensaje = NuevoArchivo;
//                return apiCreacionArchivoResponse;
//            }
//            catch (Exception ex)
//            {
//                apiCreacionArchivoResponse.Mensaje = ex.Message;
//                return apiCreacionArchivoResponse;
//            }
//        }

//        public async Task<Apiresponse<List<PersonaRequest>>> ObtenerListaPersonasCapturadas(int paginaActual, int cantidad)
//        {
//            Apiresponse<List<PersonaRequest>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "ObtenerPersonas");
//                command.Parameters.AddWithValue("@PaginaActual", paginaActual);
//                command.Parameters.AddWithValue("@CantidadRegistros", cantidad);


//                try
//                {

//                    await conexion.OpenAsync();

//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new PersonaRequest()
//                            {
//                                IdPersona = (Guid)reader["IdPersona"],
//                                Folio = (int)reader["Folio"],
//                                Nombre = reader["Nombre"].ToString(),
//                                FechaNacimiento = (DateTime)reader["FechaNacimiento"],
//                                FechaCaptura = (DateTime)reader["FechaCaptura"],
//                                Capturista = reader["Capturista"].ToString()

//                            });
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();

//                }
//            }

//            return response;
//        }

//        public async Task<string> ReporteInformacionCapturada(Guid IdPersona)
//        {
//            //Crear la estructura de DT


//            Apiresponse<List<ReporteCaptura>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;
//            string Cadena = string.Empty;
//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);




//                command.Parameters.AddWithValue("@OP", "ReporteCaptura");
//                command.Parameters.AddWithValue("@IdPersona", IdPersona);

//                try
//                {

//                    await conexion.OpenAsync();

//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new ReporteCaptura()
//                            {
//                                Folio = (int)reader["Folio"],
//                                Nombre = reader["Nombre"].ToString(),
//                                FechaNacimiento = (DateTime)reader["FechaNacimiento"],
//                                FechaCaptura = (DateTime)reader["FechaCaptura"],
//                                Capturista = reader["Capturista"].ToString(),
//                                TieneIdentificacion = reader["TieneIdentificacion"].ToString(),
//                                TipoIdentificacion = reader["TipoIdentificacion"].ToString(),
//                                ClaveIdentificacion = reader["ClaveIdentificacion"].ToString(),
//                                FotoIdentificacion = reader["FotoIdentificacion"].ToString(),
//                                Genero = reader["Genero"].ToString(),
//                                CorreoElectronico = reader["CorreoElectronico"].ToString(),
//                                FotoPerfil = reader["FotoPerfil"].ToString(),
//                                Telefono = reader["Telefono"].ToString(),
//                                ViajaConFamiliares = reader["ViajaConFamiliares"].ToString(),
//                                ViajaConMenores = reader["ViajaConMenores"].ToString(),
//                                EstadoExtranjero = reader["EstadoExtranjero"].ToString(),
//                                LocalidadExtranjero = reader["LocalidadExtranjero"].ToString(),
//                                MunicipioChiapas = reader["MunicipioChiapas"].ToString(),
//                                ColoniaChiapas = reader["ColoniaChiapas"].ToString(),
//                                Ocupacion = reader["Ocupacion"].ToString(),
//                                AspiraAlgunEmpleo = reader["AspiraAlgunEmpleo"].ToString(),
//                                ExperienciaLaboral = reader["ExperienciaLaboral"].ToString(),
//                                NombreFamiliar = reader["NombreFamiliar"].ToString(),
//                                Parentesco = reader["Parentesco"].ToString(),
//                                FechaNacimientoFamiliar = (DateTime)reader["FechaNacimientoFamiliar"],

//                            });
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();
//                    //Generar PDF
//                    try
//                    {


//                        LocalReport report = new LocalReport();
//                        report.ReportPath = "./Documentos/Reportes/CedulaPersona.rdlc";

//                        //Cabecera
//                        ReportDataSource rds = new ReportDataSource();
//                        rds.Name = "ReferenciaDataSet";//This refers to the dataset name in the RDLC file 

//                        foreach (var item in response.data)
//                        {

//                            string ruta = environment.ContentRootPath;
//                            var archivoPath = Path.Combine(ruta, item.FotoPerfil);
//                            var imagenBytes = await System.IO.File.ReadAllBytesAsync(archivoPath);
//                            item.FotoPerfilImage = imagenBytes;
//                            //dt.Rows.Add(item.Folio,item.Nombre,item.TieneIdentificacion,item.TipoIdentificacion,item.ClaveIdentificacion,item.Genero,item.FechaNacimiento,
//                            //    item.CorreoElectronico,item.Telefono,item.ViajaConFamiliares,item.ViajaConMenores,item.EstadoExtranjero,item.LocalidadExtranjero,
//                            //    item.MunicipioChiapas,item.ColoniaChiapas,item.Ocupacion,item.AspiraAlgunEmpleo,item.FechaCaptura,item.Capturista,item.NombreFamiliar,
//                            //    item.Parentesco,item.FechaNacimientoFamiliar,item.FotoPerfilImage);

//                        }

//                        rds.Value = response.data;
//                        report.DataSources.Clear();

//                        report.DataSources.Add(rds);

//                        report.EnableExternalImages = true;

//                        report.Refresh();
//                        string contentType = string.Empty;
//                        contentType = "application/pdf";

//                        string mimeType, encoding, extension;

//                        Warning[] warnings;
//                        string[] streams;
//                        var renderedBytes = report.Render
//                            (
//                                "PDF",
//                                @"<DeviceInfo><OutputFormat>PDF</OutputFormat><HumanReadablePDF>False</HumanReadablePDF></DeviceInfo>",
//                                out mimeType,
//                                out encoding,
//                                out extension,
//                                out streams,
//                                out warnings
//                            );

//                        Cadena = Convert.ToBase64String(renderedBytes);
//                    }
//                    catch (Exception ex)
//                    {

//                        throw;
//                    }


//                }
//            }

//            return Cadena;
//        }

//        public async Task<Apiresponse<List<EstadosResponse>>> ObtenerEstadosUnidos()
//        {
//            Apiresponse<List<EstadosResponse>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "EstadosUnidos");


//                try
//                {

//                    await conexion.OpenAsync();

//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new EstadosResponse()
//                            {
//                                Id = (int)reader["Id"],
//                                Nombre = reader["Nombre"].ToString()


//                            });
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();

//                }
//            }

//            return response;
//        }

//        public async Task<Apiresponse<List<EstadosResponse>>> ObtenerMunicipiosChiapas()
//        {
//            Apiresponse<List<EstadosResponse>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "MunicipioChiapas");


//                try
//                {

//                    await conexion.OpenAsync();

//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        int contado = 1;
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new EstadosResponse()
//                            {
//                                Id = contado,
//                                Nombre = reader["Nombre"].ToString()
//                            });
//                            contado++;
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();

//                }
//            }

//            return response;
//        }
//        public async Task<Apiresponse<List<EstadosResponse>>> ObtenerColoniasChiapas(string Nombre)
//        {
//            Apiresponse<List<EstadosResponse>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "ColoniasChiapas");
//                command.Parameters.AddWithValue("@NombreMuncipio", Nombre);

//                try
//                {

//                    await conexion.OpenAsync();

//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new EstadosResponse()
//                            {
//                                Id = (int)reader["IdCP"],
//                                Nombre = reader["Nombre"].ToString()
//                            });

//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();

//                }
//            }

//            return response;
//        }

//        public async Task<Apiresponse<List<EstadosResponse>>> ObtenerOficios()
//        {
//            Apiresponse<List<EstadosResponse>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "Oficios");


//                try
//                {

//                    await conexion.OpenAsync();

//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new EstadosResponse()
//                            {
//                                Id = (int)reader["Id"],
//                                Nombre = reader["Nombre"].ToString()
//                            });

//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();

//                }
//            }

//            return response;
//        }

//        //obtener datos para graficar el genero de las personas
//        public async Task<Apiresponse<List<GeneroResponse>>> ObtenerDatosGenero()
//        {
//            Apiresponse<List<GeneroResponse>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "GraficarGenero");

//                try
//                {
//                    await conexion.OpenAsync();
//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new GeneroResponse()
//                            {
//                                Genero = reader["Genero"].ToString(),
//                                Cantidad = (int)reader["Cantidad"]
//                            });
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();
//                }
//            }

//            return response;
//        }

//        public async Task<Apiresponse<List<OficioResponse>>> ObtenerDatosOficio(int idOficio)
//        {
//            Apiresponse<List<OficioResponse>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "GraficarOficio");
//                command.Parameters.AddWithValue("@IdOficio", idOficio);

//                try
//                {
//                    await conexion.OpenAsync();
//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new OficioResponse()
//                            {
//                                Oficio = reader["Oficio"].ToString(),
//                                Cantidad = (int)reader["Cantidad"]
//                            });
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();
//                }
//            }

//            return response;
//        }

//        public async Task<Apiresponse<List<ExtranjeroResponse>>> ObtenerEstadoExtranjero(int idEstadoExtranjero)
//        {
//            Apiresponse<List<ExtranjeroResponse>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "GraficarEstado");
//                command.Parameters.AddWithValue("@IdEstadoExtranjero", idEstadoExtranjero);

//                try
//                {
//                    await conexion.OpenAsync();
//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new ExtranjeroResponse()
//                            {
//                                Estado = reader["Estado"].ToString(),
//                                Cantidad = (int)reader["Cantidad"]
//                            });
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();
//                }
//            }

//            return response;

//        }

//        public async Task<Apiresponse<List<MenoresEdadResponse>>> ObtenerDatosMenoresEdad(int edadMin, int edadMax)
//        {
//            Apiresponse<List<MenoresEdadResponse>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "GraficarMenoresEdad");
//                command.Parameters.AddWithValue("@EdadMin", edadMin);
//                command.Parameters.AddWithValue("@EdadMax", edadMax);

//                try
//                {
//                    await conexion.OpenAsync();
//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new MenoresEdadResponse()
//                            {
//                                Edad = (int)reader["Edad"],
//                                Cantidad = (int)reader["Cantidad"]
//                            });
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();
//                }
//            }

//            return response;
//        }

//        public async Task<Apiresponse<List<GruposEdadResponse>>> ObtenerDatosGruposEdad()
//        {
//            Apiresponse<List<GruposEdadResponse>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "GraficarGruposEdad");

//                try
//                {
//                    await conexion.OpenAsync();
//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new GruposEdadResponse()
//                            {
//                                RangoEdad = reader["RangoEdad"].ToString(),
//                                Cantidad = (int)reader["Cantidad"]
//                            });
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();
//                }
//            }

//            return response;
//        }

//        //implementar el sp [dbo].[Agregar] para dar de alta usuarios de captura
//        public async Task<SimpleResponse> AgregarUsuario(AgregarUsuarioRequest usuario)
//        {
//            Apiresponse<List<AgregarUsuarioRequestDTO>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;
//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[Agregar]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;
//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);
//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);
//                command.Parameters.AddWithValue("@OP", "AgregarUsuario");
//                command.Parameters.AddWithValue("@UserName", usuario.UserName);
//                command.Parameters.AddWithValue("@Password", usuario.Password);
//                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
//                command.Parameters.AddWithValue("@IdRol", usuario.IdRol);
//                try
//                {
//                    await conexion.OpenAsync();
//                    await command.ExecuteNonQueryAsync();
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }
//                conexion.Close();
//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();
//                }
//            }
//            return response;



//        }

//        //obtener lista de usuarios
//        public async Task<Apiresponse<List<ObtenerUsuarioResponse>>> ObtenerListaUsuarios()
//        {
//            Apiresponse<List<ObtenerUsuarioResponse>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[Agregar]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "ObtenerUsuarios");

//                try
//                {
//                    await conexion.OpenAsync();
//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new ObtenerUsuarioResponse()
//                            {
//                                Id = (int)reader["Id"],
//                                UserName = reader["UserName"].ToString(),
//                                Nombre = reader["Nombre"].ToString(),
//                                IdRol = (int)reader["IdRol"],


//                            });
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();
//                }
//            }

//            return response;
//        }

//        public async Task<SimpleResponse> EliminarUsuario(EliminarUsuarioRequest usuario)
//        {
//            Apiresponse<List<EliminarUsuarioRequestDTO>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;
//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[Agregar]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;
//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);
//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);
//                command.Parameters.AddWithValue("@OP", "Eliminar");
//                command.Parameters.AddWithValue("@Id", usuario.Id);

//                try
//                {
//                    await conexion.OpenAsync();
//                    await command.ExecuteNonQueryAsync();
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }
//                conexion.Close();
//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();
//                }
//            }
//            return response;



//        }

//        public async Task<SimpleResponse> ActualizarUsuario(ActualizarUsuarioRequest usuario)
//        {
//            Apiresponse<List<ActualizarUsuarioRequestDTO>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;
//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[Agregar]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;
//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);
//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);
//                command.Parameters.AddWithValue("@OP", "Actualizar");
//                command.Parameters.AddWithValue("@Id", usuario.Id);
//                command.Parameters.AddWithValue("@NuevoUserName", usuario.NuevoUserName);
//                command.Parameters.AddWithValue("@NuevoPassword", usuario.NuevoPassword);
//                command.Parameters.AddWithValue("@NuevoIdRol", usuario.NuevoIdRol);

//                try
//                {
//                    await conexion.OpenAsync();
//                    await command.ExecuteNonQueryAsync();
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }
//                conexion.Close();
//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();
//                }
//            }
//            return response;



//        }
//        public async Task<string> Exportar()
//        {
//            Apiresponse<List<ExportarResponse>> response = new();
//            bool errors = false;
//            string connectionString = _migrantesDataContext.Database.GetDbConnection().ConnectionString;

//            using (var conexion = new SqlConnection(connectionString))
//            {
//                using var command = new SqlCommand();
//                command.Connection = conexion;
//                command.CommandText = "[dbo].[AdministrarRegistrosMigrantes]";
//                command.CommandType = System.Data.CommandType.StoredProcedure;

//                SqlParameter exito = new SqlParameter();
//                exito.ParameterName = "@Exito";
//                exito.SqlDbType = SqlDbType.Bit;
//                exito.Direction = ParameterDirection.Output;
//                command.Parameters.Add(exito);

//                SqlParameter mensaje = new SqlParameter();
//                mensaje.ParameterName = "@Mensaje";
//                mensaje.SqlDbType = SqlDbType.VarChar;
//                mensaje.Size = int.MaxValue;
//                mensaje.Direction = ParameterDirection.Output;
//                command.Parameters.Add(mensaje);

//                command.Parameters.AddWithValue("@OP", "Exportar");

//                try
//                {
//                    await conexion.OpenAsync();
//                    var reader = await command.ExecuteReaderAsync();
//                    if (reader.HasRows)
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            response.data.Add(new ExportarResponse()
//                            {
//                                NombrePersona = reader["NombrePersona"].ToString(),
//                                Edad = reader["Edad"].ToString(),
//                                FechaNacimiento = (DateTime)reader["FechaNacimiento"],
//                                Sexo = reader["Sexo"].ToString(),
//                                NumeroTelefono = reader["NumeroTelefono"].ToString(),
//                                Correo = reader["Correo"].ToString(),
//                                CuentaIdentificacion = reader["CuentaIdentificacion"].ToString(),
//                                TipoIdentificacion = reader["TipoIdentificacion"].ToString(),
//                                Oficio = reader["Oficio"].ToString(),
//                                Aspiras = reader["Aspiras"].ToString(),
//                                ResidenciaExtranjera = reader["ResidenciaExtranjera"].ToString(),
//                                MunicipioChiapas = reader["MunicipioChiapas"].ToString(),
//                                ViajaConFamiliares = reader["ViajaConFamiliares"].ToString(),
//                                ViajaConMenores = reader["ViajaConMenores"].ToString(),
//                                Familiar = reader["Familiar"].ToString(),
//                                EdadFamiliar = reader["EdadFamiliar"].ToString(),
//                                FechaF = reader["FechaF"].ToString(),

//                            });
//                        }
//                    }
//                }
//                catch (SqlException ex)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = ex.Message;
//                }
//                catch (Exception e)
//                {
//                    errors = true;
//                    response.Exito = false;
//                    response.Mensaje = e.Message;
//                }

//                conexion.Close();

//                if (!errors)
//                {
//                    response.Exito = (bool)exito.Value;
//                    response.Mensaje = mensaje.Value.ToString();
//                }
//            }


//            if (!response.Exito)
//            {
//                // Si la respuesta no es exitosa, devolver un string vacío
//                return string.Empty;
//            }

//            try
//            {
//                //    // Establecer el contexto de licencia
//                  ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//                using var package = new OfficeOpenXml.ExcelPackage();
//                var worksheet = package.Workbook.Worksheets.Add("Reporte");

//                // Agregar encabezados
//                worksheet.Cells[1, 1].Value = "Nombre de la Persona";
//                worksheet.Cells[1, 2].Value = "Edad";
//                worksheet.Cells[1, 3].Value = "Oficio";
//                worksheet.Cells[1, 4].Value = "Residencia en el extranjero";
//                worksheet.Cells[1, 5].Value = "Familar(es)";
//                worksheet.Cells[1, 6].Value = "Edad";

//                int row = 2; // Comienza en la fila 2
//                foreach (var item in response.data)
//                {
//                    worksheet.Cells[row, 1].Value = item.NombrePersona;
//                    worksheet.Cells[row, 2].Value = int.Parse(item.Edad);
//                    worksheet.Cells[row, 3].Value = item.Oficio;
//                    worksheet.Cells[row, 4].Value = item.ResidenciaExtranjera;
//                    worksheet.Cells[row, 5].Value = item.Familiar;
//                    worksheet.Cells[row, 6].Value = item.EdadFamiliar;
//                    row++;
//                }

//                // Ajustar el ancho de las columnas para que se adapten al contenido
//                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

//                // Convertir el contenido del archivo Excel a Base64
//                var excelBytes = package.GetAsByteArray();
//                string Cadena = Convert.ToBase64String(excelBytes);
//                return Cadena;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Error al generar el reporte Excel: {ex.Message}");
//            }
      



//        }
//        //public async Task<string> GenerarExcel()
//        //{
//        //    // Establecer el contexto de licencia
//        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
//        //    // Obtener los datos de ReporteExcelLista
//        //    var response = await Exportar();
//        //    if (!response.Exito)
//        //    {
//        //        // Si la respuesta no es exitosa, devolver un string vacío
//        //        return string.Empty;
//        //    }

//        //    try
//        //    {
//        //        using var package = new OfficeOpenXml.ExcelPackage();
//        //        var worksheet = package.Workbook.Worksheets.Add("Reporte");

//        //        // Agregar encabezados
//        //        worksheet.Cells[1, 1].Value = "Nombre de la Persona";
//        //        worksheet.Cells[1, 2].Value = "Edad";
//        //        worksheet.Cells[1, 3].Value = "Oficio";
//        //        worksheet.Cells[1, 4].Value = "Residencia en el extranjero";
//        //        worksheet.Cells[1, 5].Value = "Familar(es)";
//        //        worksheet.Cells[1, 5].Value = "Edad";

//        //        int row = 2; // Comienza en la fila 2
//        //        foreach (var item in response.data)
//        //        {
//        //            worksheet.Cells[row, 1].Value = item.NombrePersona;
//        //            worksheet.Cells[row, 2].Value = item.Edad;
//        //            worksheet.Cells[row, 3].Value = item.Oficio;
//        //            worksheet.Cells[row, 4].Value = item.ResidenciaExtranjera;
//        //            worksheet.Cells[row, 5].Value = item.Familiar;
//        //            worksheet.Cells[row, 6].Value = item.EdadFamiliar;
//        //            row++;
//        //        }

//        //        // Ajustar el ancho de las columnas para que se adapten al contenido
//        //        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

//        //        // Convertir el contenido del archivo Excel a Base64
//        //        var excelBytes = package.GetAsByteArray();
//        //        string Cadena = Convert.ToBase64String(excelBytes);
//        //        return Cadena;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw new Exception($"Error al generar el reporte Excel: {ex.Message}");
//        //    }
//        //}
//    }
//}
