//using Blazored.Modal.Services;
//using Blazored.Modal;
//using Ramto.OS.Interfaces;
//using Ramto.Lib.Enumeraciones;

//namespace Ramto.OS
//{
//    public class ModalesService : IModalesService
//    {


//        /// <summary>
//        /// Opciones visuales que tienen los modales
//        /// </summary>

//        readonly ModalOptions estilosDelModal = new ModalOptions
//        {
//            Position = ModalPosition.Middle,

//            AnimationType = ModalAnimationType.None,
//            Class = "my-custom-modal-class",

//            HideCloseButton = true,
//            DisableBackgroundCancel = true,
//            HideHeader = true
//        };



//        private Stack<IModalReference> Modales = new Stack<IModalReference>();
//        /// <summary>
//        /// Instancia del servicio de los modales
//        /// </summary>
//        internal IModalService ModalService { get; set; }
//        public Task PopModal()
//        {
//            IModalReference modalActual = Modales.Peek();
//            modalActual.Close();
//            Modales.Pop();
//            return Task.CompletedTask;
//        }

//        public Task PopToRootModal()
//        {
//            foreach (IModalReference modal in this.Modales)
//            {
//                modal.Close();
//            }
//            this.Modales.Clear();
//            return Task.CompletedTask;
//        }
//        public Task PushModal(ModalKeys modalKeys)
//        {
//            //switch (modalKeys)
//            //{
//            //    case ModalKeys.ErrorModal:
//            //        // AddToStackModal(this.ModalService.Show<MensajeAlerta>());
//            //        break;
//            //    case ModalKeys.Cargando:
//            //        // AddToStackModal(this.ModalService.Show<CargandoModal>());
//            //        break;
//            //    case ModalKeys.MensajeExitoso:
//            //        //AddToStackModal(this.ModalService.Show<MensajeExitoso>());
//            //        break;
//            //    case ModalKeys.AgregarMaestroModal:
//            //        AddToStackModal(this.ModalService.Show<AgregarMaestroModal>());
//            //        break;
//            //    case ModalKeys.AgregarAdhesionModal:
//            //        AddToStackModal(this.ModalService.Show<AgregarAdhesionModal>());
//            //        break;
//            //}
//            return Task.CompletedTask;

//        }

//        public Task PushModal<T>(ModalKeys modalKeys, T parametro)
//        {
//            throw new NotImplementedException();
//        }

//        public Task PushModal(ModalKeys modalKeys, params object[] parametros)
//        {
//            ModalParameters keyValue = new ModalParameters();

//            //switch (modalKeys)
//            //{
//            //    case ModalKeys.MensajePersonalizado:
//            //        keyValue.Add("Exito", parametros[0]);
//            //        keyValue.Add("Mensaje", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<MensajePersonalizado>(string.Empty, keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.BeneficiarioModal:
//            //        keyValue.Add("Beneficiario", parametros[1]);
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("EsNuevo", parametros[2]);
//            //        AddToStackModal(this.ModalService.Show<BeneficiarioModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.CalculoPrestamoModal:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdMaestro", parametros[1]);
//            //        keyValue.Add("EsJubilado", parametros[2]);
//            //        AddToStackModal(this.ModalService.Show<CalculaPrestamoModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.CatalogoPrestamoModal:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdMaestro", parametros[1]);
//            //        keyValue.Add("EntidadRequest", parametros[2]);
//            //        AddToStackModal(this.ModalService.Show<CatalogoPrestamoModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.EditarEtapaModal:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        keyValue.Add("IdEtapa", parametros[1]); // Pasar el IdEtapa
//            //        AddToStackModal(this.ModalService.Show<EditarEtapaModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.InstruccionEtapaModal:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        keyValue.Add("IdEtapa", parametros[1]); // Pasar el IdEtapa
//            //        keyValue.Add("Estatus", parametros[2]); // Pasar el estatus actual de la etapa
//            //        AddToStackModal(this.ModalService.Show<InstruccionEtapaModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.AgregarEtapaModal:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        //keyValue.Add("IdMaestro", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<AgregarEtapaModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.AgregarChequeModal:
//            //        keyValue.Add("PrestamoEtapa", parametros[0]);
//            //        keyValue.Add("TituloModal", parametros[1]);
//            //        keyValue.Add("IdEtapa", parametros[2]);
//            //        AddToStackModal(this.ModalService.Show<AgregarChequeModal>(parametros[1].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.AgregarAhorroModal:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        keyValue.Add("IdEmpleo", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<AgregarAhorroModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.DetalleAhorroModal:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        keyValue.Add("IdAhorro", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<DetalleAhorroModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.EditarAhorroModal:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        keyValue.Add("IdAhorro", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<EditarAhorroModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.EliminarAhorroModal:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        keyValue.Add("IdAhorro", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<EliminarAhorroModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.GenerarReferenciaBanco:
//            //        keyValue.Add("TituloModal", parametros[1]);

//            //        AddToStackModal(this.ModalService.Show<ReferenciasPagosBancoModal>(parametros[1].ToString(), keyValue, estilosDelModal));
//            //        break;

//            //    case ModalKeys.GenerarReporteFiniquitoModal:
//            //        keyValue.Add("TituloModal", parametros[1]);

//            //        AddToStackModal(this.ModalService.Show<GenerarReporteFiniquitoModal>(parametros[1].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.AsignarChequeBeneficiario:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdBeneficiario", parametros[1]);
//            //        keyValue.Add("IdMaestro", parametros[2]);
//            //        keyValue.Add("TipoCheque", parametros[3]);
//            //        AddToStackModal(this.ModalService.Show<BeneficiarioChequeModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.AdhesionJubilados:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        AddToStackModal(this.ModalService.Show<AdhesionJubilados>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.DetalleAdhesion:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdMaestro", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<DetalleAdhesion>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.EditarAdhesionJubilado:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdMaestro", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<EditarAdhesionJubilado>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.BeneficiarioJubilados:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdMaestro", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<BeneficiarioJubilados>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.JubiladosDocumentos:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdMaestro", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<JubiladosDocumentos>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.PrestamoJubilados:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        AddToStackModal(this.ModalService.Show<PrestamoJubilados>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.AportacionesJubilados:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdMaestro", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<AportacionesJubilados>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.ClaveAutorizacionModal:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdMaestro", parametros[1]);
//            //        keyValue.Add("CorreoElectronico", parametros[2]);
//            //        AddToStackModal(this.ModalService.Show<ClaveAutorizacionModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.DetallePrestamoJubiladoModal:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdMaestro", parametros[1]);
//            //        keyValue.Add("IdPrestamo", parametros[2]);
//            //        keyValue.Add("EsNuevo", parametros[3]);
//            //        keyValue.Add("EntidadRequest", parametros[4]);
//            //        AddToStackModal(this.ModalService.Show<DetallePrestamoJubilado>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.AgregarEtapaJubiladoModal:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        //keyValue.Add("IdMaestro", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<AgregarEtapaJubiladoModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.EditarEtapaJubiladosModal:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        keyValue.Add("IdEtapa", parametros[1]); // Pasar el IdEtapa
//            //        AddToStackModal(this.ModalService.Show<EditarEtapaJubiladosModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.DetallePagoJubiladoModal:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdPrestamo", parametros[1]);
//            //        keyValue.Add("IdPago", parametros[2]);
//            //        keyValue.Add("TipoAccion", parametros[3]);
//            //        AddToStackModal(this.ModalService.Show<DetallePagoJubilado>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.DetalleChequeJubiladoModal:
//            //        keyValue.Add("TituloModal", parametros[0]);
//            //        keyValue.Add("IdPrestamo", parametros[1]);
//            //        keyValue.Add("TipoAccion", parametros[2]);
//            //        AddToStackModal(this.ModalService.Show<DetalleChequeJubilado>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.InstruccionJubilacionesEtapaModal:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        keyValue.Add("IdEtapa", parametros[1]); // Pasar el IdEtapa
//            //        AddToStackModal(this.ModalService.Show<InstruccionJubilacionesEtapaModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;

//            //    case ModalKeys.GenerarReferenciaJubilado:
//            //        keyValue.Add("TituloModal", parametros[1]); // Pasar el título del modal
//            //        AddToStackModal(this.ModalService.Show<ReferenciaPagosJubiladosModal>(parametros[1].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.GenerarReferenciaJubiladoPrestamo:
//            //        keyValue.Add("TituloModal", parametros[1]); // Pasar el título del modal
//            //        AddToStackModal(this.ModalService.Show<ReferenciaPagoJubiladoPrestamo>(parametros[1].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.EliminarPagoModal:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        keyValue.Add("IdPago", parametros[1]);
//            //        AddToStackModal(this.ModalService.Show<EliminarPagoModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.AgregarDelegacion:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        AddToStackModal(this.ModalService.Show<AgregarDelegacionModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.AgregarDelegacion2:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        AddToStackModal(this.ModalService.Show<AgregarDelegacionModal2>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.BajasJubilados:
//            //        keyValue.Add("TituloModal", parametros[1]); // Pasar el título del modal
//            //        AddToStackModal(this.ModalService.Show<BajasJubilados>(parametros[1].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.AgregarCentroE:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        AddToStackModal(this.ModalService.Show<AgregarCentroEditar>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.AgregarCentroA:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        AddToStackModal(this.ModalService.Show<AgregarCentroAgregar>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //    case ModalKeys.CancelarPrestamo:
//            //        keyValue.Add("TituloModal", parametros[0]); // Pasar el título del modal
//            //        keyValue.Add("IdPrestamo", parametros[1]); // Pasar el IdPrestamo                   
//            //        AddToStackModal(this.ModalService.Show<CancelarPrestamoModal>(parametros[0].ToString(), keyValue, estilosDelModal));
//            //        break;
//            //}
//            return Task.CompletedTask;
//        }

//        public Task PushAceptarModalAutoHide(string mensajeAdicional, double time = 2, string encadezado = "¡Éxito!")
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<bool> PushAdverteciaModal(string mensajeAdicional, string encadezado = "¡Advertencia!", string mensajeSi = "Sí", string mensajeNo = "No")
//        {
//            //ModalAdvertenciaModelo dataMensaje = new ModalAdvertenciaModelo
//            //{
//            //    MensajePrincipal = encadezado,
//            //    MensajeAdicional = mensajeAdicional,
//            //    MensajeNo = mensajeNo,
//            //    MensajeSi = mensajeSi
//            //};
//            //var viewModelInstance = Locator.GetViewModel<AdvertenciaViewModel>();
//            //viewModelInstance.DataMensaje = dataMensaje;
//            //AddToStackModal(this.ModalService.Show<AdvertenciaConfirmacionModal>(string.Empty, estilosDelModal));
//            //var response = await viewModelInstance.GetResult();
//            //Locator.DestoyViewModel<AdvertenciaViewModel>();
//            return await Task.FromResult(true);
//        }

//        public Task PushErrorModal(string mensajeAdicional, string encadezado = "¡Error!", string mensajeAceptar = "Aceptar")
//        {
//        //    ErrorModelo dataMensaje = new ErrorModelo
//        //    {
//        //        MensajePrincipal = encadezado,
//        //        MensajeAdicional = mensajeAdicional,
//        //        MensajeSi = mensajeAceptar
//        //    };
//        //    Locator.GetViewModel<MensajeAlertaViewModel>().DataMensaje = dataMensaje;
//        //    AddToStackModal(this.ModalService.Show<MensajeAlerta>(string.Empty, estilosDelModal));
//         return Task.CompletedTask;
//        }


//        public Task<bool> PushReturningDataModal(ModalKeys modalKeys)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> PushReturningDataModal<T>(ModalKeys modalKeys, T parametro)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> PushReturningDataModal(ModalKeys modalKeys, params object[] param)
//        {
//            throw new NotImplementedException();
//        }
//        /// <summary>
//        /// Agrega al modal de instancias de modal el ultimo modal mandado a llamar
//        /// </summary>
//        /// <param name="modalReference"></param>
//        private void AddToStackModal(IModalReference modalReference)
//        {
//            this.Modales.Push(modalReference);
//        }
//        public Task AlertPopUp(ModalKeys modalKeys)
//        {
//            switch (modalKeys)
//            {
//                //case ModalKeys.ErrorModal:
//                //    // AddToStackModal(this.ModalService.Show<MensajeAlerta>());
//                //    break;
//                //case ModalKeys.Cargando:
//                //    AddToStackModal(this.ModalService.Show<CargandoModal>(string.Empty, estilosDelModal));
//                //    break;
//                //case ModalKeys.MensajeExitoso:
//                //    AddToStackModal(this.ModalService.Show<MensajeExitoso>(string.Empty, estilosDelModal));
//                //    break;

//            }
//            return Task.CompletedTask;

//        }
//    }
//}
