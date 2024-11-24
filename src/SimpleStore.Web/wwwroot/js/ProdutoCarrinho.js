document.getElementById('adicionar-carrinho').addEventListener('click', function (event) {
    event.preventDefault(); // Previne o envio padrão do formulário

    const form = document.getElementById('form-adicionar-carrinho');
    const formData = new FormData(form);

    fetch('/ProdutoCarrinho/AdicionarAoCarrinho', {
        method: 'POST',
        body: formData
    })
        .then(response => {
            if (response.ok) {
                alert('Produto adicionado ao carrinho!');
                setTimeout(() => alertDiv.remove(), 3000);

            } else {
                alert('Erro ao adicionar o produto ao carrinho.');
            }
        })
        .catch(error => console.error('Erro de rede:', error));
});
