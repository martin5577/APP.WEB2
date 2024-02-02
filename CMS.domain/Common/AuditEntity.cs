namespace CMS.domain.Common
{
    public class AuditEntity : BaseEntity
    {
        public DateTime CreadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ActualizadoPor { get; set; }
    }
}
