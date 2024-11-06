using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FerreteriaSur.Server.Models;
using FerreteriaSur.Server.Repositorio.Contrato;
using FerreteriaSur.Shared;

namespace FerreteriaSur.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadMedidaController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUnidadMedidaRepositorio _unidadMedidaRepositorio;
        public UnidadMedidaController(IUnidadMedidaRepositorio unidadMedidaRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _unidadMedidaRepositorio = unidadMedidaRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<UnidadMedidaDTO>> _ResponseDTO = new ResponseDTO<List<UnidadMedidaDTO>>();

            try
            {
                List<UnidadMedidaDTO> ListaUnidades = new List<UnidadMedidaDTO>();
                //IQueryable<UnidadMedida> query = await _unidadMedidaRepositorio.Consultar();
                //query = query.Include(r => r.IdCategoriaNavigation);

                //ListaUnidades = _mapper.Map<List<UnidadMedidaDTO>>(query.ToList());

                if (ListaUnidades.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<UnidadMedidaDTO>>() { status = true, msg = "ok", value = ListaUnidades };
                else
                    _ResponseDTO = new ResponseDTO<List<UnidadMedidaDTO>>() { status = false, msg = "", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<UnidadMedidaDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] UnidadMedidaDTO request)
        {
            ResponseDTO<UnidadMedidaDTO> _ResponseDTO = new ResponseDTO<UnidadMedidaDTO>();
            try
            {
                UnidadMedida _unidadMedida = _mapper.Map<UnidadMedida>(request);

                UnidadMedida _unidadMedidaCreada = await _unidadMedidaRepositorio.Crear(_unidadMedida);

                if (_unidadMedidaCreada.IdUnidad != 0)
                    _ResponseDTO = new ResponseDTO<UnidadMedidaDTO>() { status = true, msg = "ok", value = _mapper.Map<UnidadMedidaDTO>(_unidadMedidaCreada) };
                else
                    _ResponseDTO = new ResponseDTO<UnidadMedidaDTO>() { status = false, msg = "No se pudo crear el producto" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<UnidadMedidaDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] UnidadMedidaDTO request)
        {
            ResponseDTO<bool> _ResponseDTO = new ResponseDTO<bool>();
            try
            {
                UnidadMedida _unidadMedida = _mapper.Map<UnidadMedida>(request);
                UnidadMedida _unidadMedidaParaEditar = await _unidadMedidaRepositorio.Obtener(u => u.IdUnidad == _unidadMedida.IdUnidad);

                if (_unidadMedidaParaEditar != null)
                {

                    _unidadMedidaParaEditar.NombreUnidad = _unidadMedida.NombreUnidad;
                    _unidadMedidaParaEditar.IdUnidad = _unidadMedida.IdUnidad;
                    _unidadMedidaParaEditar.Simbolo = _unidadMedida.Simbolo;
                    _unidadMedidaParaEditar.Descripcion = _unidadMedida.Descripcion;
                    _unidadMedidaParaEditar.TipoUnidad = _unidadMedida.TipoUnidad;

                    bool respuesta = await _unidadMedidaRepositorio.Editar(_unidadMedidaParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<bool>() { status = true, msg = "ok", value = true };
                    else
                        _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se pudo editar" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se encontró" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = ex.Message };
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
                UnidadMedida _unidadMedidaEliminar = await _unidadMedidaRepositorio.Obtener(u => u.IdUnidad == id);

                if (_unidadMedidaEliminar != null)
                {

                    bool respuesta = await _unidadMedidaRepositorio.Eliminar(_unidadMedidaEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar", value = "" };
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
