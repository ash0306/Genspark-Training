const letters = ["G", "D", "E", "N", "I", "L"];
const centralLetter = "W";
const validWords = [
    "DWELL", "DWELLED", "DWELLING", "DWINDLE", "DWINDLED", "DWINDLING",
    "LEWD", "NEWEL", "WEDDED", "WEDDING", "WEDGE", "WEDGED", "WEDGIE",
    "WEDGING", "WEED", "WEEDED", "WEEDING", "WEENIE", "WELD", "WELDED",
    "WELDING", "WELL", "WELLED", "WELLING", "WEND", "WENDED", "WENDING",
    "WIDE", "WIDEN", "WIDENED", "WIDENING", "WIELD", "WIELDED", "WIELDING",
    "WIENIE", "WIGGED", "WIGGING", "WIGGLE", "WIGGLED", "WIGGLING", "WILD",
    "WILDLING", "WILE", "WILL", "WILLED", "WILLING", "WIND", "WINDED",
    "WINDING", "WINE", "WINED", "WING", "WINGDING", "WINGED", "WINGING",
    "WINING", "WINNING"
];
const totalWords = 57;
var guessedWords = 0;
const currentWordInput = document.getElementById("current-word");
const wordList = document.getElementById("word-list");
let currentWord = "";


document.addEventListener("DOMContentLoaded", () => {
    // Create letter buttons
    const svgElements = document.querySelectorAll(".hive-cell");
    svgElements.forEach((svg, index) => {
        const textElement = svg.querySelector(".cell-letter");
        if (index === 0) {
        textElement.textContent = centralLetter;
        } else {
        textElement.textContent = letters[index - 1];
        }

        svg.addEventListener("click", () => {
        if (currentWord.length < 5) {
            currentWord += textElement.textContent;
            currentWordInput.value = currentWord;
        }
        });
    });
});

function deleteLetter(){
    currentWord = currentWord.slice(0, -1);
    currentWordInput.value = currentWord;
}

function submitAnswer(){
    if (currentWord.includes(centralLetter)) {
        if(validWords.includes(currentWord)){
            const listItem = document.createElement("li");
            listItem.classList.add("list-group-item");
            listItem.textContent = currentWord;
            wordList.appendChild(listItem);
            guessedWords++;
            trackProgress();
        }
        else{
            alert("Invalid word")
        }
    } 
    else {
        alert("Invalid word. The word should contain the center letter");
    }
    currentWord = "";
    currentWordInput.value = "";
}

function trackProgress(){
    progressBar = document.getElementById("progress-tracker");
    progressBar.style.width = calculatePercentage() + "%";
}

function calculatePercentage() {
    const percentage = (guessedWords / totalWords) * 100;
    return Math.round(percentage);
}