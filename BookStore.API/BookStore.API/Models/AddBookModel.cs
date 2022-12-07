using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models
{
    public class AddBookModel
    {
        [Required(ErrorMessage = "Please add title")]
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
