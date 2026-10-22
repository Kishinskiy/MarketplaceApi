using System.ComponentModel.DataAnnotations;

namespace Marketplace.Api.DTOs;

public record ProductCreateDto(
    [Required(ErrorMessage = "Имя товара обязательно для заполнения.")]
    [StringLength(100, ErrorMessage = "Имя товара не может быть длиннее 100 символов.")]
    string Name, 

    [StringLength(500, ErrorMessage = "Описание не может превышать 500 символов.")]
    string Description, 

    [Range(0.01, double.MaxValue, ErrorMessage = "Цена товара должна быть больше нуля.")]
    decimal Price
);
