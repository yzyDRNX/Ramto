//using Core.MVVM;
//using Ramto.Lib.BL;
//using Ramto.Lib.Enumeraciones;
//using Ramto.Lib.OS.Interfaces;
//using Ramto.Modelos.Custom;
//using Ramto.Modelos.Request;
//using Ramto.Modelos.Response;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace Ramto.Lib.ViewModels
//{
//    public class FormularioViewModel : ViewModelBase
//    {
//        #region Propiedades
//        readonly PersonaBL _personaBL;

//        private List<string> errores = new List<string>();
//        public List<string> Errores { get => errores; set => Set(ref errores, value); }


//        private List<EstadosResponse> estadosResponse = new List<EstadosResponse>();
//        public List<EstadosResponse> EstadosUnidos { get => estadosResponse; set => Set(ref estadosResponse, value); }
//        private List<EstadosResponse> municipiosResponse = new List<EstadosResponse>();
//        public List<EstadosResponse> MunicipiosResponse { get => municipiosResponse; set => Set(ref municipiosResponse, value); }

//        private List<EstadosResponse> coloniasResponse = new List<EstadosResponse>();
//        public List<EstadosResponse> ColoniasResponse { get => coloniasResponse; set => Set(ref coloniasResponse, value); }

//        private List<EstadosResponse> oficios = new List<EstadosResponse>();
//        public List<EstadosResponse> Oficios { get => oficios; set => Set(ref oficios, value); }

//        private PersonaRequestDTO entidad = new PersonaRequestDTO();
//        public PersonaRequestDTO Entidad { get => entidad; set => Set(ref entidad, value); }



//        private ResidenciaPersonaRequestDTO entidadResidencia = new ResidenciaPersonaRequestDTO();
//        public ResidenciaPersonaRequestDTO EntidadResidencia { get => entidadResidencia; set => Set(ref entidadResidencia, value); }



//        private List<FamiliarRequestDTO> familiares = new List<FamiliarRequestDTO>();
//        public List<FamiliarRequestDTO> Familiares { get => familiares; set => Set(ref familiares, value); }



//        private FamiliarRequestDTO entidadFamilar = new FamiliarRequestDTO();
//        public FamiliarRequestDTO EntidadFamilar { get => entidadFamilar; set => Set(ref entidadFamilar, value); }

//        private AgregarUsuarioRequestDTO entidadUsuario = new AgregarUsuarioRequestDTO();
//        public AgregarUsuarioRequestDTO EntidadUsuario { get => entidadUsuario; set => Set(ref entidadUsuario, value); }

//        private ActualizarUsuarioRequestDTO entidadUsuarioActualizar = new ActualizarUsuarioRequestDTO();
//        public ActualizarUsuarioRequestDTO EntidadUsuarioActualizar { get => entidadUsuarioActualizar; set => Set(ref entidadUsuarioActualizar, value); }


//        private List<ObtenerUsuarioResponse> usuarios = new List<ObtenerUsuarioResponse>();
//        public List<ObtenerUsuarioResponse> Usuarios { get => usuarios; set => Set(ref usuarios, value); }
//        public async Task<List<ObtenerUsuarioResponse>> ObtenerListaUsuarios()
//        {
//            return await _personaBL.ObtenerListaUsuarios();
//        }
//        public async Task<SimpleResponse> EliminarUsuario(EliminarUsuarioRequest data)
//        {
//            var response = await _personaBL.EliminarUsuario(data);
//            return response; // Devolvemos el objeto SimpleResponse directamente
//        }


//        private SimpleResponse response;
//        public SimpleResponse Response { get => response; set => Set(ref response, value); }
//        #endregion
//        public FormularioViewModel()
//        {
//            _personaBL = new();
//            Loading = false;
//            EntidadResidencia.PropertyChanged += (ar, send) =>
//            {
//                switch (send.PropertyName)
//                {
//                    case "MunicipioChiapas":
//                        _ = ObtenerColoniasChiapas(EntidadResidencia.MunicipioChiapas);
//                        break;

//                    default:
//                        break;
//                }
//            };


//        }

//        #region Commands





//        RelayCommand agregarCommand = null;
//        public RelayCommand AgregarCommand
//        {
//            get => agregarCommand ?? (agregarCommand = new RelayCommand(async () =>
//            {
//                try
//                {
//                    if (!ValidarCampos())
//                    {
//                        return;
//                    }


//                    await ObtenerEstadosUnidos();
//                    await ObtenerMunicipiosChiapas();
//                    await ObtenerOficios();
//                    var res = await DependencyService.Get<ILocalStorage>().GetValue<UsuarioResponse>(LocalStorageKeys.Usuario);
//                    Entidad.IdCapturo = res.Id;
//                    var request = new PersonaRequest
//                    {
//                        Nombre = Entidad.Nombre,
//                        ApellidoPaterno = Entidad.ApellidoPaterno,
//                        ApellidoMaterno = string.IsNullOrEmpty(Entidad.ApellidoMaterno) ? "" : Entidad.ApellidoMaterno,
//                        TieneIdentificacion = Entidad.TieneIdentificacion,
//                        Identificacion = string.IsNullOrEmpty(Entidad.Identificacion) ? "" : Entidad.Identificacion,
//                        ClaveIdentificacion = string.IsNullOrEmpty(Entidad.ClaveIdentificacion) ? "" : Entidad.ClaveIdentificacion,
//                        FotoIdentificacion = string.IsNullOrEmpty(Entidad.FotoIdentificacion) ? "" : Entidad.FotoIdentificacion,
//                        FotoIdentificacionReverso = string.IsNullOrEmpty(Entidad.FotoIdentificacionReverso) ? "" : Entidad.FotoIdentificacionReverso,
//                        Genero = Entidad.Genero,
//                        FechaNacimiento = Entidad.FechaNacimiento,
//                        CorreoElectronico = Entidad.CorreoElectronico,
//                        FotoPerfil = Entidad.FotoPerfil,
//                        Telefono = Entidad.Telefono,
//                        IdCapturo = Entidad.IdCapturo,
//                        Capturista = "",
//                        LugarCaputura = "",




//                    };


//                    Loading = true;
//                    response = await _personaBL.AgregarPersona(request);
//                    Loading = false;

//                    if (response.Exito)
//                    {
//                        await DependencyService.Get<ILocalStorage>().SetValue(LocalStorageKeys.IdPersona, response.IdPersona);
//                        await DependencyService.Get<INavigationService>().NavigateTo(Helpers.PagesKeys.Residencia);
//                    }
//                    else
//                    {
//                        //await _dialogService.ShowMessage("Error", response.Mensaje, "Aceptar");
//                        Errores.Add("Ya existe una persona con datos similares o repetidos");
//                    }

//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//                finally
//                {
//                    Loading = false;
//                }
//            }, () => { return true; }));
//        }
//        #endregion

//        #region Usuario

//        public void ResetEntidadUsuario()
//        {
//            EntidadUsuario.UserName = string.Empty;
//            EntidadUsuario.Password = string.Empty;
//            EntidadUsuario.Nombre = string.Empty;
//            EntidadUsuario.IdRol = 0;
//        }
//        RelayCommand agregarCommandU = null;
//        public RelayCommand AgregarCommandU
//        {
//            get => agregarCommandU ?? (agregarCommandU = new RelayCommand(async () =>
//            {

//                try
//                {
//                    if (!ValidarCamposUsuario())
//                    {
//                        return;
//                    }

//                    var request = new AgregarUsuarioRequest
//                    {
                        
//                        UserName = EntidadUsuario.UserName,
//                        Password = EntidadUsuario.Password,
//                        Nombre = EntidadUsuario.Nombre,
//                        IdRol = EntidadUsuario.IdRol,
//                    };

//                    Loading = true;
//                    response = await _personaBL.AgregarUsuario(request);
//                    Loading = false;

//                    if (response.Exito)
//                    {
//                        // Lógica para enviar el mensaje al administrador
//                        var mensaje = "Usuarios insertados correctamente.";
//                        // Aquí puedes agregar la lógica para enviar el mensaje, por ejemplo, a través de un servicio de notificaciones
//                        Console.WriteLine(mensaje);
//                        ResetEntidadUsuario();
//                    }
//                    else
//                    {
//                        Errores.Add("UserName ya registrado, utilice otro.");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//                finally
//                {
//                    Loading = false;
//                }
//            }, () => { return true; }));
//        }


//        RelayCommand actualizarCommandU = null;
//        public RelayCommand ActualizarCommandU
//        {
//            get => actualizarCommandU ?? (actualizarCommandU = new RelayCommand(async () =>
//            {
//                try
//                {
   
//                    var request = new ActualizarUsuarioRequest
//                    {
//                        Id = EntidadUsuarioActualizar.Id,
//                        NuevoUserName = EntidadUsuarioActualizar.NuevoUserName,
//                        NuevoPassword = EntidadUsuarioActualizar.NuevoPassword,
//                        NuevoIdRol = EntidadUsuarioActualizar.NuevoIdRol
//                    };

//                    Loading = true;
//                    Response = await _personaBL.ActualizarUsuario(request);
//                    Loading = false;

//                    if (Response.Exito)
//                    {
//                        var mensaje = "Usuario actualizado correctamente.";
//                        Console.WriteLine(mensaje);
//                        ResetEntidadUsuario();
//                    }
//                    else
//                    {
//                        Errores.Add($"El UserName ya está en uso, elija otro.");
//                        Console.Error.WriteLine($"Error al actualizar usuario: {Response.Mensaje}");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//                finally
//                {
//                    Loading = false;
//                }
//            }, () => { return true; }));
//        }


//        #endregion

//        #region Residencia

//        RelayCommand agregarResidenciaCommand = null;
//        public RelayCommand AgregarResidenciaCommand
//        {
//            get => agregarResidenciaCommand ?? (agregarResidenciaCommand = new RelayCommand(async () =>
//            {
//                try
//                {

//                    if (!ValidarCamposResidencia())
//                    {
//                        return;
//                    }
//                    EntidadResidencia.IdPersona = await DependencyService.Get<ILocalStorage>().GetValue<Guid>(LocalStorageKeys.IdPersona);
//                    var request = new ResidenciaPersonaRequest
//                    {
//                        EstadoExtranjero = EntidadResidencia.EstadoExtranjero,
//                        LocalidadExtranjero = EntidadResidencia.LocalidadExtranjero,
//                        MunicipioChiapas = EntidadResidencia.MunicipioChiapas,
//                        ColoniaChiapas = EntidadResidencia.ColoniaChiapas,
//                        Ocupacion = EntidadResidencia.Ocupacion,
//                        AspirasAlgunEmpleo = EntidadResidencia.AspirasAlgunEmpleo == 0 ? false : true,
//                        ExperienciaLaboral = string.IsNullOrEmpty(EntidadResidencia.ExperienciaLaboral) ? "" : EntidadResidencia.ExperienciaLaboral,
//                        IdPersona = EntidadResidencia.IdPersona


//                    };


//                    Loading = true;
//                    response = await _personaBL.AgregarResidenciaPersona(request);
//                    Loading = false;

//                    if (response.Exito)
//                    {
//                        await DependencyService.Get<ILocalStorage>().SetValue(LocalStorageKeys.IdPersona, response.IdPersona);
//                        await DependencyService.Get<INavigationService>().NavigateTo(Helpers.PagesKeys.RegistroFamiliares);
//                    }
//                    else
//                    {
//                        //await _dialogService.ShowMessage("Error", response.Mensaje, "Aceptar");
//                    }

//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//                finally
//                {
//                    Loading = false;
//                }
//            }, () => { return true; }));
//        }
//        #endregion
//        #region Familiar

//        RelayCommand agregarFamiliarCommand = null;
//        public RelayCommand AgregarFamiliarCommand
//        {
//            get => agregarFamiliarCommand ?? (agregarFamiliarCommand = new RelayCommand(async () =>
//            {
//                try
//                {
//                    if (!ValidarCamposFamiliar())
//                    {
//                        return;
//                    }


//                    EntidadResidencia.IdPersona = await DependencyService.Get<ILocalStorage>().GetValue<Guid>(LocalStorageKeys.IdPersona);
//                    var request = new FamiliarRequest
//                    {
//                        IdPersona = EntidadResidencia.IdPersona,
//                        Nombre = EntidadFamilar.Nombre,
//                        Apellidos = EntidadFamilar.Apellidos,
//                        IdParentesco = EntidadFamilar.Idparentesco,
//                        FechaNacimiento = EntidadFamilar.FechaNacimiento,
//                        ViajaConFamiliares = EntidadFamilar.ViajeConFamiliar == 0 ? false : true,
//                        ViajaConMenores = EntidadFamilar.ViajeConMenores == 0 ? false : true,
//                        Parentesco = EntidadFamilar.Parentesco == null ? "" : EntidadFamilar.Parentesco,
//                        Foto = string.IsNullOrEmpty(EntidadFamilar.FotoPerfilF) ? "" : EntidadFamilar.FotoPerfilF

//                    };


//                    Loading = true;
//                    response = await _personaBL.AgregarFamiliarPersona(request);
//                    Loading = false;

//                    if (response.Exito)
//                    {
//                        Familiares = await _personaBL.ObtenerListaFamiliarPersona(request);

//                    }
//                    else
//                    {
//                        //await _dialogService.ShowMessage("Error", response.Mensaje, "Aceptar");
//                    }

//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//                finally
//                {
//                    Loading = false;
//                }
//            }, () => { return true; }));
//        }
//        #endregion
//        #region Imprimir Cedula
//        private string reportePDF = "";
//        public string ReportePDF { get => reportePDF; set => Set(ref reportePDF, value); }

//        RelayCommand imprimirReportePersonaCommand = null;
//        public RelayCommand ImprimirReportePersonaCommand
//        {
//            get => imprimirReportePersonaCommand ??= new RelayCommand(async () =>
//            {
//                try
//                {
//                    Loading = true; // Mostrar el mensaje de carga

//                    var res = await DependencyService.Get<ILocalStorage>().GetValue<Guid>(LocalStorageKeys.IdPersona);

//                    ReportePDF = await _personaBL.ReporteCapturaPersona(res);
//                    await DependencyService.Get<INavigationService>().NavigateTo(Helpers.PagesKeys.Dashboard);
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//                finally
//                {
//                    Loading = false; // Ocultar el mensaje de carga después de completar la operación
//                }
//            }, () => { return true; });
//        }
//        #endregion

//        #region Catalogos
//        public async Task ObtenerOficios()
//        {
//            Oficios = new List<EstadosResponse>();
//            Oficios = await _personaBL.ObtenerOficios();
//        }
//        public async Task ObtenerEstadosUnidos()
//        {
//            EstadosUnidos = new List<EstadosResponse>();
//            EstadosUnidos = await _personaBL.ObtenerListaEstadosUnidos();
//        }
//        public async Task ObtenerMunicipiosChiapas()
//        {
//            MunicipiosResponse = new List<EstadosResponse>();
//            MunicipiosResponse = await _personaBL.ObtenerListaMunicipiosChiapas();
//        }
//        public async Task ObtenerColoniasChiapas(string Nombre)
//        {
//            ColoniasResponse = new List<EstadosResponse>();
//            ColoniasResponse = await _personaBL.ObtenerListaColoniasChiapas(Nombre);
//        }
//        #endregion


//        public bool ValidarCampos()
//        {
//            Errores.Clear(); // Limpiar la lista de errores antes de la validación
//            bool result = true;

//            if (string.IsNullOrEmpty(Entidad.Nombre))
//            {
//                Errores.Add("El campo Nombre es obligatorio");
//                result = false;
//            }
//            if (string.IsNullOrEmpty(Entidad.ApellidoPaterno))
//            {
//                Errores.Add("El campo Apellido Paterno es obligatorio");
//                result = false;
//            }
//            if (Entidad.Genero == 0)
//            {
//                Errores.Add("El campo Género es obligatorio");
//                result = false;
//            }
//            if (Entidad.FechaNacimiento == default)
//            {
//                Errores.Add("El campo Fecha de Nacimiento es obligatorio");
//                result = false;
//            }
//            if (string.IsNullOrEmpty(Entidad.CorreoElectronico))
//            {
//                Errores.Add("El campo Correo Electrónico es obligatorio");
//                result = false;
//            }
//            if (string.IsNullOrEmpty(Entidad.Telefono))
//            {
//                Errores.Add("El campo Teléfono es obligatorio");
//                result = false;
//            }
//            if (string.IsNullOrEmpty(Entidad.FotoPerfil))
//            {
//                Errores.Add("La foto de perfil es obligatoria");
//                result = false;
//            }

            


//            return result;
//        }

//        public bool ValidarCamposResidencia()
//        {
//            Errores.Clear(); // Limpiar la lista de errores antes de la validación
//            bool result = true;

//            if (string.IsNullOrEmpty(EntidadResidencia.EstadoExtranjero))
//            {
//                Errores.Add("El campo Estado en el extranjero es obligatorio");
//                result = false;
//            }
//            if (string.IsNullOrEmpty(EntidadResidencia.LocalidadExtranjero))
//            {
//                Errores.Add("El campo Localidad en el extranjero es obligatorio");
//                result = false;
//            }
//            if (string.IsNullOrEmpty(EntidadResidencia.MunicipioChiapas))
//            {
//                Errores.Add("El campo Municipio en Chiapas es obligatorio");
//                result = false;
//            }
//            if (string.IsNullOrEmpty(EntidadResidencia.ColoniaChiapas))
//            {
//                Errores.Add("El campo Colonia en Chiapas es obligatorio");
//                result = false;
//            }
//            if (string.IsNullOrEmpty(EntidadResidencia.Ocupacion))
//            {
//                Errores.Add("El campo Ocupación es obligatorio");
//                result = false;
//            }

//            return result;
//        }

//        public bool ValidarCamposFamiliar()
//        {
//            Errores.Clear(); // Limpiar la lista de errores antes de la validación
//            bool result = true;
//            if (string.IsNullOrEmpty(EntidadFamilar.Nombre))
//            {
//                Errores.Add("El campo Nombre es obligatorio");
//                result = false;
//            }
//            if (string.IsNullOrEmpty(EntidadFamilar.Apellidos))
//            {
//                Errores.Add("El campo Apellidos es obligatorio");
//                result = false;
//            }

//            if (EntidadFamilar.FechaNacimiento == default)
//            {
//                Errores.Add("El campo Fecha de Nacimiento es obligatorio");
//                result = false;
//            }

//            return result;

//        }

//        public bool ValidarCamposUsuario()
//        {
//            Errores.Clear(); // Limpiar la lista de errores antes de la validación
//            bool result = true;
//            if (string.IsNullOrEmpty(EntidadUsuario.UserName))
//            {
//                Errores.Add("El campo Nombre de Usuario es obligatorio");
//                result = false;
//            }
//            if (string.IsNullOrEmpty(EntidadUsuario.Password))
//            {
//                Errores.Add("El campo Contraseña es obligatorio");
//                result = false;
//            }
//            if (string.IsNullOrEmpty(EntidadUsuario.Nombre))
//            {
//                Errores.Add("El campo Nombre es obligatorio");
//                result = false;
//            }
//            if (EntidadUsuario.IdRol == 0)
//            {
//                Errores.Add("El campo Rol es obligatorio");
//                result = false;
//            }
//            return result;
//        }
//        RelayCommand obtenerUsuariosCommand = null;
//        public RelayCommand ObtenerUsuariosCommand
//        {
//            get => obtenerUsuariosCommand ?? (obtenerUsuariosCommand = new RelayCommand(async () =>
//            {
//                try
//                {
//                    Loading = true;
//                    Usuarios = await _personaBL.ObtenerListaUsuarios();
//                    Loading = false;
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//                finally
//                {
//                    Loading = false;
//                }
//            }, () => { return true; }));
//        }
//    }
//}  

