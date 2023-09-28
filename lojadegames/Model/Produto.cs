using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lojadegames.Model
{
    public class Produto
    {
        [Key] // Primary Key (Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // IDENTITY(1,1)
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Console { get; set; } = string.Empty;

        [Column(TypeName = "decimal(8,2)")]
        [StringLength(255)]
        public decimal Preco { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(510)]
        public string Foto { get; set; } = string.Empty;

        public virtual Categoria? Categoria { get; set; }

    }
}


