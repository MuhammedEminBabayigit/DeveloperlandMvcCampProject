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
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterFullName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterNickName).NotEmpty().WithMessage("Nickname Kısmını Boş Geçemezsiniz");
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("Yazar Mailini Boş Geçemezsiniz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar Şifresini Boş Geçemezsiniz");
            RuleFor(x => x.WriterEmail).Must(IsAboutValid).WithMessage("Lütfen Email adresine bir @ işareti ekleyin");

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
