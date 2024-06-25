document.addEventListener('DOMContentLoaded', function(){
    var token = sessionStorage.getItem('customerToken');

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
})