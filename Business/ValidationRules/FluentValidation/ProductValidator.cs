using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{

    //urun icin kurallar gerceklestirecegiz demek
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Urun ismi bos olamaz");
            RuleFor(p=>p.CategoryID).NotEmpty().WithMessage("Category bos olamaz"); 
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Urun fiyatı bos olamaz"); 
            RuleFor(p => p.UnitsInStock).NotEmpty().WithMessage("Stock bos olamaz"); 
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage("Ürün birimi bos olamaz"); 

            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Urun fiyatı 0 dan buyuk olmalı"); 
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0).WithMessage("Stock 0 dan buyuk olmalı"); 

        }
    }
}
