using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioEvaluacion<Evaluacion> : IDisposable, IRepository<Evaluacion> where Evaluacion : class
    {
        internal Contexto contexto;

        // CONSTRUCTOR
        public RepositorioEvaluacion()
        {
            contexto = new Contexto();
        }

        // METODO MODIFICAR
        public virtual bool Modificar(Evaluacion entity)
        {
            bool Paso = false;
            try
            {
               // Contexto.Entry(entity).State = EntityState.Modified;
                Paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return Paso;
        }

        public Evaluacion Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(Evaluacion entity)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Evaluacion> GetList(Expression<Func<Evaluacion, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
