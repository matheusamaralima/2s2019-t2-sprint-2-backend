﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        EstudioRepository EstudiosRepository = new EstudioRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(EstudiosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                EstudiosRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro :(" + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estudios Estudio = EstudiosRepository.BuscarPorId(id);
            if (Estudio == null)
                return NotFound();
            return Ok(Estudio);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstudiosRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Estudios estudio)
        {
            EstudiosRepository.Atualizar(estudio);
            return Ok();
        }
    }
}