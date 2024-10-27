using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

public class PerfilService : IPerfilService
{
    private readonly IPerfilRepository _perfilRepository;

    public PerfilService(IPerfilRepository perfilRepository)
    {
        _perfilRepository = perfilRepository;
    }

    // Método para obter os detalhes do comprador
    public PerfilViewModel GetCompradorDetails(string cpf)
    {
        var perfil = _perfilRepository.GetCompradorDetails(cpf);
        if (perfil == null)
        {
            throw new Exception("Perfil não encontrado.");
        }
        return perfil;
    }

    // Método para atualizar os detalhes do comprador
    public bool UpdateCompradorDetails(PerfilViewModel model)
    {
        if (string.IsNullOrWhiteSpace(model.NomeComp))
        {
            throw new ArgumentException("O nome não pode ser vazio.");
        }

        var updateResult = _perfilRepository.UpdateCompradorDetails(model);
        if (!updateResult)
        {
            throw new Exception("Falha ao atualizar o perfil.");
        }
        return updateResult;
    }
}

public interface IPerfilService
{
    PerfilViewModel GetCompradorDetails(string cpf);
    bool UpdateCompradorDetails(PerfilViewModel model);
}