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

function verificarEnter(event) {
    if (event.key === "Enter") {
        buscarEndereco();
    }
}