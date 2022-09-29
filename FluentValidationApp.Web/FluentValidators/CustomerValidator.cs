using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{   
    // generic tip entity, dto veya viewmodel olabilir.
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";
        public CustomerValidator()
        {   
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır");

            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage
                ("Yaş alanı 18 ile 60 arasında olmalıdır.");


            // Must() method ile custom validasyon yazmak.
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;

            }).WithMessage("Yaşınız 18'den büyük olmalıdır");

            // enum. isinenum
            RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} alanı Erkek=1, Bayan=2 olmalıdır");

            // parent - child ilişkisinde validator
            // Her bir adres için AdressValidatoru uygula. 
            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
        }
        
        
    }
}
