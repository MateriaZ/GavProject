namespace GavResortsTest.Models
{
    public class Contact
    {
        public virtual int Id { get; set; }

        public virtual string? Nome { get; set; }

        public virtual string? Email { get; set; }

        public virtual string? Telefone { get; set; }

        public virtual string? Endereco { get; set; }

        public virtual string? Categoria { get; set; }

        public virtual bool Ativo { get; set; }
    }
}
