﻿using System.ComponentModel.DataAnnotations;
namespace UrlShortener.Models
{
    public class UrlForCreationDto
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? ShortUrl { get; set; }
        public int ContadorVisitas { get; set; }
        public CategoriaEnum Categoria { get; set; }
    }
}
