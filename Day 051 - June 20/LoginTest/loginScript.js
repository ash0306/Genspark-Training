const users = [
    { username: 'user1', password: 'pass1' },
    { username: 'user2', password: 'pass2' },
];

document.getElementById('loginButton').addEventListener('click', () => {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    const message = document.getElementById('message');

    const user = users.find(user => user.username === username && user.password === password);

    if (user) {
        message.textContent = 'Login successful!';
        message.style.color = 'green';
    } else {
        message.textContent = 'Invalid username or password';
        message.style.color = 'red';
    }
});
