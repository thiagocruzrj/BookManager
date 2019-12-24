using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookManager.Application.ViewModels
{
    public class AuthorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Field {0} is required.")]
        public Document Cpf { get; set; }
        [Required(ErrorMessage = "Field {0} is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field {0} is required.")]
        public DateTime Birthdate { get; set; }
        public virtual ICollection<BookViewModel> Books { get; set; }
    }
}
