using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesITQ
{
    public class Datos
    {
        public int cedulaPaciente { get; set; }
        public string nombrePaciente { get; set; }
        public string apellidoPaciente { get; set; }
        public string correoPaciente { get; set; }
        public string telefonoPaciente { get; set; }
        public string direccionPaciente { get; set; }
        public bool estadoPaciente { get; set; }

        //TABLA CITA
        public int idCita { get; set; }
        public int idPaciente { get; set; }
        public string nombreMedico { get; set; }
        public string especialidad { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }

    }
}
