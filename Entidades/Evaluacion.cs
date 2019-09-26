using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public class Evaluacion
    {
        [Key]
        public int EvaluacionId { get; set; }
        public String Nombre { get; set; }
        public String Categoria { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Logrado { get; set; }
        public decimal Perdido { get; set; }

        public Evaluacion(int evaluacionId, string nombre, string categoria, DateTime fecha, decimal valor, decimal logrado, decimal perdido)
        {
            EvaluacionId = evaluacionId;
            Nombre = nombre;
            Categoria = categoria;
            Fecha = fecha;
            Valor = valor;
            Logrado = logrado;
            Perdido = perdido;
        }

        public Evaluacion()
        {
            EvaluacionId = 0;
            Nombre = String.Empty;
            Categoria = String.Empty;
            Fecha = DateTime.Now;
            Valor = 0;
            Logrado = 0;
            Perdido = 0;
        }
    }
}
