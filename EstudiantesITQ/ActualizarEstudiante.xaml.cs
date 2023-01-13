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
    public partial class ActualizarEstudiante : ContentPage
    {
        public const string Url = "http://192.168.70.135/prueba/post.php?cedulaPaciente={0}&nombrePaciente={1}&apellidoPaciente={2}&correoPaciente={3}&telefonoPaciente={4}&direccionPaciente={5}&estadoPaciente={6}";


        public ActualizarEstudiante(int cedula, string nombre, string apellido, string correo, string telefono, string direccion, bool estado)
        {
            InitializeComponent();
            entCodigo.Text= cedula.ToString();
            entNombre.Text= nombre.ToString();
            entApellido.Text= apellido.ToString();
            entCorreo.Text= correo.ToString();
            entTelefono.Text= telefono.ToString();
            entDireccion.Text = direccion.ToString();
            entEstado.Text = estado.ToString();
        }

        private void actualizar_Clicked(object sender, EventArgs e)
        {

            WebClient client = new WebClient();
            try 
            {
                using (var webClient = new WebClient())
                {
                    var uri = new Uri(string.Format(Url,
                    entCodigo.Text, entNombre.Text, entApellido.Text, entCorreo.Text, entTelefono.Text, entDireccion.Text, entEstado.Text));
                    webClient.UploadString(uri, "PUT", string.Empty);

                    DisplayAlert("Success", "Registro de: " + entNombre.Text + " " + entApellido.Text + " actualizado correctamente", "Cerrar");
                }
                
            } catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private async void btnRegreso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoEstudiantes());
        }
    }
}