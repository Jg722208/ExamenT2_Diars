using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Examen_T2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Examen_T2.Controllers
{
    public class PokemonController : BaseController
    {
        private readonly ContexPokemon context;
        private readonly IConfiguration configuration;
        private readonly IHostEnvironment _hostEnv;
        public PokemonController(ContexPokemon context, IHostEnvironment hostEnv, IConfiguration configuration) : base(context)
        {
            this.context = context;
            _hostEnv = hostEnv;
            this.configuration = configuration;
        }
        [HttpGet]
        public ActionResult Pokemon(User user, string search)
        {

            var pokemones = context.Elementos.ToList();

            ViewBag.Buscar = search;

            var pokemon = context.Pokemones.Include(o => o.Elemento).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                pokemon = pokemon.Where(s => s.Nombre.Contains(search)).ToList();
                return View("Pokemon", pokemon);
            }

            return View("Pokemon", pokemon);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Registro()
        {
            ViewBag.Elementos = context.Elementos.ToList();
            return View("Registro", new Pokemon());
        }
        [Authorize]
        [HttpPost]
        public ActionResult Registro(Pokemon pokemon, IFormFile image, string nombre)
        {
            if (image != null && image.Length > 0)
            {
                var basePath = _hostEnv.ContentRootPath + @"\wwwroot";
                var ruta = @"\File\" + image.FileName;
                using (var strem = new FileStream(basePath + ruta, FileMode.Create))
                {
                    image.CopyTo(strem);
                    pokemon.Imagen = ruta;
                }
            }
            else
            {
                ModelState.AddModelError("Imagen", "Este campo es obligatorio");
            }
            var pokemons = context.Pokemones.ToList();
            foreach (var item in pokemons)
            {
                if (item.Nombre == nombre)
                {
                    ModelState.AddModelError("Nombre1", "Este pokemon ya existe");
                }
            }
            Console.WriteLine("Imagen? " + image);
            if (ModelState.IsValid)
            {
                context.Pokemones.Add(pokemon);
                context.SaveChanges();
                return RedirectToAction("Pokemon");
            }
            else
            {
                ViewBag.Elementos = context.Elementos.ToList();
                return View("Registro", pokemon);
            }
        }
    }
}