const togglePassword = document
    .querySelector('#togglePassword');

const password = document.querySelector('#password');

togglePassword.addEventListener('click', () => {
    const type = password
        .getAttribute('type') === 'password' ?
        'text' : 'password';

    password.setAttribute('type', type);

    if (togglePassword.classList.contains('fa-eye-slash')) {
        togglePassword.classList.remove('fa-eye-slash');
        togglePassword.classList.add('fa-eye');
        return;
    }

    if (togglePassword.classList.contains('fa-eye')) {
        togglePassword.classList.remove('fa-eye');
        togglePassword.classList.add('fa-eye-slash');
        return;
    }
});