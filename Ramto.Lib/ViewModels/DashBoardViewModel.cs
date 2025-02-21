//using Core.MVVM;
//using Ramto.Lib.BL;
//using Ramto.Lib.Enumeraciones;
//using Ramto.Lib.OS.Interfaces;
//using Ramto.Modelos.Custom;
//using Ramto.Modelos.Request;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Ramto.Lib.ViewModels
//{
//    public class DashBoardViewModel : ViewModelBase
//    {
//        public DashBoardViewModel()
//        {
//            _personaBL = new();
//        }

//        private string reportePDF = "";
//        public string ReportePDF { get => reportePDF; set => Set(ref reportePDF, value); }

//        readonly PersonaBL _personaBL;
//        private List<PersonaRequestDTO> personasCapturadas = new List<PersonaRequestDTO>();
//        public List<PersonaRequestDTO> PersonasCapturadas { get => personasCapturadas; set => Set(ref personasCapturadas, value); }

//        private int paginaActual = 1;
//        private const int cantidadRegistros = 10;

//        public int PaginaActual
//        {
//            get => paginaActual;
//            set
//            {
//                paginaActual = value;
//                OnPropertyChanged();
//            }
//        }

//        #region Comandos
//        RelayCommand registrarPersonaCommand = null;
//        public RelayCommand RegistrarPersonaCommand
//        {
//            get => registrarPersonaCommand ??= new RelayCommand(async () =>
//            {
//                try
//                {
//                    await DependencyService.Get<INavigationService>().NavigateTo(Helpers.PagesKeys.RegistroPersona);
//                }
//                catch (Exception ex)
//                {
//                    // Manejo de excepciones
//                }
//                finally
//                {
//                    Loading = false;
//                }
//            }, () => { return true; });
//        }

//        RelayCommand<PersonaRequestDTO> imprimirReportePersonaCommand = null;
//        public RelayCommand<PersonaRequestDTO> ImprimirReportePersonaCommand
//        {
//            get => imprimirReportePersonaCommand ??= new RelayCommand<PersonaRequestDTO>(async (persona) =>
//            {
//                try
//                {
//                    ReportePDF = await _personaBL.ReporteCapturaPersona(persona.IdPersona);
//                }
//                catch (Exception ex)
//                {
//                    // Manejo de excepciones
//                }
//                finally
//                {
//                    Loading = false;
//                }
//            }, (persona) => { return true; });
//        }

//        RelayCommand siguienteCommand = null;
//        public RelayCommand SiguienteCommand
//        {
//            get => siguienteCommand ??= new RelayCommand(async () =>
//            {
//                //validar el numero de clicks en el boton siguiente
//                if(PaginaActual <= (cantidadRegistros/10) + 1)
//                {
//                    PaginaActual++;
//                    await ObtenerListas();
//                }
//                else
//                {
//                    PaginaActual = 1;
//                    await ObtenerListas();
//                }

//                //PaginaActual++;
//                //await ObtenerListas();
//            }, () => !Loading && !Processing);
//        }

//        RelayCommand anteriorCommand = null;
//        public RelayCommand AnteriorCommand
//        {
//            get => anteriorCommand ??= new RelayCommand(async () =>
//            {
//                if (PaginaActual > 1)
//                {
//                    PaginaActual--;
//                    await ObtenerListas();
//                }
//            }, () => !Loading && !Processing && PaginaActual > 1);
//        }
//        #endregion

//        #region Lista de Personas Capturadas
//        public async Task ObtenerListas()
//        {
//            //validar el numero de clicks en el boton siguiente
            
            
       
//            PersonasCapturadas = await _personaBL.ObtenerListaPersonasCapturadas(PaginaActual, cantidadRegistros);
//        }
//        #endregion
//        private string base64Pdf;
//        public string Base64Pdf { get => base64Pdf; set => Set(ref base64Pdf, value); }

//        RelayCommand generarExcel;
//        public RelayCommand GenerarExcel => generarExcel ??= new RelayCommand(async () =>
//        {
//            //Console.WriteLine("Ejecutando GenerarChequesCommand"); // Mensaje de depuración


//            Loading = true;
//            //Console.WriteLine("Contenido del archivo cargado correctamente en el ViewModel.");
//            try
//            {
//                //Envía el contenido del archivo al servidor para que genere el PDF
//                var response = await _personaBL.Exportar();

//                if (!string.IsNullOrEmpty(response))
//                {
//                    Base64Pdf = response;
//                }
//                else
//                {
//                    //Console.WriteLine("Error: El PDF no se generó correctamente en el servidor.");

//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                Loading = false;
//            }
//            Loading = false;

//        }, () => { return true; });
//    }
//}
