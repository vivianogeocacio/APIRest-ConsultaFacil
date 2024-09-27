using apirest.Services;
using apirest.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace apirest.Controllers
{
    public class ConsultasController : BaseController<Consulta, IConsultaService>
    {
        private readonly IMapper _mapper;
        private readonly IConsultaService _userService;

        public ConsultasController(IConsultaService service, IMapper mapper) : base(service)
        {
            _mapper = mapper;
            _userService = service;
        }

        [Authorize(Roles = "Administrador, Medico, Paciente")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var test =  await base.GetAll(page, pageSize);
            return test;
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public override async Task<ActionResult> GetById(int id)
        {
            return await base.GetById(id);
        }

        [Authorize(Roles = "Administrador, Medico")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> Create([FromBody] Consulta entity)
        {
            return await base.Create(entity);
        }

        [Authorize(Roles = "Administrador, Paciente, Medico")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> Update(int id, [FromBody] Consulta entity)
        {
            return await base.Update(id, entity);
        }

        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}
