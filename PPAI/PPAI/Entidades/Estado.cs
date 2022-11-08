using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public static class EnumExtensions
    {
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0
              ? (T)attributes[0]
              : null;
        }
        public static string getAmbito(this Enum value)
        {
            var attribute = value.GetAttribute<AmbitoAttribute>();
            return attribute == null ? value.ToString() : attribute.Ambito;
        }

        public static string getNombre(this Enum value)
        {
            var attribute = value.GetAttribute<NombreAttribute>();
            return attribute == null ? value.ToString() : attribute.Nombre;
        }

        public static string getDescripcion(this Enum value)
        {
            var attribute = value.GetAttribute<DescripcionAttribute>();
            return attribute == null ? value.ToString() : attribute.Descripcion;
        }
        public static bool getReservable(this Enum value)
        {
            var attribute = value.GetAttribute<EsReservableAttribute>();
            return attribute.EsReservable;
            //return attribute == null ? value.ToString() : attribute.EsReservable;
        }
        public static bool getCancelable(this Enum value)
        {
            var attribute = value.GetAttribute<EsCancelableAttribute>();
            return attribute.EsCancelable;
            //return attribute == null ? value.ToString() : attribute.EsCancelable;
        }
        public static bool esAmbitoTurno(this Enum value)
        {
            return value.getAmbito() == "Turno";
        }
        public static bool esReservado(this Enum value)
        {
            return value.getNombre() == "Reservado";
        }
    }

    public class AmbitoAttribute : Attribute
    {
        string ambito;
        public AmbitoAttribute(string amb)
        {
            ambito = amb;
        }

        public string Ambito { get { return ambito; } }
    }

    public class NombreAttribute : Attribute
    {
        string nombre;
        public NombreAttribute(string nom)
        {
            nombre = nom;
        }

        public string Nombre { get { return nombre; } }
    }

    public class DescripcionAttribute : Attribute
    {
        string descripcion;
        public DescripcionAttribute(string des)
        {
            descripcion = des;
        }

        public string Descripcion { get { return descripcion; } }
    }

    public class EsReservableAttribute : Attribute
    {
        bool esReservable;
        public EsReservableAttribute(bool esr)
        {
            esReservable = esr;
        }

        public bool EsReservable { get { return esReservable; } }
    }

    public class EsCancelableAttribute : Attribute
    {
        bool esCancelable;
        public EsCancelableAttribute(bool esc)
        {
            esCancelable = esc;
        }

        public bool EsCancelable { get { return esCancelable; } }
    }

    public enum Estado
    {
        [Ambito("Turno"),Nombre("Disponible"),Descripcion("Turno Disponible"),EsReservable(true),EsCancelable(false)]
        TurnoDisponible,
        [Ambito("Turno"), Nombre("Reservado"), Descripcion("Turno Reservado"), EsReservable(false), EsCancelable(true)]
        TurnoReservado,
        [Ambito("Turno"), Nombre("Reserva Pendiente"), Descripcion("Turno con Reserva Pendiente"), EsReservable(false), EsCancelable(true)]
        TurnoReservaPendiente,
        [Ambito("RT"), Nombre("Activo"), Descripcion("RT Activo"), EsReservable(true), EsCancelable(false)]
        RTActivo
    }
    /*
    public class Estado
    {
        private string Ambito { set; get; }
        private string Nombre { set; get; }
        private string Descripcion { set; get; }

        private static Estado disp;
        private static Estado res;
        private static Estado resp;
        private static Estado rtact;

        public bool EsReservable()
        {
            return (this.Nombre == "Disponible" || this.Nombre == "Activo");
        }

        public bool EsCancelable()
        {
            return (this.Nombre == "Reservado" || this.Nombre == "Reserva Pendiente");
        }
        
        public static Estado TurnoDisponible()
        {
            if (disp == null)
            {
                disp = new Estado();
                disp.Ambito = "Turno";
                disp.Nombre = "Disponible";
                disp.Descripcion = "Turno Disponible";
            }
            return disp;
        }
    }
    */
    /*
    internal class Estado
    {
        private string nombre;
        private string descripcion;
        private string ambito;
        private bool esReservable;
        private bool esCancelable;

        public Estado(string nom, string des, string amb, bool esr, bool esc)
        {
            nombre = nom;
            descripcion = des;
            ambito = amb;
            esReservable = esr;
            esCancelable = esc;
        }

        public string MostrarEstado()
        {
            return nombre;
        }
    }
    */
}
