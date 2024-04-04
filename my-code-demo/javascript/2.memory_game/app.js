// ---- the cards display starts ---- //

const cardSideLengthPx = 150;
const cardBorderWidthPx = 1;
const noOfCardPerLine = 5;
let chosenCardTags = [];
let chosenCardNames = [];
let score = document.getElementById("result");
score.innerHTML = 0;
const cardsData = [
  {
    name: "red",
    img: "images/red.png",
  },
  {
    name: "yellow",
    img: "images/yellow.png",
  },
  {
    name: "blue",
    img: "images/blue.png",
  },
  {
    name: "cyan",
    img: "images/cyan.png",
  },
  {
    name: "magenta",
    img: "images/magenta.png",
  },
  {
    name: "green",
    img: "images/green.png",
  },
  // duplicate
  {
    name: "red",
    img: "images/red.png",
  },
  {
    name: "yellow",
    img: "images/yellow.png",
  },
  {
    name: "blue",
    img: "images/blue.png",
  },
  {
    name: "cyan",
    img: "images/cyan.png",
  },
  {
    name: "magenta",
    img: "images/magenta.png",
  },
  {
    name: "green",
    img: "images/green.png",
  },
];

// random the elements order
cardsData.sort(() => 0.5 - Math.random());

// fill in the grid
const grid = document.querySelector("#grid");
grid.style.width =
  (cardSideLengthPx + cardBorderWidthPx * 2) * noOfCardPerLine + "px";

for (let i = 0; i < cardsData.length; i++) {
  const card = document.createElement("img");
  card.setAttribute("src", "images/black.png");
  // card.setAttribute("src", cardsData[i].img);
  card.setAttribute("id", i);
  card.setAttribute("width", cardSideLengthPx);
  card.setAttribute("height", cardSideLengthPx);
  card.style.border = "1px solid #ffffff";
  card.addEventListener("click", chooseCard);
  // console.log(card); // debug
  grid.appendChild(card);
}

// ==== the cards display ends ==== //

function chooseCard() {
  if (chosenCardTags.length >= 2) return;
  // ---- show hidden img, add chosen pair to a temp arr ----
  const cardId = this.getAttribute("id");
  const cardData = cardsData[cardId];
  this.setAttribute("src", cardData.img);
  chosenCardTags.push(this);
  chosenCardNames.push(cardData.name);

  if (chosenCardTags.length != 2) return;
  // ---- check a pair match ----
  setTimeout(() => {
    if (chosenCardTags[0] === chosenCardTags[1]) {
      // handle clicking the same card
      alert("You pick the same card");
      chosenCardTags[0].setAttribute("src", "images/black.png");
    } else if (chosenCardNames[0] === chosenCardNames[1]) {
      // 2 chosen cards are of 1 kind
      alert("It's a match");
      // +1 score and if no more cards, win the game
      score.innerHTML++;
      if (score.innerHTML == cardsData.length / 2) {
        alert("You won the game!");
      }
      // remove the card
      chosenCardTags.forEach((cardTag) => {
        cardTag.setAttribute("src", "images/white.png");
        cardTag.removeEventListener("click", chooseCard);
      });
    } else {
      // 2 chosen cards are not of 1 kind
      chosenCardTags.forEach((cardTag) => {
        cardTag.setAttribute("src", "images/black.png");
      });
    }
    // reset the arrays
    chosenCardTags = [];
    chosenCardNames = [];
  }, 1000);
}
