using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLibraryApi.Models
{
    public class Game
    {
        // Använder string som Id eftersom det stod i Api specifikationen. 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Identifier { get; set; }
        public string? Name { get; set; }
        public string? Company { get; set; }
        public double Price { get; set; }
    }
}
