

using System.ComponentModel.DataAnnotations.Schema;

namespace GavResortsTest.Models
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string? Nome { get; set; }
        public virtual string? Senha { get; set; }
        [ForeignKey("Id")]
        public virtual Perfil? Perfil { get; set; }
    }
}
