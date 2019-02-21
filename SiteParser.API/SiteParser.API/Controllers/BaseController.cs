using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteParser.API.Context;
using SiteParser.API.Models;
using Microsoft.AspNetCore.Cors;
using SiteParser.API.IRepositories;
using SiteParser.API.Repositories;

namespace SiteParser.API.Controllers
{
    [Route("api/base")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IBaseRepository _baseRepository;

        public BaseController(IBaseRepository baseRepository)
        {
            this._baseRepository = baseRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultModel>>> GetResult()
        {
            IEnumerable<ResultModel> result = await _baseRepository.GetResultsAsync();
            _baseRepository.Save();
            return Ok(result);
        }

        [HttpPost]
        public async Task Calculate(BaseModel item)
        {
            await _baseRepository.ParserResult(item);
        }

    }
}