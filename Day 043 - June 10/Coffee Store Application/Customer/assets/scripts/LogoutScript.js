
document.addEventListener("DOMContentLoaded", function() {
    sessionStorage.removeItem("customerToken");

    if(sessionStorage.getItem("customerToken") == null){
        var typed = new Typed("#typed-element", {
            strings: ["Logout Successful"],
            typeSpeed: 50,
            cursorChar: "",
            loop: false
        });
    }
});