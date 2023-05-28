class User {
    constructor(username, email, password) {
        this.username = username;
        this.email = email;
        this.password = password;
    }
}


function saveUser(user) {
    const users = JSON.parse(localStorage.getItem('users')) || [];
    users.push(user);
    localStorage.setItem('users', JSON.stringify(users));
    fs.writeFileSync('logs.json', users);
    console.log(users);
}

function registerUser(event) {
    event.preventDefault();

    const username = document.getElementById('signupForm').username.value;
    const email = document.getElementById('signupForm').email.value;
    const password = document.getElementById('signupForm').password.value;

    const user = new User(username, email, password);
    saveUser(user);

    console.log('Registration successful!');
}

function loginUser(event) {
    event.preventDefault();

    const email = document.getElementById('loginForm').email.value;
    const password = document.getElementById('loginForm').password.value;

    console.log('Login successful!');
}

const signupForm = document.getElementById('signupForm');
signupForm.addEventListener('submit', registerUser);

const loginForm = document.getElementById('loginForm');
loginForm.addEventListener('submit', loginUser);
