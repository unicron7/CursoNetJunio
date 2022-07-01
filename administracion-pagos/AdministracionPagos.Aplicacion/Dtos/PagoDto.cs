namespace AdministracionPagos.Aplicacion.Dtos
{
    public class PagoDto
    {
        public int Id { get; set; }
        public string NumeroComprobante { get; set; }
        public DateTime FechaPago { get; set; }

        public string Cliente { get; set; }
    }
}