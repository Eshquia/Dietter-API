using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.DataCast;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Services.Services.ListService;

namespace DietterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService _service;
        private readonly ILogger _logger;
        public ListController(IListService service, ILogger logservice)
        {
            _service = service;
            _logger = logservice;
        }

        [Route("getList")]
        [HttpGet]
        public IActionResult GetLists()
        {
            try
            {
                var list = _service.GetLists();
                var result = new Result<List<ListDto>>();
                result.Data = list;
                result.Success = true;
                return Ok(result);
            }
            catch (Exception e)
            {
                var result = new Result<List<ListDto>>();
                result.Data = null;
                result.Success = false;
                _logger.Warning("Kullanıcı Listeleri alırken bir hata aldı", e);
                return NotFound(result);

            }
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetList(int id)
        {

            try
            {
                var list = _service.GetList(id);
                var result = new Result<ListDto>();
                result.Data = list;
                result.Success = true;
                return Ok(result);
            }
            catch (Exception e)
            {
                var result = new Result<ListDto>();
                result.Data = null;
                result.Success = false;
                _logger.Warning("Kullanıcı list alırken bir hata aldı", e);
                return NotFound(result);

            }

        }

        [HttpPost]
        [Route("postList")]
        public IActionResult PostList([FromBody]ListDto list)
        {
            try
            {
                var newList = _service.PostList(list);
                var result = new Result<bool>();
                result.Data = newList;
                result.Success = true;
                return Ok(result);
            }
            catch (Exception e)
            {
                var result = new Result<bool>();
                result.Data = false;
                result.Success = false;
                _logger.Warning("Kullanıcı list eklerken bir hata aldı", e);
                return NotFound(result);

            }
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeleteList(int id)
        {
            try
            {
                var delete = _service.DeleteList(id);
                var result = new Result<bool>();
                result.Data = delete;
                result.Success = true;
                return Ok(result);
            }
            catch (Exception e)
            {

                var result = new Result<bool>();
                result.Data = false;
                result.Success = false;
                _logger.Warning("Kullanıcı list silerken alırken bir hata aldı", e);
                return NotFound(e);

            }



        }
    }
}
