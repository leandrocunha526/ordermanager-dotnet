using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ordermanager_dotnet.Data;
using ordermanager_dotnet.Models;

namespace ordermanager_dotnet.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsMachineController : Controller
    {
        public IRepository _repo{get;}
        public ModelsMachineController(IRepository repo){
            _repo = repo;
        }

        [HttpGet("list")]
        public async Task<IActionResult> Get(){
            try{
                var result = await _repo.GetAllModelAsync(true);
                return Ok(result);
            }
            catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Error code 500: Internal Server Error");
            }
        }

        [HttpGet("{ModelId}")]
        public async Task<IActionResult> GetModelById(int ModelId){
            try{
                var result = await _repo.GetModelAsyncById(ModelId, true);
                return Ok(result);
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Error code 500: Internal Server Error");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post(ModelMachine model){
            try{
                _repo.Add(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"/api/models/register/{model.Id}", model);
                }
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Error code 500: Internal Server Error");
            }
            return BadRequest();
        }

        [HttpPut("/edit/{ModelId}")]
        public async Task<IActionResult> Put(int ModelMachineId, ModelMachine model){
            try{
                var modelmachine = await _repo.GetModelAsyncById(ModelMachineId, false);
                if(modelmachine == null)
                return NotFound();
                _repo.Update(modelmachine);
                    if(await _repo.SaveChangesAsync()){
                        model = await _repo.GetModelAsyncById(ModelMachineId, true);
                        return Created($"/api/models/edit/{modelmachine.Id}", modelmachine);
                    }
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Error code 500: Internal Server Error");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int ModelMachineId){
            try{
                var modelmachine = await _repo.GetModelAsyncById(ModelMachineId, false);
                if(modelmachine == null)
                return NotFound();

                _repo.Delete(modelmachine);

                    if(await _repo.SaveChangesAsync()){
                        return Ok();
                    }
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Error code 500: Internal Server Error");
            }
            return BadRequest();
        }
    }
}
