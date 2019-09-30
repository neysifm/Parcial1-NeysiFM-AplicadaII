using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    [Serializable]
    public class Evaluacion
    {
        [Key]
        public int EvaluacionID { get; set; }
        public DateTime Fecha { get; set; }
        public string Estudiante { get; set; }
        public decimal TotalPerdido { get; set; }
        public virtual List<DetalleEvaluacion> DetalleEvaluacion { get; set; }

        public Evaluacion(int evaluacionID, DateTime fecha, string estudiante, decimal totalPerdido)
        {
            EvaluacionID = evaluacionID;
            Fecha = fecha;
            Estudiante = estudiante ?? throw new ArgumentNullException(nameof(estudiante));
            TotalPerdido = totalPerdido;
            DetalleEvaluacion = new List<DetalleEvaluacion>();
        }

        public Evaluacion()
        {
            EvaluacionID = 0;
            Fecha = DateTime.Now;
            Estudiante = string.Empty;
            TotalPerdido = 0;
            DetalleEvaluacion = new List<DetalleEvaluacion>();
        }
    }
}
