﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookManager.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Field {0} is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field {0} is required.")]
        public int Code { get; set; }
        public virtual ICollection<BookViewModel> Books { get; set; }
    }
}