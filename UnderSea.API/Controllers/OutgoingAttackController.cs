using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutgoingAttackController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<OutgoingAttackViewModel>> Get()
        {
            return NotFound(new List<OutgoingAttackViewModel>());
        }

    }
}
