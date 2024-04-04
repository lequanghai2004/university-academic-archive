const computerChoiceDispl = document.getElementById("computer-choice");
const userChoiceDispl = document.getElementById("user-choice");
const resultDispl = document.getElementById("result");

let userChoice;
let computerChoice;

// collect possible choices
const choices = document.querySelectorAll(".choice");

// display user choice anytime a choice is selected
choices.forEach((choice) => {
  choice.addEventListener("click", (ev) => {
    // get user choice from selected button id
    userChoice = ev.target.id;
    // generate random computer choice
    randomNo = Math.floor(Math.random() * choices.length);
    computerChoice = choices[randomNo].innerHTML;
    // display both choices
    userChoiceDispl.innerHTML = userChoice;
    computerChoiceDispl.innerHTML = computerChoice;

    // compare to give result
    if (userChoice === computerChoice) resultDispl.innerHTML = "It's a draw";
    else {
      switch (userChoice) {
        case "rock":
          resultDispl.innerHTML =
            computerChoice === "scissor" ? "You win!" : "Computer wins!";
        case "paper":
          resultDispl.innerHTML =
            computerChoice === "rock" ? "You win!" : "Computer wins!";
        case "scissor":
          resultDispl.innerHTML =
            computerChoice === "paper" ? "You win!" : "Computer wins!";
        default:
          computerChoice = "Invalid choice";
      }
    }
  });
});
