// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function aplicarMascaras() {
    const telefoneInput = document.getElementById('telefone');
    aplicarMascaraTelefone();
    telefoneInput?.addEventListener('input', () => {
        aplicarMascaraTelefone();
    });

    const cepInput = document.getElementById('cep');
    aplicarMascaraCep();
    cepInput?.addEventListener('input', () => {
        aplicarMascaraCep();
    });

    const cpfInput = document.getElementById('cpf');
    aplicarMascaraCpf();
    cpfInput?.addEventListener('input', () => {
        aplicarMascaraCpf();
    });
}

function aplicarMascaraTelefone() {
    const telefoneInput = document.getElementById('telefone');
    let value = telefoneInput.value.replace(/\D/g, ''); // Remove caracteres não numéricos
    telefoneInput.value = value;

    if (value.length > 11) {
        value = value.slice(0, 11); // Limita a 11 caracteres
    }

    // Formata como celular ou fixo
    if (value.length > 10) {
        telefoneInput.value = `(${value.slice(0, 2)}) ${value.slice(2, 3)} ${value.slice(3, 7)}-${value.slice(7)}`;
    } else if (value.length > 6) {
        telefoneInput.value = `(${value.slice(0, 2)}) ${value.slice(2, 6)}-${value.slice(6)}`;
    } else if (value.length > 2) {
        telefoneInput.value = `(${value.slice(0, 2)}) ${value.slice(2)}`;
    } else if (value.length > 0) {
        telefoneInput.value = `(${value}`;
    }
}

function aplicarMascaraCep() {
    const cepInput = document.getElementById('cep');
    let value = cepInput.value.replace(/\D/g, ''); // Remove caracteres não numéricos

    if (value.length > 9) {
        value = value.slice(0, 9); // Limita a 9 caracteres
    }

    // Formata o CEP
    if (value.length > 5) {
        cepInput.value = `${value.slice(0, 5)}-${value.slice(5)}`;
    } else {
        cepInput.value = value;
    }
}

function aplicarMascaraCpf() {
    const cpfInput = document.getElementById('cpf');
    let value = cpfInput.value.replace(/\D/g, ''); // Remove caracteres não numéricos

    if (value.length > 14) {
        value = value.slice(0, 14); // Limita a 14 dígitos numéricos
    }

    // Formata como CPF (999.999.999-99)
    if (value.length > 9) {
        cpfInput.value = `${value.slice(0, 3)}.${value.slice(3, 6)}.${value.slice(6, 9)}-${value.slice(9)}`;
    } else if (value.length > 6) {
        cpfInput.value = `${value.slice(0, 3)}.${value.slice(3, 6)}.${value.slice(6)}`;
    } else if (value.length > 3) {
        cpfInput.value = `${value.slice(0, 3)}.${value.slice(3)}`;
    } else {
        cpfInput.value = value;
    }
}