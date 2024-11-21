// Capturar o formulário de pesquisa e adicionar evento de envio
document.getElementById('formPesquisa').addEventListener('submit', function (event) {
    event.preventDefault(); // Evita o envio do formulário

const termoPesquisa = document.getElementById('inputPesquisa').value.toLowerCase().trim();
const produtos = document.querySelectorAll('.produto'); // Todos os produtos exibidos

    produtos.forEach(produto => {
        const nome = produto.getAttribute('data-nome').toLowerCase();

// Verifica se o termo de pesquisa está presente no nome ou descrição
if (nome.includes(termoPesquisa)) {
    produto.style.display = 'block'; // Exibe o produto
        } 

else {
    produto.style.display = 'none'; // Oculta o produto
        }

    });
});

