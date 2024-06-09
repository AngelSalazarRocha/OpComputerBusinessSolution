using System.Security.Principal;

namespace OPCBusinessSolution.Models
{
    public class MBPedimento
    {
        public string Cliente { get; set; }
        public string ClavePedimento { get; set; }
        public string TipoOperacion { get; set; }
        public string Referencia { get; set; }
        public string Pedimento { get; set; }
        public string Remesa { get; set; }
        public string Caja { get; set; }
        public string Sello { get; set; }
        public string DODA { get; set; }
        public string CPFolios { get; set; }
        public string CruceSOIA { get; set; }
        public string Usuario { get; set; }
        public DateTime TiempoReciboBGTS { get; set; }
        public DateTime TiempoACGConfirmado { get; set; }
        public DateTime FechaCCP { get; set; }
        public DateTime FechaRemesa { get; set; }
    }
}
