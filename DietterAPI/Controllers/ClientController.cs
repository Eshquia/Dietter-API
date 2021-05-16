using DataAccess.DataCast;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Services;
using Services.Services.ClientService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DietterAPI.Controllers
{
      [Route("api/[controller]")]
      [ApiController]
    public class ClientController : ControllerBase
      {
        private readonly IClientService _service;
        private readonly ILogger _logger;
        public ClientController(IClientService service, ILogger logservice)
        {
            _service = service;
            _logger = logservice;
        }
          [Route("Clients")]
          [HttpGet]
          public IActionResult GetClients()
          {
              try
              {
                var clients=_service.GetClientList();
                var result = new Result<List<ClientDto>>();
                result.Data = clients;
                result.Success = true;
                 return Ok(result);
              }
              catch(Exception e)
              {
                var result = new Result<List<ClientDto>>();
                result.Data = null;
                result.Success = false;
                _logger.Warning("Kullanıcı clientları alırken bir hata aldı",e);
                return NotFound(result);
               
              }
          }

          [Route("Client/{id}")]
          [HttpGet]
          public IActionResult GetClient(int id)
          {
            try
            {
                var client = _service.GetClient(id);
                var result = new Result<ClientDto>();
                result.Data = client;
                result.Success = true;
                return Ok(result);
            }
            catch (Exception e)
            {
                var result = new Result<ClientDto>();
                result.Data = null;
                result.Success = false;
                _logger.Warning("Kullanıcı Clientı alırken bir hata aldı", e);
                return NotFound(result);

            }
        }


          [HttpPost]
          [Route("postClient")]
          public IActionResult Post( ClientDto client)
          {
            try
            {
                var newclient = _service.PostClient(client);
                var result = new Result<bool>();
                result.Data = newclient;
                result.Success = true;
                return Ok(result);
            }
            catch (Exception e)
            {
                var result = new Result<bool>();
                result.Data = false;
                result.Success = false;
                _logger.Warning("Kullanıcı clientı eklerken bir hata aldı", e);
                return NotFound(result);

            }
        }


        [HttpPost]
        [Route("createDiet")]
        public IActionResult CreateDiet(Diet diet)
        {
            try
            {
                var newList = _service.CreateDiet(diet);
                var result = new Result<List<List<DietList>>>();
                result.Data = newList;
                result.Success = true;
                return Ok(result);
            }
            catch (Exception e)
            {
                var result = new Result<bool>();
                result.Data = false;
                result.Success = false;
                _logger.Warning("Kullanıcı liste oluştururken  bir hata aldı", e);
                return NotFound(result);

            }
        }



        [HttpDelete("{id}")]
          public IActionResult Delete(int id)
          {
            try
            {
                var delete = _service.DeleteClient(id);
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
                _logger.Warning("Kullanıcı clientı silerken alırken bir hata aldı", e);
                return NotFound(e);

            }
        }

        [HttpPut]
        [Route("putClient")]
        public IActionResult Put(ClientDto client)
        {
            try
            {
                var updateClient = _service.PutClient(client);
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
                _logger.Warning("Kullanıcı Client'ı güncellerken bir hata aldı", e);
                return NotFound(result);

            }
        }

    } 
}
