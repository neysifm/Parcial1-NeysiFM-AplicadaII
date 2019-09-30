using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class DetalleEvaluacion
    {
        [Key]
        public int DetalleID { get; set; }
        public int EvaluacionID { get; set; }
        [ForeignKey("EvaluacionID")]
        public virtual Evaluacion Evaluacion { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public decimal Logrado { get; set; }
        public decimal Perdido { get; set; }

        public DetalleEvaluacion(int detalleID, int evaluacionID, string categoria, decimal valor, decimal logrado, decimal perdido)
        {
            DetalleID = detalleID;
            EvaluacionID = evaluacionID;
            Categoria = categoria ?? throw new ArgumentNullException(nameof(categoria));
            Valor = valor;
            Logrado = logrado;
            Perdido = perdido;
        }

        public DetalleEvaluacion()
        {
            DetalleID = 0;
            EvaluacionID = 0;
            Categoria = string.Empty;
            Valor = 0;
            Logrado = 0;
            Perdido = 0;
        }
    }
}
