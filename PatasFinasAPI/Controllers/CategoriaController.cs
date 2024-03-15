﻿using Microsoft.AspNetCore.Mvc;
using PatasFinasAPI.Models;

namespace PatasFinasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly db_Patas_FinasContext BD;

        public CategoriaController(db_Patas_FinasContext context)
        {
            BD = context;
        }

        [HttpGet]
        public IEnumerable<Categorium> ListaDeCategorias()
        {
            return BD.Categoria.ToList();
        }
    }
}
