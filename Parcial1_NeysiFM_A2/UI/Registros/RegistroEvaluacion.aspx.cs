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
        readonly string KeyViewState = "Evaluacion";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState[KeyViewState] = new Evaluacion();
            }
        }
        private void Limpiar()
        {
            EvaluacionID.Text = 0.ToString();
            FechaTextBox.Text = DateTime.Now.ToString();
            EstudianteTextBox.Text = string.Empty;
            CategoriaTextBox.Text = string.Empty;
            ValorTextBox.Text = 0.ToString();
            LogradoTextBox.Text = 0.ToString();
            TotalPerdidoTextBox.Text = 0.ToString();
            MostrarMensajes.Visible = false;
            MostrarMensajes.Text = string.Empty;
            ViewState[KeyViewState] = new Evaluacion();
            ActualizarGrid();
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrEmpty(EstudianteTextBox.Text))
                paso = false;
            if (string.IsNullOrEmpty(FechaTextBox.Text))
                paso = false;
            if (DetalleGridView.Rows.Count <= 0)
                paso = false;
            return paso;
        }

        private Evaluacion LlenaClase()
        {
            Evaluacion evaluaciones = new Evaluacion();
            DateTime.TryParse(FechaTextBox.Text, out DateTime result);
            evaluaciones = (Evaluacion)ViewState[KeyViewState];
            evaluaciones.EvaluacionID = EvaluacionID.Text.ToInt();
            evaluaciones.Fecha = result;
            evaluaciones.Estudiante = EstudianteTextBox.Text;
            evaluaciones.TotalPerdido = TotalPerdidoTextBox.Text.ToDecimal();
            return evaluaciones;
        }

        private void LlenaCampo(Evaluacion evaluaciones)
        {
            EvaluacionID.Text = evaluaciones.EvaluacionID.ToString();
            FechaTextBox.Text = evaluaciones.Fecha.ToString();
            EstudianteTextBox.Text = evaluaciones.Estudiante.ToString();
            TotalPerdidoTextBox.Text = evaluaciones.TotalPerdido.ToString();
            ViewState[KeyViewState] = evaluaciones;
            ActualizarGrid();
        }

        public bool ExisteEnLaBaseDeDatos()
        {
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
            return repositorio.Buscar(EvaluacionID.Text.ToInt()) != null; ;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            bool paso = false;
            Evaluacion evaluacion = LlenaClase();
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
            if (evaluacion.EvaluacionID == 0)
                paso = repositorio.Guardar(evaluacion);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    return;
                }
                paso = repositorio.Modificar(evaluacion);
            }
            if (paso)
            {
                Limpiar();
                MostrarMensajes.Text = "Guardado";
                MostrarMensajes.CssClass = "alert-success";
                MostrarMensajes.Visible = true;
            }
            else
            {
                MostrarMensajes.Text = "No guardo";
                MostrarMensajes.CssClass = "alert-warning";
                MostrarMensajes.Visible = true;
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
            Evaluacion evaluaciones = repositorio.Buscar(EvaluacionID.Text.ToInt());
            if (evaluaciones != null)
            {
                Limpiar();
                LlenaCampo(evaluaciones);
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
            int id = EvaluacionID.Text.ToInt();
            if (!ExisteEnLaBaseDeDatos())
            {
                MostrarMensajes.Visible = true;
                MostrarMensajes.Text = "No encontrado";
                MostrarMensajes.CssClass = "alert-danger";
                return;
            }
            else
            {
                if (repositorio.Eliminar(id))
                {
                    Limpiar();
                    MostrarMensajes.Visible = true;
                    MostrarMensajes.Text = "Eliminado";
                    MostrarMensajes.CssClass = "alert-danger";
                }
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Evaluacion evaluacion = ((Evaluacion)ViewState[KeyViewState]);
            decimal Valor = ValorTextBox.Text.ToDecimal();
            decimal Logrado = LogradoTextBox.Text.ToDecimal();
            evaluacion.DetalleEvaluacion.Add(new DetalleEvaluacion(0, evaluacion.EvaluacionID, CategoriaTextBox.Text, Valor, Logrado, (Valor - Logrado)));
            ViewState[KeyViewState] = evaluacion;
            ActualizarGrid();
            Calcular();
            CategoriaTextBox.Text = string.Empty;
            ValorTextBox.Text = 0.ToString();
            LogradoTextBox.Text = 0.ToString();
        }

        private void Calcular()
        {
            decimal TotalPerdido = 0;
            Evaluacion evaluacion = ((Evaluacion)ViewState[KeyViewState]);
            foreach (var item in evaluacion.DetalleEvaluacion.ToList())
            {
                TotalPerdido += item.Perdido;
            }
            TotalPerdidoTextBox.Text = TotalPerdido.ToString();
        }

        private void ActualizarGrid()
        {
            Evaluacion evaluacion = (Evaluacion)ViewState[KeyViewState];
            DetalleGridView.DataSource = evaluacion.DetalleEvaluacion;
            DetalleGridView.DataBind();
        }
    }
}