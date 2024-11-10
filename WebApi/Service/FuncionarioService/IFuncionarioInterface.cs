using WebApi.Models;

namespace WebApi.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        // buscar todos
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();

        //inserir
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);

        // buscar por ID
        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);

        //update

        Task<ServiceResponse<List<FuncionarioModel>>> UpdteEditarFuncionario(FuncionarioModel funcionario);

        // deletar 
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);


        //inativar funcionaro

        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionaro(int id );
    }
}
