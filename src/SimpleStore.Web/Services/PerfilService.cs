using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Services;

namespace SimpleStore.Web.Services {
public class PerfilService
{
    private readonly PerfilRepository _perfilRepository;

    public PerfilService(PerfilRepository perfilRepository)
    {
        _perfilRepository = perfilRepository;
    }

    // Método para obter os detalhes do comprador
    public Perfil BuscarDadosComprador(string cpf)
    {
        var perfil = _perfilRepository.BuscarDadosComprador(cpf);
        if (perfil == null)
        {
            throw new Exception("Perfil não encontrado.");
        }
        return perfil;
    }

    // Método para atualizar os detalhes do comprador
    public bool AtualizarDadosComprador(Comprador dados)
    {
        if (string.IsNullOrWhiteSpace(dados.NomeComp))
        {
            throw new ArgumentException("O nome não pode ser vazio.");
        }

        var AtualizarDados = _perfilRepository.AtualizarDadosComprador(dados);
        if (!AtualizarDados)
        {
            throw new Exception("Falha ao atualizar o perfil.");
        }
        return AtualizarDados;
    }
}

//public interface PerfilService
//{
//    Comprador BuscarComprador(string cpf);
//    bool AtualizarDadosComprador(Comprador dados);
//}

}