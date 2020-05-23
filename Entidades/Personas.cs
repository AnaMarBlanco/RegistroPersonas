using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Media.Effects;

namespace Tarea2.Entidades
{
    class Personas
    {
        
       //ahora usaremos [key], que espara decirle al programa cual sera el ID
       [Key]
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public String Direccion { get; set; }
        public DateTime FechaNacimiento  { get; set; }
        //pon los que faltan
        //muy bien
        //mira con un for, escribe for y dale tab 2 veces
        //ahora con un try
        // esos atajos ayudan mucho
        // dale a tools>nuguet package man
        //los paquetes que dije que siempre hay que descargar, te los puedes embotellar xd

    }
}
