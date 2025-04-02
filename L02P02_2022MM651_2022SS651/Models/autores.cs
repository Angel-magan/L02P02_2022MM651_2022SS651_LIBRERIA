using System.ComponentModel.DataAnnotations;

namespace L02P02_2022MM651_2022SS651.Models
{
    public class autores
    {
        [Key]
        public int id { get; set; }
        public string autor { get; set; }
    }
}
