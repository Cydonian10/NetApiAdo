using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Tareas.Util
{
    public class Parametro
    {

        public Parametro(string nombre, string valor)
        {
            Nombre = nombre;
            Valor = valor;
        }

        public string Nombre { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;
    }
}