document.addEventListener("DOMContentLoaded", function () {
    const freteFixo = 19.99;

    function atualizarResumo() {
        let subtotal = 0;

        document.querySelectorAll('.cart-item').forEach(function (item) {
            const precoUnitario = parseFloat(item.querySelector('[data-preco]').getAttribute('data-preco'));
            const quantidade = parseInt(item.querySelector('.quantidade').value);
            subtotal += precoUnitario * quantidade;
        });

        document.getElementById('subtotal').textContent = `R$ ${subtotal.toLocaleString("pt-BR", { minimumFractionDigits: 2 })}`;
        const total = subtotal + freteFixo;
        document.getElementById('total').textContent = `R$ ${total.toLocaleString("pt-BR", { minimumFractionDigits: 2 })}`;
    }

    document.addEventListener("change", function (event) {
        if (event.target.matches(".quantidade")) {
            if (event.target.value < 1) event.target.value = 1;
            atualizarResumo();
        }
    });

    document.addEventListener("click", function (event) {
        if (event.target.matches(".btn-outline-danger")) {
            event.target.closest(".cart-item").remove();
            atualizarResumo();
        }
    });

    atualizarResumo();
});
