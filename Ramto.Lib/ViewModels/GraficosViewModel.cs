//using Core.MVVM;


//namespace Ramto.Lib.ViewModels
//{
//    public class GraficoGeneroViewModel : ViewModelBase
//    {
//        readonly BL.PersonaBL personaBL;

//        public async Task ExportarGenero()
//        {
         
//        }
//        public GraficoGeneroViewModel()
//        {
//            personaBL = new BL.PersonaBL();
//        }
//        public List<string> Labels { get; set; }
//        public List<string> Data { get; set; }
//        #region Generos
//        public async Task ObtenerGeneros()
//        {
//            Labels = new List<string>();
//            Data = new List<string>();
//            var generoResult = await personaBL.ObtenerGenerosGrafica();

//            foreach (var item in generoResult)
//            {
//                Labels.Add(item.Genero);
//                Data.Add(item.Cantidad.ToString());
//            }


//        }
//        #endregion


//    }

//    public class GraficoEdadViewModel : ViewModelBase
//    {
//        readonly BL.PersonaBL personaBL;
//        public GraficoEdadViewModel()
//        {
//            personaBL = new BL.PersonaBL();
//        }
//        public List<string> Labels { get; set; }
//        public List<string> Data { get; set; }
//        public async Task ExportarEdad()
//        {
         
//        }
//        public async Task ObtenerEdades()
//        {
//            Labels = new List<string>();
//            Data = new List<string>();
//            var edadResult = await personaBL.ObtenerGruposEdadGrafica();
//            foreach (var item in edadResult)
//            {
//                Labels.Add(item.RangoEdad);
//                Data.Add(item.Cantidad.ToString());
//            }
//        }
//    }

//    public class GraficoMenoresViewModel : ViewModelBase
//    {
//        readonly BL.PersonaBL personaBL;

//        public GraficoMenoresViewModel()
//        {
//            personaBL = new BL.PersonaBL();
//        }
//        public async Task ExportarEdad()
//        {
           
//        }
//        public List<string> Labels { get; set; }
//        public List<string> Data { get; set; }

//        public async Task ObtenerMenoresEdad()
//        {
//            Labels = new List<string>();
//            Data = new List<string>();
//            int edadMin = 0; // Define el valor mínimo de edad
//            int edadMax = 18; // Define el valor máximo de edad
//            var menoresEdadResult = await personaBL.ObtenerMenoresGrafica(edadMin, edadMax);

//            if (menoresEdadResult != null)
//            {
//                foreach (var item in menoresEdadResult)
//                {
//                    Labels.Add(item.Edad.ToString());
//                    Data.Add(item.Cantidad.ToString());
//                }
//            }
//            else
//            {
//                Console.Error.WriteLine("No se obtuvieron datos de menores de edad.");
//            }
//            Console.WriteLine($"Labels: {string.Join(", ", Labels)}");
//            Console.WriteLine($"Data: {string.Join(", ", Data)}");
//        }

//        public async Task ObtenerMenoresGrafica(int edadMin, int edadMax)
//        {
//            var menores = await personaBL.ObtenerMenoresGrafica(edadMin, edadMax);
//            Labels = menores.Select(m => m.Edad.ToString()).ToList();
//            Data = menores.Select(m => m.Cantidad.ToString()).ToList();

//            // Verificación adicional
//            if (Data.Any(d => int.Parse(d) < 0))
//            {
//                Console.Error.WriteLine("Se encontraron valores negativos en los datos.");
//            }
//        }


//    }


//    public class GraficoOficioViewModel : ViewModelBase
//    {
//        private readonly BL.PersonaBL personaBL;

//        public GraficoOficioViewModel()
//        {
//            personaBL = new BL.PersonaBL();
//        }
//        private string base64Pdf;
//        public string Base64Pdf { get => base64Pdf; set => Set(ref base64Pdf, value); }
        
//        public List<string> Labels { get; set; } = new List<string>();
//        public List<int> Data { get; set; } = new List<int>();
//        public int SelectedOficioId { get; set; }
//        public string Mensaje { get; set; }
//        public async Task ExportarOficio()
//        {
          
//        }
//        public async Task ObtenerDatosOficio()
//        {
//            var response = await personaBL.ObtenerOficiosGrafica(SelectedOficioId);
//            Labels.Clear();
//            Data.Clear();
//            Mensaje = string.Empty;
//            if (response != null && response.Any())
//            {
//                foreach (var item in response)
//                {
//                    Labels.Add(item.Oficio);
//                    Data.Add(item.Cantidad);
//                }

//                if (!Data.Any())
//                {
//                    Mensaje = "No hay datos disponibles para el estado seleccionado.";
//                }
//            }
//            else
//            {
//                Mensaje = "No hay datos disponibles para el estado seleccionado.";
//            }
//        }
//        RelayCommand generarExcelGraficaOficio;
//        public RelayCommand GenerarExcelGraficaOficio => generarExcelGraficaOficio ??= new RelayCommand(async () =>
//        {
//            //Console.WriteLine("Ejecutando GenerarChequesCommand"); // Mensaje de depuración


//            Loading = true;
//            //Console.WriteLine("Contenido del archivo cargado correctamente en el ViewModel.");
//            try
//            {
//                //Envía el contenido del archivo al servidor para que genere el PDF
//                var response = await personaBL.ReporteExcel(SelectedOficioId);

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

    
//    public class GraficoExtranjeroViewModel : ViewModelBase
//    {
//        readonly BL.PersonaBL personaBL;

//        public GraficoExtranjeroViewModel()
//        {
//            personaBL = new BL.PersonaBL();
//        }

//        public List<string> Labels { get; set; } = new List<string>();
//        public List<int> Data { get; set; } = new List<int>();
//        public string Mensaje { get; set; }
//        public int SelectedEstadoId { get; set; } // Agregar esta propiedad

//        public async Task ExportarExtranjero()
//        {
         
//        }
//        public async Task ObtenerDatosExtranjero()
//        {
//            var response = await personaBL.ObtenerExtranjeroGrafica(SelectedEstadoId);
//            Labels.Clear();
//            Data.Clear();
//            Mensaje = string.Empty;

//            if (response != null && response.Any())
//            {
//                foreach (var item in response)
//                {
//                    Labels.Add(item.Estado);
//                    Data.Add(item.Cantidad);
//                }

//                if (!Data.Any())
//                {
//                    Mensaje = "No hay datos disponibles para el estado seleccionado.";
//                }
//            }
//            else
//            {
//                Mensaje = "No hay datos disponibles para el estado seleccionado.";
//            }
//        }
//    }
    

//}



