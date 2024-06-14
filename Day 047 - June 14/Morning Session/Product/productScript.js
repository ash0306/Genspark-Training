function buttonClick() {
        var myDiv = document.getElementById("div1");
        myDiv.innerHTML = "You clicked the button";
        //myDiv.style.backgroundColor = "blue";
        //myDiv.style.color = "white";
        myDiv.classList.add("alert");
        myDiv.classList.add("alert-primary");
    }
    var validateName = () => {
        var txtName = document.getElementById("txtName");
        if (!txtName.value) {
            txtName.classList.add("error");
            txtName.classList.remove("correct");
        }
        else {
            txtName.classList.remove("error");
            txtName.classList.add("correct");
        }
   
    }
var btnMouseEnter = () => {
        document.getElementsByTagName("button")[0].style.backgroundColor = "blue";
}

var btnMouseLeave = () => {
        document.getElementsByTagName("button")[0].style.backgroundColor = "green";
}

var inputChange = () => {
    var inputText = document.getElementById("txtName").value;
    var paragraph = document.querySelector("p");
    paragraph.textContent = "Input text changed: " + inputText;
}