var calcAge = () =>{
    var DoB = document.getElementById("dob").value;
    if(DoB){
        var dob = new Date(DoB);
        var today = new Date();
        var age = today.getFullYear() - dob.getFullYear();
        var month = today.getMonth() - dob.getMonth();
        if (month < 0 || (month === 0 && today.getDate() < dob.getDate())) {
            age--;
        }
        ageOutput = age + " years old.";
        document.getElementById("age").value = ageOutput;
    }
}

var professionValid = () =>{
    const professionDataList = document.getElementById("professionList");
    const professionList = ["Doctor", "Engineer", "Teacher"];
    const profession = document.getElementById("profession").value.trim();
      if (!professionList.includes(profession)) {
        professionList.push(profession);
        const option = document.createElement("option");
        option.value = profession;
        professionDataList.appendChild(option);
      }
}




//BOOTSTRAP VALIDATION
// Fetch all the forms we want to apply custom Bootstrap validation styles to
var forms = document.querySelectorAll('.needs-validation');

// Loop over them and prevent submission
Array.prototype.slice.call(forms).forEach(function (form) {
    form.addEventListener('submit', function (event) {
        if (!form.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
        }

        form.classList.add('was-validated');
    }, false);
});

// Real-time validation
document.querySelectorAll('.needs-validation .form-control').forEach(function (input) {
    input.addEventListener('input', function () {
        if (input.checkValidity()) {
            input.classList.remove('is-invalid');
            input.classList.add('is-valid');
        } else {
            input.classList.remove('is-valid');
            input.classList.add('is-invalid');
        }
    });
});