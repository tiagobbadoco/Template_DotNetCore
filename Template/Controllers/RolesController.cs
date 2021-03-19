using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Interfaces;
using Template.Application.ViewModels;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(roleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(roleService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(RoleViewModel roleViewModel)
        {
            return Ok(roleService.Post(roleViewModel));
        }

        [HttpPut]
        public IActionResult Put(RoleViewModel roleViewModel)
        {
            return Ok(roleService.Put(roleViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(roleService.Delete(id));
        }
    }
}
