using System.ComponentModel;

namespace Commun
{
    public class Enums
    {
        public enum TipoUsuario
        {
            Admin = 1,
            Agente = 2
        }

        public enum NumPisos
        {
            [Description("1")]
            Uno = 1,

            [Description("2")]
            Dos = 2,

            [Description("3")]
            Tres = 3,

            [Description("4")]
            Cuatro = 4,

            [Description("5+")]
            Cinco = 5,
        }
    }
}
