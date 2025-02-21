using Ramto.Lib.Helpers;

namespace Ramto.OS
{
    public class Routes
    {
        #region Propiedaes
        private static string Ruta = string.Empty;
        #endregion

        #region Métodos
        public static string ObtenerRuta(PagesKeys page)
        {
            return page switch
            {
    
                //PagesKeys.RecuperarPassword => "/RecuperarPassword",
                //PagesKeys.DetalleBajas => "/DetalleBajas",
                //PagesKeys.DetalleBeneficiario => "/DetalleBeneficiario",
                //PagesKeys.DetalleCheques => "/DetalleCheques",
                //PagesKeys.DetalleDatos1 => "/DetalleDatos1",
                //PagesKeys.DetalleDatos2 => "/DetalleDatos2",
                //PagesKeys.DetalleEmpleo => "/DetalleEmpleo",
                //PagesKeys.DetalleObito => "/DetalleObito",
                //PagesKeys.DetallePago => "/DetallePago",
                //PagesKeys.DetallePrejubilado => "/DetallePrejubilado",
                //PagesKeys.DetallePrestamo => "/DetallePrestamo",
                //PagesKeys.DetallePrestamo2 => "/DetallePrestamo2",
                //PagesKeys.EditarBajas => "/EditarBajas",
                //PagesKeys.EditarBeneficiario => "/EditarBeneficiario",
                //PagesKeys.EditarDatos1 => "/EditarDatos1",
                //PagesKeys.EditarDatos2 => "/EditarDatos2",
                //PagesKeys.EditarEmpleo => "/EditarEmpleo",
                //PagesKeys.EditarObito => "/EditarObito",
                //PagesKeys.EditarPago => "/EditarPago",
                //PagesKeys.EditarPrejubilado => "/EditarPrejubilado",
                //PagesKeys.EditarPrestamo => "/EditarPrestamo",
                //PagesKeys.EditarPrestamo2 => "/EditarPrestamo2",
                //PagesKeys.Fondo => "/Fondo",
                //PagesKeys.Menu => "/Menu",
                //PagesKeys.NuevoPago => "/NuevoPago",
                //PagesKeys.NuevoPrestamo => "/NuevoPrestamo",
                //PagesKeys.NuevoPrestamo2 => "/NuevoPrestamo2",
                //PagesKeys.NuevoRegistroP => "/NuevoRegistroP",
                //PagesKeys.NuevoRegistroP2 => "/NuevoRegistroP2",
                //PagesKeys.Pagos => "/Pagos",
                //PagesKeys.VisualizarPrestamo => "/VisualizarPrestamo",
                //PagesKeys.ActCheques => "/ActCheques",
                //PagesKeys.ActLiquido => "/ActLiquido",
                //PagesKeys.ChequesDifunciones => "/ChequesDifunciones",
                //PagesKeys.Etapas => "/Etapas",
                //PagesKeys.PdfCheques => "/PdfCheques",
                //PagesKeys.ReferenciasPrestamos => "/ReferenciasPrestamos",
                //PagesKeys.CajaAhorro => "/CajaAhorro",
                //PagesKeys.Fraudes => "/Fraudes",
                //PagesKeys.Estatus => "/Estatus",
                //PagesKeys.Becas => "/Becas",
                //PagesKeys.Generales => "/Generales",
                //PagesKeys.CambioContrasena => "/CambioContrasena",
                //PagesKeys.AgregarEmpleo => "/AgregarEmpleo",
                //PagesKeys.Ahorro => "/Ahorro",
                //PagesKeys.VisualizarDocumento => $"/VisualizarDocumento",
                //PagesKeys.Jubilados => "/Jubilados",
                //PagesKeys.EtapasJubilados => "/EtapasJubilados",
                //PagesKeys.PrestamoJubilado => $"/PrestamoJubilados",
                //PagesKeys.AgregarAdhesionJubilados => $"/AgregarAdhesionJubilados",
                //PagesKeys.PagosJubilado => $"/PagoJubilado",
                //PagesKeys.EditarAdhesionJubilados => $"/EditarAdhesionJubilados",
                //PagesKeys.GeneralesJubilados => $"/GeneralesJubilados",

                _ => string.Empty
            };
        }

        /// <summary>
        /// Retorna el URL correspondiente contatenado con el parametro enviado, esto en el caso del usuario tener permisos
        /// </summary>
        /// <param name="page"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public static string ObtenerRuta(PagesKeys page, string parametro, string parametro2 = "")
        {
            //string Ruta = RetornarUrlConBaseAlRolySubRol(page);
            //Ruta = $"{Ruta}/{parametro}";
            //return Ruta;
            return page switch
            {
                //
                PagesKeys.Dashboard => $"/dash",
                //PagesKeys.DetalleBajas => $"/DetalleBajas/{parametro}",
                //PagesKeys.DetalleBeneficiario => $"/DetalleBeneficiario/{parametro}",
                //PagesKeys.DetalleCheques => $"/DetalleCheques/{parametro}/{parametro2}",
                //PagesKeys.DetalleDatos1 => $"/DetalleDatos1/{parametro}",
                //PagesKeys.DetalleDatos2 => $"/DetalleDatos2/{parametro}",
                //PagesKeys.DetalleEmpleo => $"/DetalleEmpleo/{parametro}",
                //PagesKeys.DetalleObito => $"/DetalleObito/{parametro}",
                //PagesKeys.DetallePago => $"/DetallePago/{parametro}/{parametro2}",
                //PagesKeys.DetallePrejubilado => $"/DetallePrejubilado/{parametro}",
                //PagesKeys.DetallePrestamo => $"/DetallePrestamo/{parametro}/{parametro2}",
                //PagesKeys.DetallePrestamo2 => $"/DetallePrestamo2/{parametro}/{parametro2}",
                //PagesKeys.EditarBajas => $"/EditarBajas/{parametro}",
                //PagesKeys.EditarBeneficiario => $"/EditarBeneficiario/{parametro}",
                //PagesKeys.EditarDatos1 => $"/EditarDatos1/{parametro}",
                //PagesKeys.EditarDatos2 => $"/EditarDatos2/{parametro}",
                //PagesKeys.EditarEmpleo => $"/EditarEmpleo/{parametro}",
                //PagesKeys.EditarObito => $"/EditarObito/{parametro}",
                //PagesKeys.EditarPago => $"/EditarPago/{parametro}/{parametro2}",
                //PagesKeys.EditarPrejubilado => $"/EditarPrejubilado/{parametro}",
                //PagesKeys.EditarPrestamo => $"/EditarPrestamo/{parametro}/{parametro2}",
                //PagesKeys.EditarPrestamo2 => $"/EditarPrestamo2/{parametro}/{parametro2}",
                //PagesKeys.Fondo => $"/Fondo/{parametro}",
                //PagesKeys.Menu => $"/Menu/{parametro}",
                //PagesKeys.NuevoPago => $"/NuevoPago/{parametro}/{parametro2}",
                //PagesKeys.NuevoPrestamo => $"/NuevoPrestamo/{parametro}",
                //PagesKeys.NuevoPrestamo2 => $"/NuevoPrestamo2/{parametro}",
                //PagesKeys.NuevoRegistroP => $"/NuevoRegistroP/{parametro}",
                //PagesKeys.NuevoRegistroP2 => $"/NuevoRegistroP2/{parametro}",
                //PagesKeys.Pagos => $"/Pagos/{parametro}/{parametro2}",
                //PagesKeys.VisualizarPrestamo => $"/VisualizarPrestamo/{parametro}",
                //PagesKeys.ActCheques => $"/ActCheques/{parametro}",
                //PagesKeys.ActLiquido => $"/ActLiquido/{parametro}",
                //PagesKeys.ChequesDifunciones => $"/ChequesDifunciones/{parametro}",
                //PagesKeys.Etapas => $"/Etapas/{parametro}",
                //PagesKeys.PdfCheques => $"/PdfCheques/{parametro}",
                //PagesKeys.ReferenciasPrestamos => $"/ReferenciasPrestamos/{parametro}",
                //PagesKeys.CajaAhorro => $"/CajaAhorro/{parametro}",
                //PagesKeys.Fraudes => $"/Fraudes/{parametro}",
                //PagesKeys.Estatus => $"/Estatus/{parametro}",
                //PagesKeys.Becas => $"/Becas/{parametro}",
                //PagesKeys.Generales => $"/Generales/{parametro}",
                //PagesKeys.CambioContrasena => $"/CambioContrasena/{parametro}",
                //PagesKeys.AgregarEmpleo => $"/AgregarEmpleo/{parametro}",
                //PagesKeys.Ahorro => $"/Ahorro/{parametro}",
                //PagesKeys.VisualizarDocumento => $"/VisualizarDocumento/{parametro}",
                //PagesKeys.Jubilados => $"/Jubilados/{parametro}",
                //PagesKeys.EtapasJubilados => $"/EtapasJubilados/{parametro}",
                //PagesKeys.PrestamoJubilado => $"/PrestamoJubilados/{parametro}",
                //PagesKeys.AgregarAdhesionJubilados => $"/AgregarAdhesionJubilados/{parametro}",
                //PagesKeys.ChequesJubilado => $"/ChequeJubilado/{parametro}/{parametro2}",
                //PagesKeys.PagosJubilado => $"/PagoJubilado/{parametro}/{parametro2}",
                //PagesKeys.EditarAdhesionJubilados => $"/EditarAdhesionJubilados/{parametro}",
                //_ => string.Empty
            };
        }


        private static string ObtenerRutasSinLogueo(PagesKeys page)
        {
            return page switch
            {
                //PagesKeys.Login => "/",

                _ => string.Empty
            };
        }


        #region  Rutas de administradores
        /// <summary>
        /// Recupera las rutas permitidas para los usuarios de tipo administrador
        /// </summary>
        /// <param name="page"></param>
        /// <returns>String con la ruta a la que se navega.
        /// Si el usuario no tiene permisos para la ruta que quiere acceder</returns>
        private static string ObtenerRutasAdministradorRoot(PagesKeys page)
        {
            return page switch
            {
                PagesKeys.Login => "/AdministradorRoot/Dashboard",




                _ => string.Empty
            };
        }


        #endregion

        #endregion
    }
}
