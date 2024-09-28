using apirest.Services;
using apirest.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace apirest.Controllers
{
    public class MedicosController : BaseController<Medico, IMedicoService>
    {
        public MedicosController(IMedicoService service) : base(service)
        {
            
        }

        [Authorize(Roles = "Administrador, Medico")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var test = await base.GetAll(page, pageSize);
            return test;
        }

        [Authorize(Roles = "Administrador, Medico")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public override async Task<ActionResult> GetById(int id)
        {
            return await base.GetById(id);
        }

        [Authorize(Roles = "Administrador, Medico")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> Create([FromBody] Medico entity)
        {
            return await base.Create(entity);
        }

        [Authorize(Roles = "Administrador, Medico")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> Update(int id, [FromBody] Medico entity)
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
