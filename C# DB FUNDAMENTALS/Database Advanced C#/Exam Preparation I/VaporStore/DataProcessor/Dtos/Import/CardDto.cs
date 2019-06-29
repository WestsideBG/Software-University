﻿using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dtos.Import
{
    public class CardDto
    {
        [Required]
        [RegularExpression(@"^[0-9]{4}\s+[0-9]{4}\s+[0-9]{4}\s+[0-9]{4}$")]
        public string Number { get; set; }
        [Required]
        [RegularExpression("^[0-9]{3}$")]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }

    }
}