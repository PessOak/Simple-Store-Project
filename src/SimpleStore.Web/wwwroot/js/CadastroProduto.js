const form = document.getElementById('product-form');
const productContainer = document.getElementById('product-container');
const searchInput = document.getElementById('search-input');

form.addEventListener('submit', function (e) {
    e.preventDefault(); // Impede o envio do formulário

    const name = document.getElementById('product-name').value;
    const description = document.getElementById('product-description').value;
    const price = document.getElementById('product-price').value;
    const category = document.getElementById('product-category').value;
    const stock = document.getElementById('product-stock').value;
    const minStock = document.getElementById('product-min-stock').value;
    const maxStock = document.getElementById('product-max-stock').value;
    const imageFile = document.getElementById('product-image').files[0];

    if (!imageFile) {
        alert('Por favor, insira uma imagem.');
        return;
    }

    const imageURL = URL.createObjectURL(imageFile);

    // Cria um novo card
    const card = document.createElement('div');
    card.classList.add('card', 'mb-3');
    card.innerHTML = `
        <img src="${imageURL}" class="card-img-top" alt="${name}">
        <div class="card-body">
            <h5 class="card-title">${name}</h5>
            <p class="card-text">${description}</p>
            <p><strong>R$ ${price}</strong></p>
            <p>Categoria: ${category}</p>
            <p>Estoque disponível: ${stock}</p>
            <p>Estoque mínimo: ${minStock}, máximo: ${maxStock}</p>
            <button class="remove-btn">remover;</button>
            <button class="edit-btn">Editar</button>
        </div>
    `;

    // Adiciona funcionalidade de remoção
    card.querySelector('.remove-btn').addEventListener('click', function () {
        card.remove();
    });

    // Adiciona funcionalidade de edição
    card.querySelector('.edit-btn').addEventListener('click', function () {
        document.getElementById('product-name').value = name;
        document.getElementById('product-description').value = description;
        document.getElementById('product-price').value = price;
        document.getElementById('product-category').value = category;
        document.getElementById('product-stock').value = stock;
        document.getElementById('product-min-stock').value = minStock;
        document.getElementById('product-max-stock').value = maxStock;

        card.remove();
    });

    // Adiciona o card ao container
    productContainer.appendChild(card);

    // Limpa o formulário após adicionar o produto
    form.reset();
});

// Função de busca
searchInput.addEventListener('input', function () {
    const searchTerm = searchInput.value.toLowerCase();
    const cards = document.querySelectorAll('.card');

    cards.forEach(card => {
        const title = card.querySelector('.card-title').textContent.toLowerCase();
        const description = card.querySelector('.card-text').textContent.toLowerCase();
        const price = card.querySelector('strong').textContent.toLowerCase();

        if (title.includes(searchTerm) || description.includes(searchTerm) || price.includes(searchTerm)) {
            card.style.display = 'block';
        } else {
            card.style.display = 'none';
        }
    });
});