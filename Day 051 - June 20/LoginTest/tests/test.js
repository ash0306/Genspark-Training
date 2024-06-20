const { JSDOM } = require('jsdom');
const fs = require('fs');
const path = require('path');

test('successful login', () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../login.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../loginScript.js'), 'utf8');

    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    // Simulate user input
    dom.window.document.getElementById('username').value = 'user1';
    dom.window.document.getElementById('password').value = 'pass1';

    // Trigger the login button click
    dom.window.document.getElementById('loginButton').click();

    const message = dom.window.document.getElementById('message').textContent;
    expect(message).toBe('Login successful!');
});

test('failed login', () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../login.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../loginScript.js'), 'utf8');

    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    // Simulate user input
    dom.window.document.getElementById('username').value = 'user1';
    dom.window.document.getElementById('password').value = 'wrongpassword';

    // Trigger the login button click
    dom.window.document.getElementById('loginButton').click();

    const message = dom.window.document.getElementById('message').textContent;
    expect(message).toBe('Invalid username or password');
});
