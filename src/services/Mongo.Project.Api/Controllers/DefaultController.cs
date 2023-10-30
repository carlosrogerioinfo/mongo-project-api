using Crm.Mongo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mongo_webapi.Commands.Handler;

namespace mongo_webapi.Controllers
{
    [ApiController]
    [Route("default")]
    public class DefaultController : ControllerBase
    {
        private readonly DefaultCommandHandler _handler;

        public DefaultController(DefaultCommandHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Retorna as informações dos produtos cadastrados.
        /// </summary>
        /// <response code="200">As informações dos produtos cadastrados retornados com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpGet, Route("products/get"), AllowAnonymous]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _handler.Handle();
        }
    }
}