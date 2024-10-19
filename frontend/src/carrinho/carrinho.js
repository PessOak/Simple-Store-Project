<script>
document.addEventListener("DOMContentLoaded", function () {
    // Define o valor do frete
    const freteFixo = 19.99;

    // Função para calcular o subtotal e o total
    function atualizarResumo() {
        let subtotal = 0;

        // Seleciona todos os produtos no carrinho
        document.querySelectorAll('.cart-item').forEach(function (item) {
            const precoUnitario = parseFloat(item.getAttribute('data-preco'));
            const quantidade = parseInt(item.querySelector('.quantidade').value);

            // Soma o preço total por produto
            subtotal += precoUnitario * quantidade;
        });

        // Atualiza o subtotal no resumo do pedido
        document.getElementById('subtotal').textContent = subtotal.toFixed(2);

        // Atualiza o total (subtotal + frete)
        const total = subtotal + freteFixo;
        document.getElementById('total').textContent = total.toFixed(2);
    }

    // Detecta mudanças na quantidade dos produtos
    document.querySelectorAll('.quantidade').forEach(function (input) {
        input.addEventListener('change', function () {
            if (input.value < 1) input.value = 1;  // Garante que a quantidade mínima seja 1
            atualizarResumo();
        })
    });

    // Detecta quando um item é removido
    document.querySelectorAll('.remover-item').forEach(function (button) {
        button.addEventListener('click', function () {
            button.closest('.cart-item').remove(); // Remove o produto do carrinho
            atualizarResumo(); // Recalcula o total após a remoção
        })
    });

    // Inicializa o resumo com os valores atuais
    atualizarResumo();
})
</script>
