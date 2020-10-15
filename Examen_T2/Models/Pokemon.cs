using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T2.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int TipoId { get; set; }
        public string Imagen { get; set; }
        public Elemento Elemento { get; set; }
        public List<Capturar> Capturas { get; set; }
    }
}
