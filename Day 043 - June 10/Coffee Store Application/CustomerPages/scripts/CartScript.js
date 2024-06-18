AOS.init({ duration: 1500 });

document.addEventListener('DOMContentLoaded', function(){
    if(sessionStorage.getItem("customerToken")==null){
        var notLoggedInModal = new bootstrap.Modal(document.getElementById('notLoggedInModal'));
        notLoggedInModal.show();

        document.getElementById('login-btn').addEventListener('click', function(){
            window.location.href = './Login.html';
        })
        return;
    }
})