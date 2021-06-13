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
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminFullName).NotEmpty().WithMessage("Admin Adını Boş Geçemezsiniz");
            RuleFor(x => x.AdminNickName).NotEmpty().WithMessage("Nickname Kısmını Boş Geçemezsiniz");
            //RuleFor(x => x.AdminRole).NotEmpty().WithMessage("Rol Kısmını Boş Geçemezsiniz");
            RuleFor(x => x.AdminEmail).NotEmpty().WithMessage("Admin Mailini Boş Geçemezsiniz");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Admin Şifresini Boş Geçemezsiniz");
            RuleFor(x => x.AdminEmail).Must(IsAboutValid).WithMessage("Lütfen Email adresine bir @ işareti ekleyin");

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
