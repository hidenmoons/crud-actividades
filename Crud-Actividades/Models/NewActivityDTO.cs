namespace Crud_Actividades.Models
{
    public class NewActivityDTO
    {
        public int PropertyId { get; set; }

        public DateTime Schedule { get; set; }

        public string Title { get; set; } = null!;

        public string Status { get; set; } = null!;
    }
}
