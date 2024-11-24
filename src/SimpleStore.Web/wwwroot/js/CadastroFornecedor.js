document.addEventListener('DOMContentLoaded', () => {
    verificarCep();

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

    const cepInput = document.getElementById('cep');

    cepInput.addEventListener('input', function (e) {
        let value = e.target.value.replace(/\D/g, ''); // Remove caracteres não numéricos

        if (value.length > 9) {
            value = value.slice(0, 9); // Limita a 9 caracteres
        }

        // Formata o CEP
        if (value.length > 5) {
            e.target.value = `${value.slice(0, 5)}-${value.slice(5)}`;
        } else {
            e.target.value = value;
        }
    });

    const cnpjInput = document.getElementById('cnpj');

    cnpjInput.addEventListener('input', function (e) {
        let value = e.target.value.replace(/\D/g, ''); // Remove caracteres não numéricos

        if (value.length > 18) {
            value = value.slice(0, 18); // Limita a 14 caracteres
        }

        // Formata como CNPJ (##.###.###/####-##)
        if (value.length > 12) {
            e.target.value = `${value.slice(0, 2)}.${value.slice(2, 5)}.${value.slice(5, 8)}/${value.slice(8, 12)}-${value.slice(12, 14)}`;
        } else if (value.length > 8) {
            e.target.value = `${value.slice(0, 2)}.${value.slice(2, 5)}.${value.slice(5, 8)}/${value.slice(8)}`;
        } else if (value.length > 5) {
            e.target.value = `${value.slice(0, 2)}.${value.slice(2, 5)}.${value.slice(5)}`;
        } else if (value.length > 2) {
            e.target.value = `${value.slice(0, 2)}.${value.slice(2)}`;
        } else {
            e.target.value = value;
        }
    });

    const senhaInput = document.getElementById('senha');
    const confirmarSenhaInput = document.getElementById('confirmarSenha');

    const mostrarSenhaCheckbox = document.getElementById('mostrarSenha');
    const mostrarConfirmarSenhaCheckbox = document.getElementById('mostrarConfirmarSenha');

    mostrarSenhaCheckbox.addEventListener('change', () => {
        if (mostrarSenhaCheckbox.checked) {
            senhaInput.type = 'text';
        } else {
            senhaInput.type = 'password';
        }

    });

    mostrarConfirmarSenhaCheckbox.addEventListener('change', () => {
        if (mostrarConfirmarSenhaCheckbox.checked) {
            confirmarSenhaInput.type = 'text';
        } else {
            confirmarSenhaInput.type = 'password';
        }
    });
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