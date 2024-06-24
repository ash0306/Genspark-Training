document.addEventListener('DOMContentLoaded', function(){
    var adminRole = '';

    var token = sessionStorage.getItem('employeeToken');
    const tokenArray = token.split('.');
    const tokenPayload = JSON.parse(atob(tokenArray[1]));
    adminRole = tokenPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

    const navbar = document.getElementById('navBarToggleContent');

    if(token!==null){
        navbar.innerHTML ='';
        navbar.innerHTML = `
        <a href="./Products.html" class="text-dark text-decoration-none">Products</a>
        <a href="./Orders.html" class="text-dark text-decoration-none">Orders</a>
        <a href="./Customers.html" class="text-dark text-decoration-none">Customers</a>
        <a href="./Employees.html" class="text-dark text-decoration-none">Employees</a>
        <button type="button"class="btn btn-dark rounded-lg px-3"><a href="./Logout.html"
                class="text-light text-decoration-none">Logout</a></button>`;
    }

    if(adminRole=='Admin'){
        navbar.innerHTML ='';
        navbar.innerHTML = `
        <a href="./Customers.html" class="text-dark text-decoration-none">Customers</a>
        <a href="./Employees.html" class="text-dark text-decoration-none">Employees</a>
        <button type="button" href="#" class="btn btn-dark rounded-lg px-3">
        <a href="./Logout.html" class="text-light text-decoration-none">Logout</a></button>`;
    }
})