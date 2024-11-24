document.addEventListener('DOMContentLoaded', () => {

    const senhaInput = document.getElementById('senha');

    const mostrarSenhaCheckbox = document.getElementById('mostrarSenha');

    mostrarSenhaCheckbox.addEventListener('change', () => {
        if (mostrarSenhaCheckbox.checked) {
            senhaInput.type = 'text';
        } else {
            senhaInput.type = 'password';
        }

    });
});