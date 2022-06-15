using System.ComponentModel.DataAnnotations.Schema;

namespace RESTWithASP_NET5Udemy.Model
{
    [Table("book")]
    public class Book
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("Nome")]
        public string nome { get; set; }
        [Column("Categoria")]
        public string categoria { get; set; }
        [Column("Autor")]
        public string autor { get; set; }
        [Column("Preco")]
        public long preco { get; set; }
    }
}
