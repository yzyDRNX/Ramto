
namespace Ramto.Modelos.Custom
{
    public class ApiValues
    {
        private string urlWebApi;

        public string UrlWebApi
        {
            get { return $"{urlWebApi}/api/"; }
            set { urlWebApi = value; }
        }
        public string WebApiBaseUrl
        {
            get { return urlWebApi; }
        }

        public string MensajeErrorApi { get; set; }

        public string URLSAC { get; set; }
    }
}
