﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UrlShortener.Models;

namespace UrlShortener.Entities
{
    public class URL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Url { get; set; }

        [Required]
        public string? ShortUrl { get; set; }

        [Required]
        public int ContadorVisitas { get; set; }

        [Required]
        public CategoriaEnum Categoria { get; set; }

    }
}
