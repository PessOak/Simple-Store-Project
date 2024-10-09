function changeImage(element) {
    // Pega o caminho da imagem clicada
    const newSrc = element.src.replace("150", "600"); // Substitui a resolução da imagem pequena pela grande
    // Define a nova imagem no elemento principal
    document.getElementById('main-image').src = newSrc;
}

// Carrega a primeira imagem como principal ao carregar a página
window.onload = function () {
    const firstImage = document.getElementById('img1');
    changeImage(firstImage);  // Faz com que a primeira imagem seja carregada como principal
};

function increaseQuantity() {
    const quantityInput = document.getElementById('product-quantity');
    quantityInput.value = parseInt(quantityInput.value) + 1;
}

function decreaseQuantity() {
    const quantityInput = document.getElementById('product-quantity');
    if (quantityInput.value > 1) {
        quantityInput.value = parseInt(quantityInput.value) - 1;
    }
}