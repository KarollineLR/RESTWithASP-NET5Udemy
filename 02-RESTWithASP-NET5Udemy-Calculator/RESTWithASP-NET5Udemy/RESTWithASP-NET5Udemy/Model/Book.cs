using RESTWithASP_NET5Udemy.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTWithASP_NET5Udemy.Model
{
    [Table("book")]
    public class Book : BaseEntity
    {
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
