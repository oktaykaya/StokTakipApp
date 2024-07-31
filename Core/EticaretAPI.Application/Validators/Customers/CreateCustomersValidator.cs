using EticaretAPI.Application.ViewModels.Customers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Application.Validators.Customers
{
    public class CreateCustomersValidator: AbstractValidator<VM_Create_Customers>
    {
        public CreateCustomersValidator() 
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen İsim alanını boş bırakmayınız")
                .MaximumLength(50)
                .MinimumLength(3)
                    .WithMessage("Lütfen ürün adını 3 ila 50 karakter arasında giriniz");

            RuleFor(p => p.LastName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Soyisim alanını boş bırakmayınız")
                .MaximumLength(50)
                .MinimumLength(3)
                    .WithMessage("Lütfen ürün adını 3 ila 50 karakter arasında giriniz");

            RuleFor(p => p.Gender)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen cinsiyet alanını boş bırakmayınız");

            RuleFor(p => p.Phone)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Lütfen telefon numarası alanını boş bırakmayınız")
                .MaximumLength(11)
                .MinimumLength(11)
                    .WithMessage("Lütfen 11 haneli telefon numaranızı giriniz");

            RuleFor(p => p.Address)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen adres alanını boş bırakmayınız")
                .MaximumLength(250)
                .MinimumLength(10)
                    .WithMessage("Lütfen adres alanını 10 ila 250 karakter arasında giriniz");

            RuleFor(p => p.Tc)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Lütfen TC alanını boş bırakmayınız")
                .MaximumLength(11)
                .MinimumLength(11)
                    .WithMessage("Lütfen 11 haneli TC numaranızı giriniz");
        }
    }
}
