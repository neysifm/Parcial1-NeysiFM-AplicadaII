using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioEvaluacion : RepositorioBase<Evaluacion> 
    {
        // METODO MODIFICAR
        public override bool Modificar(Evaluacion entity)
        {
            bool paso = false;
            Evaluacion Anterior = Buscar(entity.EvaluacionID);
            Contexto contexto = new Contexto();
            try
            {
                using (Contexto baseDatos = new Contexto())
                {
                    foreach (var item in Anterior.DetalleEvaluacion.ToList())
                    {
                        if (!entity.DetalleEvaluacion.Exists(x => x.DetalleID == item.DetalleID))
                        {
                            baseDatos.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    baseDatos.SaveChanges();
                }
                foreach (var item in entity.DetalleEvaluacion)
                {
                    var estado = EntityState.Unchanged;
                    if (item.DetalleID == 0)
                    estado = EntityState.Added;
                    contexto.Entry(item).State = estado;
                }
                contexto.Entry(entity).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        // METODO BUSCAR
        public override Evaluacion Buscar(int id)
        {
            Evaluacion Evaluacion = new Evaluacion();
            Contexto contexto = new Contexto();
            try
            {
                Evaluacion = contexto.Evaluacion.Include(x => x.DetalleEvaluacion).Where(x => x.EvaluacionID == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Evaluacion;
        }
    }
}
