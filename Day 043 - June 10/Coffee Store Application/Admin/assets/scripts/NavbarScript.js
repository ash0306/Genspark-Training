document.addEventListener('DOMContentLoaded', function(){
    var adminRole = '';

    var token = sessionStorage.getItem('employeeToken');
    const tokenArray = token.split('.');
    const tokenPayload = JSON.parse(atob(tokenArray[1]));
    adminRole = tokenPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

    const navbar = document.getElementById('navBarToggleContent');

    if(adminRole=='Admin'){
        navbar.innerHTML ='';
        navbar.innerHTML = `
        <a href="./Customers.html" class="text-dark text-decoration-none">Customers</a>
        <a href="./Employees.html" class="text-dark text-decoration-none">Employees</a>
        <button type="button" href="#" class="btn btn-dark rounded-lg px-3">
        <a href="./Login.html" class="text-light text-decoration-none">Login</a></button>`;
    }
})