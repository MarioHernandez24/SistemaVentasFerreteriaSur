using AutoMapper;
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
    public class UnidadController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnidadRepositorio _unidadRepositorio;
        public UnidadController(IUnidadRepositorio unidadRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _unidadRepositorio = unidadRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<UnidadDTO>> _response = new ResponseDTO<List<UnidadDTO>>();

            try
            {
                List<UnidadDTO> _listaUnidad = new List<UnidadDTO>();
                _listaUnidad = _mapper.Map<List<UnidadDTO>>(await _unidadRepositorio.Lista());

                if (_listaUnidad.Count > 0)
                    _response = new ResponseDTO<List<UnidadDTO>>() { status = true, msg = "ok", value = _listaUnidad };
                else
                    _response = new ResponseDTO<List<UnidadDTO>>() { status = false, msg = "sin resultados", value = null };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseDTO<List<UnidadDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] UnidadDTO request)
        {
            ResponseDTO<UnidadDTO> _ResponseDTO = new ResponseDTO<UnidadDTO>();
            try
            {
                Unidad _unidad = _mapper.Map<Unidad>(request);

                Unidad _unidadCreada = await _unidadRepositorio.Crear(_unidad);

                if (_unidadCreada.IdUnidad != 0)
                    _ResponseDTO = new ResponseDTO<UnidadDTO>() { status = true, msg = "ok", value = _mapper.Map<UnidadDTO>(_unidadCreada) };
                else
                    _ResponseDTO = new ResponseDTO<UnidadDTO>() { status = false, msg = "No se pudo crear la categoria" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<UnidadDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] UnidadDTO request)
        {
            ResponseDTO<UnidadDTO> _ResponseDTO = new ResponseDTO<UnidadDTO>();
            try
            {
                Unidad _unidad = _mapper.Map<Unidad>(request);
                Unidad _unidadParaEditar = await _unidadRepositorio.Obtener(u => u.IdUnidad == _unidad.IdUnidad);

                if (_unidadParaEditar != null)
                {

                    _unidadParaEditar.Nombre = _unidad.Nombre;
                    _unidadParaEditar.Simbolo = _unidad.Simbolo;
                    _unidadParaEditar.Descripcion = _unidad.Descripcion;                    


                    bool respuesta = await _unidadRepositorio.Editar(_unidadParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<UnidadDTO>() { status = true, msg = "ok", value = _mapper.Map<UnidadDTO>(_unidadParaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<UnidadDTO>() { status = false, msg = "No se pudo editar el usuario" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<UnidadDTO>() { status = false, msg = "No se encontró el usuario" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<UnidadDTO>() { status = false, msg = ex.Message };
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
                Unidad _unidadEliminar = await _unidadRepositorio.Obtener(u => u.IdUnidad == id);

                if (_unidadEliminar != null)
                {

                    bool respuesta = await _unidadRepositorio.Eliminar(_unidadEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar la unidad", value = "" };
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
