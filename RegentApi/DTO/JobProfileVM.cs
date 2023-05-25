using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RegentApi.DTO
{
    public class JobProfileVM
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 characters are allowed")]
        [Required(ErrorMessage = "Role is required")]
        [Remote("isroleavailable", "page", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Role already in use")]
        public string RoleName { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 characters are allowed")]
        [Required(ErrorMessage = "Menu name is required")]
        public string MenuButtonName { get; set; }

        [Required(ErrorMessage = "Page url is required")]
        [Remote("isurlavailable", "page", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Url already in use")]
        public string Url { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters are allowed")]
        [Required(ErrorMessage = "Page heading is required")]
        public string PageHeading { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 characters are allowed")]
        [Required(ErrorMessage = "Page title is required")]
        public string PageTitle { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters are allowed")]
        [Required(ErrorMessage = "SEO keywords are required")]
        public string MetaKeyword { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(256, ErrorMessage = "Maximum 256 characters are allowed")]
        [Required(ErrorMessage = "SEO description is required")]
        public string MetaDescription { get; set; }

        public string CoverPhotoUrl { get; set; }


        [MaxLength(512, ErrorMessage = "Maximum 512 characters are allowed")]
        [Required(ErrorMessage = "Contact form heading is required")]
        public string ContactFormHeading { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public string HtmlContent { get; set; }

        [UIHint("tinymce_jquery_classic"), AllowHtml]
        [Required(ErrorMessage = "Content is required")]
        public string HtmlContentPublic
        {
            get { return HtmlContent; }
            set { HtmlContent = value; }
        }

        [MaxLength(100, ErrorMessage = "Maximum 100 characters are allowed")]
        public string SalaryTitle { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(512, ErrorMessage = "Maximum 512 characters are allowed")]
        public string SalaryDescription { get; set; }
    }
}
