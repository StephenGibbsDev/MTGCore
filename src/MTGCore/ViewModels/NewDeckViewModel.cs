using System.ComponentModel.DataAnnotations;

namespace MTGCore.ViewModels
{
    public class NewDeckViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The title must be between 3 and 30 characters")]
        public string Title { get; }
        public string Description { get; }

        public NewDeckViewModel(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}