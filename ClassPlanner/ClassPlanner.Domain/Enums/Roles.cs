using System.ComponentModel;

namespace ClassPlanner.Domain.Enums
{
    public enum Roles
    {
        [Description("Administrador")]
        Administrador = 0,
        [Description("Gestor")]
        Gestor = 1,
        [Description("Docente")]
        Docente = 2
    }
}
