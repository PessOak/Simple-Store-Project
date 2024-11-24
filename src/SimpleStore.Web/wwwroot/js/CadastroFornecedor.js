document.addEventListener('DOMContentLoaded', () => {
    const telefoneInput = document.getElementById('telefone');

    telefoneInput.addEventListener('input', (e) => {
        let value = e.target.value.replace(/\D/g, ''); // Remove caracteres não numéricos
        e.target.value = value;

        if (value.length > 11) {
            value = value.slice(0, 11); // Limita a 11 caracteres
        }

        // Formata como celular ou fixo
        if (value.length > 10) {
            e.target.value = `(${value.slice(0, 2)}) ${value.slice(2, 3)} ${value.slice(3, 7)}-${value.slice(7)}`;
        } else if (value.length > 6) {
            e.target.value = `(${value.slice(0, 2)}) ${value.slice(2, 6)}-${value.slice(6)}`;
        } else if (value.length > 2) {
            e.target.value = `(${value.slice(0, 2)}) ${value.slice(2)}`;
        } else if (value.length > 0) {
            e.target.value = `(${value}`;
        }
    });
});

function buscarEndereco() {
    const cep = document.getElementById('cep');

    if (cep.value.length !== 8 || isNaN(cep.value)) {
        alert('Por favor, digite um CEP válido com 8 dígitos.');
        return;
    }

    const url = `https://viacep.com.br/ws/${cep.value.replace(/\D/g, "")}/json/`;

    fetch(url)
        .then(response => response.json())
        .then(data => {
            if (data.erro) {
                alert('CEP não encontrado!');
                return;
            }

            document.getElementById('logradouro').value = data.logradouro;
            document.getElementById('bairro').value = data.bairro;
            document.getElementById('cidade').value = data.localidade;
            document.getElementById('estado').value = data.uf;
        })
        .catch(error => {
            alert('Erro ao buscar o endereço!');
            console.error('Erro:', error);
        });
}

function verificarCep(event) {
    const cep = document.getElementById('cep');
    if (cep.value.length === 9 || event.key === "Enter") {
        buscarEndereco();
    }
}