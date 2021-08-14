using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aec_webapi_entity_framework.Models
{
  [Table("marcas")]
  public class Marca
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

    [Column("nome", TypeName = "varchar")]
    [MaxLength(150)]
    [Required]
    public string Nome { get;set; }
    public ICollection<Carro> Carros { get; set; }
  }
}