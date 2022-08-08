using System.Collections.Generic;
using System.Security.Claims;

namespace DommunBackend.Common
{
    public class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("TipoZona", "View"),
            new Claim("TipoZona", "Create"),
            new Claim("TipoZona", "Edit"),
            new Claim("TipoZona", "Delete"),

            new Claim("Zona", "View"),
            new Claim("Zona", "Create"),
            new Claim("Zona", "Edit"),
            new Claim("Zona", "Delete"),

            new Claim("Agente", "View"),
            new Claim("Agente", "Create"),
            new Claim("Agente", "Edit"),
            new Claim("Agente", "Delete"),

            new Claim("Cliente", "View"),
            new Claim("Cliente", "Create"),
            new Claim("Cliente", "Edit"),
            new Claim("Cliente", "Delete"),

            new Claim("Pais", "View"),
            new Claim("Pais", "Create"),
            new Claim("Pais", "Edit"),
            new Claim("Pais", "Delete"),


            new Claim("Departamento", "View"),
            new Claim("Departamento", "Create"),
            new Claim("Departamento", "Edit"),
            new Claim("Departamento", "Delete"),

            new Claim("Municipio", "View"),
            new Claim("Municipio", "Create"),
            new Claim("Municipio", "Edit"),
            new Claim("Municipio", "Delete"),

            new Claim("Roles", "View"),
            new Claim("Roles", "Create"),
            new Claim("Roles", "Edit"),
            new Claim("Roles", "Delete"),

            new Claim("Roles", "View"),
            new Claim("Roles", "Create"),
            new Claim("Roles", "Edit"),
            new Claim("Roles", "Delete"),

            new Claim("RolPermisos", "View"),
            new Claim("RolPermisos", "Create"),
            new Claim("RolPermisos", "Edit"),
            new Claim("RolPermisos", "Delete"),

            new Claim("UserRoles", "View"),
            new Claim("UserRoles", "Create"),
            new Claim("UserRoles", "Edit"),
            new Claim("UserRoles", "Delete"),
        };
    }
}
