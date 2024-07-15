import { dictionary } from "./5-letter-words.js";

const words = [
  "grape",
  "frost",
  "blend",
  "quick",
  "chess",
  "glide",
  "eagle",
  "laugh",
  "jelly",
  "plank",
];

const word = words[Math.floor(Math.random() * words.length)];

const board = document.getElementById("board");
const keyboard = document.getElementById("keyboard");

let currentGuess = "";
let currentRow = 0;

function createBoard() {
  for (let i = 0; i < 6; i++) {
    const row = document.createElement("div");
    row.className = "d-flex mb-2 justify-content-center";
    for (let j = 0; j < 5; j++) {
      const cell = document.createElement("div");
      cell.className = "border border-secondary p-2 m-1 text-center";
      cell.style.width = "50px";
      cell.style.height = "50px";
      row.appendChild(cell);
    }
    board.appendChild(row);
  }
}

function createKeyboard() {
  const rows = ["QWERTYUIOP", "ASDFGHJKL", ["ENTER", "ZXCVBNM", "DELETE"]];

  rows.forEach((rowChars, index) => {
    const rowDiv = document.createElement("div");
    rowDiv.className = "d-flex justify-content-center mb-2";

    // Check if it's the last row (special buttons row)
    if (index === rows.length - 1) {
      // Create Enter button at the start of the row
      const enterButton = createSpecialButton("Enter", () => handleSubmit());
      rowDiv.appendChild(enterButton);

      // Create buttons for characters in the middle
      rowChars.forEach((key) => {
        if (key === "ENTER" || key === "DELETE") return;
        key.split("").forEach((char) => {
            var button = document.createElement("button");
            button = createKeyboardButton(button, char);
            rowDiv.appendChild(button);
        })
      });

      const deleteButton = createSpecialButton("←", () => handleBackspace());
      rowDiv.appendChild(deleteButton);
    } else {
      // Regular row creation for QWERTYUIOP and ASDFGHJKL
      const keys = rowChars.split("");
      keys.forEach((key) => {
        var button = document.createElement("button");
        button = createKeyboardButton(button, key)
        rowDiv.appendChild(button);
      });
    }

    keyboard.appendChild(rowDiv);
  });
}

function createKeyboardButton(button, key){
    button.textContent = key;
    button.className = "btn btn-secondary m-1";
    button.style.width = "50px";
    button.style.height = "50px";
    button.addEventListener("click", () => handleKeyPress(key));

    return button;
}

function createSpecialButton(text, clickHandler) {
  const button = document.createElement("button");
  button.textContent = text;
  button.className = "btn btn-secondary m-1";
  button.style.width = "100px";
  button.style.height = "50px";
  button.addEventListener("click", clickHandler);
  return button;
}

function handleBackspace() {
  currentGuess = currentGuess.slice(0, -1);
  updateBoard();
}

function handleKeyPress(key) {
  if (currentGuess.length < 5) {
    currentGuess += key;
    updateBoard();
  }
}

function updateBoard() {
  const rows = board.children;
  const row = rows[currentRow];
  for (let i = 0; i < 5; i++) {
    const letter = currentGuess[i] ? currentGuess[i].toUpperCase() : "";
    row.children[i].textContent = letter;
  }
}

function checkGuess() {
  const rows = board.children;
  const row = rows[currentRow];
  const guess = currentGuess.split("");
  const wordArray = word.split("");

  for (let i = 0; i < 5; i++) {
    if (guess[i] === wordArray[i]) {
      row.children[i].classList.add("bg-success");
    } else if (wordArray.includes(guess[i])) {
      row.children[i].classList.add("bg-warning");
    } else {
      row.children[i].classList.add("bg-secondary");
    }
  }
}

function isValidWord(word) {
  return dictionary.includes(word.toLowerCase());
}

function handleSubmit() {
  if (currentGuess.length === 5) {
    if (!isValidWord(currentGuess)) {
      showToast("bg-danger", "Not a valid word");
        // alert("Not a valid word")
        return;
    }
    checkGuess();
    if (currentGuess === word) {
          showToast("bg-success", "You guessed the word!");
        // alert("You guessed the word!")
    } else {
      currentRow++;
      currentGuess = "";
      if (currentRow === 6) {
        showToast("bg-danger", `Game Over! The word was ${word}`);
        // alert("Game Over! The word was " + word)
      }
    }
  }
}

document.addEventListener("keydown", (e) => {
  if (e.key === "Enter") {
    handleSubmit();
  } else if (e.key === "Backspace") {
    currentGuess = currentGuess.slice(0, -1);
    updateBoard();
  } else if (/^[a-z]$/i.test(e.key)) {
    // Only allow alphabet keys
    handleKeyPress(e.key.toLowerCase());
  }
});

function showToast(classBackground, message) {
    const toastElement = document.getElementById("toastNotification");
    const toast = new bootstrap.Toast(toastElement);

    toastElement.classList.remove("bg-success", "bg-danger", "bg-warning");
    toastElement.classList.add(classBackground);
    const toastBody = toastElement.querySelector(".toast-body");
    if (toastBody) {
        toastBody.innerHTML = message;
    }
        console.log(toast);

    toast.show();
}

createBoard();
createKeyboard();