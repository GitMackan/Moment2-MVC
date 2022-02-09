using System.ComponentModel.DataAnnotations;

namespace Moment2.Models {
    public class MovieModel {
        // Properties
        [Display(Name = "Titel:")]
        [Required(ErrorMessage = "Ange en Titel.")]
        public string? Title { get; set; }

        [Display(Name = "Regissör:")]
        [Required(ErrorMessage = "Ange en Regissör.")]
        public string? Director { get; set; }

        [Display(Name = "År:")]
        [Range(1800, 2022, ErrorMessage = "Ange ett år mellan 1888-2022.")]
        [Required(ErrorMessage = "Ange ett årtal.")]
        public int? Year { get; set; }

        [Display(Name = "Betyg (1-5):")]
        [Range(1, 5, ErrorMessage = "Ange ett betyg mellan 1-5.")]
        [Required(ErrorMessage = "Ange ett betyg.")]
        public int? Review { get; set; }

        [Display(Name = "IMDB-länk (Valfritt):")]
        public string? IMDB { get; set; }

        [Display(Name = "Genre:")]
        [Required(ErrorMessage = "Ange en genre.")]
        public string? Genre { get; set; }

        
    }
}