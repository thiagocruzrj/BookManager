using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookManager.Catalog.Application.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Field {0} is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field {0} is required.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Field {0} is required.")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Field {0} is required.")]
        public BookIdentificator Isbn { get; set; }

        [Required(ErrorMessage = "Field {0} is required.")]
        public DateTime RegisterDate { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
