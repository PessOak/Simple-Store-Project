using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

public class CadastroProduto
{
    [Key]
    public int IdProd { get; set; } // ID do produto (chave primária)

    [Required(ErrorMessage = "O fornecedor é obrigatório.")]
    public int IdForn { get; set; } // ID do fornecedor (chave estrangeira)

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(50, ErrorMessage = "O nome do produto deve ter no máximo 50 caracteres.")]
    public string NomeProd { get; set; }

    [Required(ErrorMessage = "O preço de venda é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal PrecoProd { get; set; }

    [Required(ErrorMessage = "A categoria é obrigatória.")]
    [StringLength(50, ErrorMessage = "A categoria deve ter no máximo 50 caracteres.")]
    public string CategProd { get; set; }

    [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a zero.")]
    public int QuantProd { get; set; }

    [StringLength(50, ErrorMessage = "A descrição deve ter no máximo 50 caracteres.")]
    public string DescProd { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "O estoque mínimo deve ser maior ou igual a zero.")]
    public int EstoqueMinimo { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "O estoque máximo deve ser maior ou igual a zero.")]
    public int EstoqueMaximo { get; set; }

    [Display(Name = "Imagem do Produto")]
    public IFormFile ImagemProduto { get; set; } // Para upload de imagens

    public byte[] ImgUrl { get; set; } // Para salvar o BLOB diretamente no banco (se necessário)
}