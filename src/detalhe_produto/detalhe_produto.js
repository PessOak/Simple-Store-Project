function changeImage(element) {
    var mainImage = document.getElementById('main-image');
    mainImage.src = element.src;
}

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
