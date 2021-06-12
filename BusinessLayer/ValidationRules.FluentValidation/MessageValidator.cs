using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresini Boş Geçemezsiniz");
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Boş Geçemezsiniz");
            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(x => x.ReceiverMail).Must(IsAboutValid).WithMessage("Lütfen Email adresine bir @ işareti ekleyin");

            bool IsAboutValid(string arg)
            {
                try
                {
                    Regex regex = new Regex(@"^(?=.*[@])");
                    return regex.IsMatch(arg);
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
    }
}
