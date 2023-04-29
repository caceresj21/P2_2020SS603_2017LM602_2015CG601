using System.ComponentModel.DataAnnotations;

namespace P2_2020SS603_2017LM602_2015CG601.Models
{
    public class Generos
    {

        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}
