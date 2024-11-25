document.addEventListener('DOMContentLoaded', () => {
    verificarCep();
    aplicarMascaras();
});

function buscarEndereco() {

    const cepInput = document.getElementById('cep');

    const cep = cepInput.value.replace(/\D/g, "");

    if (cep.length !== 8 || isNaN(cep)) {
        console.log("CEP inválido");
        alert('Por favor, digite um CEP válido com 8 dígitos.');
        return;
    }

    const url = `https://viacep.com.br/ws/${cep}/json/`;

    fetch(url)
        .then((response) => {
            if (!response.ok) {
                throw new Error("Erro ao buscar o endereço.");
            }
            return response.json();
        })
        .then((data) => {
            if (data.erro) {
                alert("CEP não encontrado!");
                return;
            }

            document.getElementById("logradouro").value = data.logradouro || "";
            document.getElementById("bairro").value = data.bairro || "";
            document.getElementById("cidade").value = data.localidade || "";
            document.getElementById("estado").value = data.uf || "";
        })
        .catch((error) => {
            alert("Erro ao buscar o endereço!");
            console.error("Erro:", error);
        });
}

function verificarCep(event) {
    const cep = document.getElementById('cep');
    if (cep.value.length === 9 || event?.key === "Enter") {
        buscarEndereco();
    }
}