using Microsoft.EntityFrameworkCore;
using WebApi.DataContext;
using WebApi.Models;

namespace WebApi.Service.FuncionarioService
{
    public class FuncionariService : IFuncionarioInterface

    {
        private ApplicationDbContext _context;
        public FuncionariService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponde = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if(novoFuncionario == null)
                {
                    serviceResponde.Dados = null;
                    serviceResponde.Mensagem = "Informar dados";
                    serviceResponde.Sucesso = false;

                }
                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();
                serviceResponde.Dados = _context.Funcionarios.ToList();


            }
            catch (Exception ex)
            {
                serviceResponde.Mensagem = ex.Message;
                serviceResponde.Sucesso = false;
            }
            return serviceResponde;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponde = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
                serviceResponde.Dados = _context.Funcionarios.ToList();


            }
            catch (Exception ex)
            {
                serviceResponde.Mensagem = ex.Message;
                serviceResponde.Sucesso = false;
            }
            return serviceResponde;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse <FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel> ();

            try
            {
                FuncionarioModel funcionario =  _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                serviceResponse.Dados = funcionario;
                if(funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado";
                    serviceResponse.Sucesso = false;
                }

            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }       


        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionaro(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if(funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado";
                    serviceResponse.Sucesso = false;
                }
                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Funcionarios.ToList();


            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdteEditarFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);

                if(funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado";
                    serviceResponse.Sucesso = false;
                }

                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();

            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
        
      

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                // vai trazer a mensagem buscando os dados no meu banco de dados representado pro context.Funcionarios que é minha tabela Tolist(LISTA TODOS OS FUNCIONARIDOS);
                serviceResponse.Dados = _context.Funcionarios.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrato!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}






