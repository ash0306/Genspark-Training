var typed = new Typed("#typed-element", {
    strings: ["Logout Successful"],
    typeSpeed: 50,
    cursorChar: "",
    loop: false
});
document.addEventListener("DOMContentLoaded", function() {
    sessionStorage.removeItem("employeeToken");
    console.log("logged out");
})