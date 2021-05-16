using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.DataCast;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using service;

namespace DietterAPI.Controllers
{   //ToDo:Tüm controller result dönüşüne çevrilecek
    [Route("api")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IDietService _service;
        private readonly ILogger _logger;
        public FoodController(IDietService service, ILogger logservice)
        {
            _service = service;
            _logger = logservice;
        }

        [Route("Foods")]
        [HttpGet]
        public IActionResult GetFoods()
        {

            try
            {
                var food = _service.GetFoods();
                var result = new Result<List<FoodDto>>();
                result.Data = food;
                result.Success = true;
                return Ok(result);
            }
            catch (Exception e)
            {
                var result = new Result<List<FoodDto>>();
                result.Data = null;
                result.Success = false;
                _logger.Warning("Kullanıcı besinleri alırken bir hata aldı", e);
                return NotFound(result);

            }


        }
          [Route("Foods/{id}")]
          [HttpGet]
          public IActionResult GetFood(int id)
          {
            try
            {
                var food = _service.GetFood(id);
                return Ok(food);
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }
        
          [HttpPost]
          [Route("PostFood")]
          public IActionResult postFood([FromBody]FoodDto food)
          {
            try
            {
                var newfood = _service.PostFood(food);
                var result = new Result<bool>();
                result.Data = newfood;
                result.Success = true;
                return Ok(result);
            }
            catch (Exception e)
            {
                var result = new Result<bool>();
                result.Data = false;
                result.Success = false;
                _logger.Warning("Kullanıcı besin eklerken  bir hata aldı", e);
                return NotFound(result);

            }

          }
        
          [Route("Foods/{id}")]
          [HttpDelete]
          public IActionResult DeleteFood(int id)
          {

            try
            {
                var delete = _service.DeleteFood(id);
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
                _logger.Warning("Kullanıcı besini silerken alırken bir hata aldı", e);
                return NotFound(e);

            }
        }

        [HttpPut]
        [Route("putFood")]
        public IActionResult Put(FoodDto food)
        {
            try
            {
                var updateClient = _service.PutFood(food);
                var result = new Result<bool>();
                result.Data = updateClient;
                result.Success = true;
                return Ok(result);
            }
            catch (Exception e)
            {
                var result = new Result<bool>();
                result.Data = false;
                result.Success = false;
                _logger.Warning("kullanıcı Client'ı güncellerken bir hata aldı", e);
                return NotFound(result);

            }
        }




    }
}
