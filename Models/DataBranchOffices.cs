namespace Backend.Models
{
    public class DataBranchOffices
    {
        public int? Id { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public string? Abreviatura { get; set; }
        public string? IdMoneda { get; set; }
        public string? Moneda { get; set; }
        public string Codigo { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
