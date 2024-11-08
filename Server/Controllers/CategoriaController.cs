﻿using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FerreteriaSur.Server.Repositorio.Contrato;
using FerreteriaSur.Shared;
using FerreteriaSur.Server.Repositorio.Implementacion;
using FerreteriaSur.Server.Models;

namespace FerreteriaSur.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaController(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<CategoriaDTO>> _response = new ResponseDTO<List<CategoriaDTO>>();

            try
            {
                List<CategoriaDTO> _listaCategorias = new List<CategoriaDTO>();
                _listaCategorias = _mapper.Map<List<CategoriaDTO>>(await _categoriaRepositorio.Lista());

                if (_listaCategorias.Count > 0)
                    _response = new ResponseDTO<List<CategoriaDTO>>() { status = true, msg = "ok", value = _listaCategorias };
                else
                    _response = new ResponseDTO<List<CategoriaDTO>>() { status = false, msg = "sin resultados", value = null };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseDTO<List<CategoriaDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] CategoriaDTO request)
        {
            ResponseDTO<CategoriaDTO> _ResponseDTO = new ResponseDTO<CategoriaDTO>();
            try
            {
                Categoria _categoria = _mapper.Map<Categoria>(request);

                Categoria _categoriaCreada = await _categoriaRepositorio.Crear(_categoria);

                if (_categoriaCreada.IdCategoria != 0)
                    _ResponseDTO = new ResponseDTO<CategoriaDTO>() { status = true, msg = "ok", value = _mapper.Map<CategoriaDTO>(_categoriaCreada) };
                else
                    _ResponseDTO = new ResponseDTO<CategoriaDTO>() { status = false, msg = "No se pudo crear la categoria" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<CategoriaDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO request)
        {
            ResponseDTO<CategoriaDTO> _ResponseDTO = new ResponseDTO<CategoriaDTO>();
            try
            {
                Categoria _categoria = _mapper.Map<Categoria>(request);
                Categoria _categoriaParaEditar = await  _categoriaRepositorio.Obtener(u => u.IdCategoria == _categoria.IdCategoria);

                if (_categoriaParaEditar != null)
                {

                    _categoriaParaEditar.NombreCategoria = _categoria.NombreCategoria;


                    bool respuesta = await _categoriaRepositorio.Editar(_categoriaParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<CategoriaDTO>() { status = true, msg = "ok", value = _mapper.Map<CategoriaDTO>(_categoriaParaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<CategoriaDTO>() { status = false, msg = "No se pudo editar el usuario" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<CategoriaDTO>() { status = false, msg = "No se encontró el usuario" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<CategoriaDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            ResponseDTO<string> _ResponseDTO = new ResponseDTO<string>();
            try
            {
                Categoria _categoriaEliminar = await _categoriaRepositorio.Obtener(u => u.IdCategoria == id);

                if (_categoriaEliminar != null)
                {

                    bool respuesta = await _categoriaRepositorio.Eliminar(_categoriaEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar la catg", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

    }
}
