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
    public partial class AgregarEstudiante : ContentPage
    {

        private const string Url = "http://192.168.70.135/prueba/post.php";

        public AgregarEstudiante()
        {
            InitializeComponent();
        }

        private void insertar_Clicked(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            try
            {
                var parameters = new System.Collections.Specialized.NameValueCollection();
                parameters.Add("cedulaPaciente", entCedula.Text);
                parameters.Add("nombrePaciente", entNombre.Text);
                parameters.Add("apellidoPaciente", entApellido.Text);
                parameters.Add("correoPaciente", entCorreo.Text);
                parameters.Add("telefonoPaciente", entTelefono.Text);
                parameters.Add("direccionPaciente", entDireccion.Text);
                parameters.Add("estadoPaciente", entEstado.Text);

                client.UploadValues(Url, "POST", parameters);
                DisplayAlert("Completado", "Paciente Registrado: " + entNombre + " " + entApellido, "Cerrar");
                Limpiar();

            } catch(Exception ex) 
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
                DisplayAlert("Error", "Se produjo un Errrrroooorr: ", "Cerrar");
            }
        }

        public void Limpiar()
        {
            entCedula.Text = string.Empty;
            entNombre.Text = string.Empty;
            entApellido.Text = string.Empty;
            entCorreo.Text = string.Empty;
            entTelefono.Text = string.Empty;
            entDireccion.Text = string.Empty;
            entEstado.Text = string.Empty;
        }

        private async void btnRegreso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoEstudiantes());
        }
    }
}