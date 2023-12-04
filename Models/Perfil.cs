using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace GavResortsTest.Models
{
    public class Perfil
    {
        public virtual int Id { get; set; }
        public virtual string? Descricao { get; set; }
        public virtual bool Ativo { get; set; }
    }
}
