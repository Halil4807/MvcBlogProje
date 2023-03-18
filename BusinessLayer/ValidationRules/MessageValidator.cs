using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş geçilemez!!");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Alıcı adresi formata uygun değil!!");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçilemez!!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez!!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter giriniz!!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter giriniz!!");
        }
    }
}
