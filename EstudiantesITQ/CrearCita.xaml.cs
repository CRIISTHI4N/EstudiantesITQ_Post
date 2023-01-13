using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstudiantesITQ
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearCita : ContentPage
    {

        private const string Url = "http://192.168.70.135/prueba/post1.php";
        public CrearCita(int cedula, string nombre)
        {
            InitializeComponent();
            entCodigo.Text = cedula.ToString();
            entNombre.Text = nombre.ToString();
        }

        private void guardar_Clicked(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            try
            {
                var parameters = new System.Collections.Specialized.NameValueCollection();
                parameters.Add("idCita", entId.Text);
                parameters.Add("idPaciente", entCodigo.Text);
                parameters.Add("nombreMedico", entMedico.Text);
                parameters.Add("especialidad", entEspecialidad.Text);
                parameters.Add("fecha", entFecha.Text);
                parameters.Add("hora", entHora.Text);

                client.UploadValues(Url, "POST", parameters);
                DisplayAlert("Completado", "Paciente Registrado: " + entCodigo + " " + entNombre, "Cerrar");

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
                DisplayAlert("Error", "Se produjo un Errrrroooorr: ", "Cerrar");
            }
        }

        private async void btnRegreso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoEstudiantes());
        }
    }
}