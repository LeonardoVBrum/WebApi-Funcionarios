using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Service.FuncionarioService;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioIterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioIterface = funcionarioInterface;
        }


        //Listar todos funcionarios
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            return Ok(await _funcionarioIterface.GetFuncionarios());
        }

        //buscar funcionario por ID
        [HttpGet("{id}")]

        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id)
        {

            ServiceResponse<FuncionarioModel> serviceResponde = await _funcionarioIterface.GetFuncionarioById(id);
            return serviceResponde;
        }
       
        //Criar funcionario
        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioIterface.CreateFuncionario(novoFuncionario));
        }

        // atualiza funcionario 
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdteEditarFuncionario(FuncionarioModel funcionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioIterface.UpdteEditarFuncionario(funcionario);

            return Ok(serviceResponse);
        }


        //Intaiva  Funcionario OBS: httpPUT faz updadte 
        [HttpPut("Inativa Funcionario")]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse =  await _funcionarioIterface.InativaFuncionaro(id);

            return Ok(serviceResponse);
        }

        [HttpDelete]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            return Ok(await _funcionarioIterface.DeleteFuncionario(id));
        }


    }
}
