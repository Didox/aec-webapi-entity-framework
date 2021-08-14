using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aec_webapi_entity_framework.Models
{
  [Table("carros")]
  public class Carro
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

    [Column("nome", TypeName = "varchar")]
    [MaxLength(150)]
    [Required]
    public string Nome { get;set; }

    [Column("modelo", TypeName = "varchar")]
    [MaxLength(50)]
    [Required]    
    public string Modelo { get;set; }

    [Column("marca_id")]
    [Required]
    [ForeignKey("MarcaId")]
    [JsonPropertyName("marca_id")]
    public int MarcaId { get; set; }

    [JsonIgnore]
    public Marca Marca { get; set; }

    [Column("ano", TypeName = "int")]
    [Required]
    public int Ano { get;set; }
  }
}