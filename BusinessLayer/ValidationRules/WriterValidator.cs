using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçemezsiniz!!");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş geçemezsiniz!!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında boş geçemezsiniz!!"); 
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir A harfi içermelidir");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Yazar resmi boş geçemezsiniz!!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar maili boş geçemezsiniz!!");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Yazar mail formaya uygun değil!!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar parolası boş geçemezsiniz!!");
        }
    }
}
