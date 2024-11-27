using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class CadastroProdutoService
    {
        private readonly CadastroProdutoRepository _cadastroProdutoRepository;

        public CadastroProdutoService(CadastroProdutoRepository cadastroProdutoRepository)
        {
            _cadastroProdutoRepository = cadastroProdutoRepository;
        }

        public async Task<bool> SalvarProdutoAsync(CadastroProduto produto)
        {
            try
            {
                if (produto == null) throw new ArgumentNullException(nameof(produto));

                if (produto.ImagemProduto != null)
                {
                    produto.ImgUrl = await SalvarImagemAsync(produto.ImagemProduto);
                }

                var produtoId = await _cadastroProdutoRepository.AdicionarProdutoAsync(produto);
                return produtoId > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar produto: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> VerificarFornecedorAsync(int idForn)
        {
            return await _cadastroProdutoRepository.FornecedorExisteAsync(idForn);
        }

        private async Task<byte[]> SalvarImagemAsync(IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
                throw new ArgumentException("Arquivo de imagem inválido.");

            using (var memoryStream = new MemoryStream())
            {
                await arquivo.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
