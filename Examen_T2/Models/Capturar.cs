using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T2.Models
{
    public class Capturar
    {
        public int Id { set; get; }
        public int IdUsuario { set; get; }
        public int IdPokemon { set; get; }
        public DateTime FechaCaptura { set; get; }
        public Pokemon Pokemon { set; get; }

    }
}
