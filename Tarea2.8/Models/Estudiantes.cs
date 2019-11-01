using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tarea2._8.Models
{
    public class Estudiantes
    {
        public int EstudianteID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Inscripcion { get; set; }
        public virtual ICollection<Inscripciones> Inscripciones { get; set; }
    }
    public class Inscripciones
    {
        public int InscripcionId { get; set; }
        public int CursoId { get; set; }
        public int EstudianteID { get; set; }
        public int Semestre { get; set; }
        public virtual Estudiantes Estudiante { get; set; }
    }
    public class Cursos
    {
        public int CursoID { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Inscripciones> Inscripciones { get; set; }

    }

}
