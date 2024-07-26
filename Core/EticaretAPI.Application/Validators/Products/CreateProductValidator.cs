using EticaretAPI.Application.ViewModels.Products;
using FluentValidation;

namespace EticaretAPI.Application.Validators.Products
{
    public class CreateProductValidator: AbstractValidator<VM_Create_Products>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz")
                .MaximumLength(50)
                .MinimumLength(1)
                    .WithMessage("Lütfen ürün adını 1 ila 50 karakter arasında giriniz");

            RuleFor(p => p.Feature1)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen özelliğini boş geçmeyiniz")
                .MaximumLength(50)
                .MinimumLength(1)
                    .WithMessage("Lütfen özelliğini 1 ila 50 karakter arasında giriniz");

            RuleFor(p => p.Feature2)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen özelliğini boş geçmeyiniz")
                .MaximumLength(50)
                .MinimumLength(1)
                    .WithMessage("Lütfen özelliğini 1 ila 50 karakter arasında giriniz");

            RuleFor(p => p.ProductCode)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen kodu boş geçmeyiniz")
                .MaximumLength(50)
                .MinimumLength(1)
                    .WithMessage("Lütfen kodu 1 ila 50 karakter arasında giriniz");

            RuleFor(p => p.CategoryId)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen bir kategori seçiniz")
                .Must(c => c > 0)
                    .WithMessage("lütfen 0 dan büyük bir değer giriniz");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz")
                .Must(p => p >= 0)
                    .WithMessage("Lütfen fiyat bilgisini 0 veya sıfırdan büyük giriniz");

            RuleFor(p => p.Quantity)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stok bilgisini boş geçmeyiniz")
                .Must(q => q >= 0)
                    .WithMessage("Lütfen stok bilgisini 0 veya sıfırdan büyük giriniz");

        }
    }
}
