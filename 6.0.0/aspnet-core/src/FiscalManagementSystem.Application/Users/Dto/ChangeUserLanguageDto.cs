using System.ComponentModel.DataAnnotations;

namespace FiscalManagementSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}