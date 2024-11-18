using System.ComponentModel.DataAnnotations;

namespace ShopTARgv23.Models.Cocktails
{
    public class CocktailsSearchViewModel
    {
        [Required(ErrorMessage = "You must enter a cocktail name!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a cocktail name greater than 2 and lesser than 20 chracters!")]
        [Display(Name = "Cocktail Name")]
        public string strDrink { get; set; }
    }
}
