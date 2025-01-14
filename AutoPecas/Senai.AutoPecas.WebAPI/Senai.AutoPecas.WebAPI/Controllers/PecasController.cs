﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebAPI.Domains;
using Senai.AutoPecas.WebAPI.Interfaces;
using Senai.AutoPecas.WebAPI.Repositories;

namespace Senai.AutoPecas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private IPecasRepository PecasRepository { get; set; }

        public PecasController()
        {
            PecasRepository = new PecasRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PecasRepository.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Pecas peca = PecasRepository.BuscarPorId(id);
            if (peca == null)
            {
                return NotFound();
            }
            int idBuscadoUsuario = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "FornecedorId").Value);
            if (idBuscadoUsuario == peca.FornecedorId)
            {
                return Ok(peca);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Cadastrar(Pecas peca)
        {
            PecasRepository.Cadastrar(peca);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Pecas peca)
        {
            PecasRepository.Atualizar(peca);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PecasRepository.Deletar(id);
            return Ok();
        }
    }
}