using System;
using Entidades;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Parcial1_NeysiFM_A2.Utilidades;
using System.Linq.Expressions;

namespace Parcial1_NeysiFM_A2.UI.Registros
{
    public partial class RegistroEvaluacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Evaluacion> repositorio = new RepositorioBase<Evaluacion>();
                    var evaluacion = repositorio.Buscar(id);

                    if (evaluacion == null)
                    {
                        MostrarMensaje(TiposMensaje.Error, "Registro no encontrado");
                    }
                    else
                    {
                        LlenaCampos(evaluacion);
                    }
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Evaluacion, bool>> filtro = x => true;
            int id = Utils.ToInt(Request.QueryString["id"]);
            if (id > 0)
            {
                RepositorioBase<Evaluacion> repositorio = new RepositorioBase<Evaluacion>();
                var evaluacion = repositorio.Buscar(id);

                if (evaluacion == null)
                {
                    MostrarMensaje(TiposMensaje.Error, "Registro no encontrado");
                }
                else
                {
                    LlenaCampos(evaluacion);
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            ErrorLabel.Text = string.Empty;
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Evaluacion> repositorio = new BLL.RepositorioBase<Evaluacion>();
            Evaluacion evaluacion = new Evaluacion();
            evaluacion = LlenaClase();
            bool paso = false;

            if (evaluacion.EvaluacionId <= 0)
            {
                evaluacion.Fecha = DateTime.Now;
                paso = repositorio.Guardar(evaluacion);
                if (paso)
                {
                    Limpiar();
                }
            }
            else
                paso = repositorio.Modificar(evaluacion);

            if (paso)
            {
                MostrarMensaje(TiposMensaje.Success, "Registro Guardado Correctamente!");
                Limpiar();
            }
            else
                MostrarMensaje(TiposMensaje.Error, "No Fue Posible Guardar El Registro");
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = 0;

            if (string.IsNullOrEmpty(this.IdTextBox.Text) || string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                MostrarMensaje(TiposMensaje.Error, "El Registro no Puede Ser Eliminado!!");
                return;
            }
            id = Utils.ToInt(IdTextBox.Text);
            RepositorioBase<Evaluacion> repositorio = new RepositorioBase<Evaluacion>();

            if (repositorio.Buscar(id) == null)
            {
                MostrarMensaje(TiposMensaje.Error, "Registro no encontrado");
                return;
            }
            bool eliminado = repositorio.Eliminar(id);
            if (eliminado)
            {
                MostrarMensaje(TiposMensaje.Success, "Registro Eliminado!!");
                Limpiar();
                return;
            }
        }

        private Evaluacion LlenaClase()
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.EvaluacionId = Utils.ToInt(IdTextBox.Text.ToString());
            evaluacion.Nombre = NombreTextBox.Text;

            return evaluacion;
        }
        private void LlenaCampos(Evaluacion evaluacion)
        {
            IdTextBox.Text = evaluacion.EvaluacionId.ToString();
            NombreTextBox.Text = evaluacion.Nombre;
    
        }
        private void Limpiar()
        {
            IdTextBox.Text = " ";
            NombreTextBox.Text = " ";   
        }

        void MostrarMensaje(TiposMensaje tipo, string mensaje)
        {
            ErrorLabel.Text = mensaje;

            if (tipo == TiposMensaje.Success)
                ErrorLabel.CssClass = "alert-success";
            else
                ErrorLabel.CssClass = "alert-danger";
        }        
    }
}