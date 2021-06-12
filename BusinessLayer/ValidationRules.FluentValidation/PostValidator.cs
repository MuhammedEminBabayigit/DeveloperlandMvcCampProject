using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.PostHead).NotEmpty().WithMessage("Post başlık Alanı Boş Geçilemez");
            RuleFor(x => x.PostContent).NotEmpty().WithMessage("Post İçerik Alanı Boş Geçilemez");
            RuleFor(x => x.PostImage).NotEmpty().WithMessage("Post Resim Alanı Boş Geçilemez");
            RuleFor(x => x.WriterID).NotEmpty().WithMessage("Post Yazar Alanı Boş Geçilemez");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Post Kategori Alanı Boş Geçilemez");
        }
    }
}
