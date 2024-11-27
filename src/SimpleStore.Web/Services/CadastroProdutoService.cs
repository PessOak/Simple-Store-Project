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

        public async Task<bool> SalvarProdutoAsync(Produto produto)
        {
            try
            {
                if (produto == null) throw new ArgumentNullException(nameof(produto));

                Console.WriteLine("Preparando para salvar o produto...");

                // Processar a imagem se for enviada via formulário
                if (produto.ImagemProduto != null)
                {
                    produto.ImgUrl = await SalvarImagemAsync(produto.ImagemProduto);
                }

                Console.WriteLine("Chamando o repositório para salvar o produto...");
                var produtoId = await _cadastroProdutoRepository.AdicionarProdutoAsync(produto);

                Console.WriteLine($"Produto salvo com ID: {produtoId}");
                return produtoId > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar produto: {ex.Message}");
                return false;
            }
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
