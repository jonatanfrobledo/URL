﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Data;
using UrlShortener.Entities;
using UrlShortener.Helpers;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UrlController : ControllerBase
    {
        private readonly UrlShortenerContext _UrlContext;

        public UrlController(UrlShortenerContext UrlContext)
        {
            _UrlContext = UrlContext;
        }

        [HttpGet("get")]

        public IActionResult GetUrl(string ClientUrl)
        {
            var urlEntity = _UrlContext.Urls.FirstOrDefault(x => x.ShortUrl == ClientUrl);

            if (urlEntity == null)
            {
                return NotFound("La URL no existe");
            }
            urlEntity.ContadorVisitas += 1;
            _UrlContext.SaveChanges();
            return Ok(urlEntity.Url);
            //return Redirect(urlEntity.Url);
        }

        [HttpGet("getByCategoria")]

        public IActionResult GetUrlsByCategory(CategoriaEnum Category)
        {
            var urlsFounded = _UrlContext.Urls.Where(x => x.Categoria == Category).ToList();

            var urlList = urlsFounded.Select(url => url.Url).ToList();
            return Ok(urlList);
        }


        [HttpPost("post")]
        public IActionResult CreateNewURL(string newurl, CategoriaEnum category)
        {
            var urlHelper = new UrlHelper();
            var urlEntity = new URL()
            {
                Url = newurl,
                ShortUrl = urlHelper.GetShortURL(),
                Categoria = category
            };

            _UrlContext.Urls.Add(urlEntity);
            _UrlContext.SaveChanges();
            return Ok(urlEntity.ShortUrl);
        }


    }
}
