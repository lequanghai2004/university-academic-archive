// run this with terminal or node js interpreter
// a restaurant needs to prepare the order BEFORE serving it
let stock = {
  fruits: ["strawberry", "grapes", "apple", "banana"],
  liquids: ["water", "ice"],
  holders: ["cone", "cup", "stick"],
  toppings: ["chocolate", "peanuts"],
};

let isShopOpen = true;

// const time = async (ms) => {
//   if (isShopOpen) {
//     setTimeout(resolve, ms);
//   } else {
//     reject(console.log("shop was closed"));
//   }
// };

const time = (ms) =>
  new Promise((resolve, reject) => {
    if (isShopOpen) {
      setTimeout(resolve, ms);
    } else {
      reject(console.log("shop was closed"));
    }
  });

let topping_choice = () => new Promise((resolve, reject) => console.log());

kitchen = async () => {
  let intervalId;
  try {
    // await keyword goes after a promise
    await new Promise((resolve, reject) => resolve());

    intervalId = setInterval(() => {
      console.log("++++");
    }, 1000);

    promise1 = time(3000);
    console.log("SELECTING FRUIT .....");
    await promise1;
    console.log(`${stock.fruits[0]} was selected`);

    promise2 = time(0);
    console.log("GATHERING NECESSITIES FOR PRODUCTION");
    await promise2;
    console.log("start the production");

    promise3 = time(2000);
    console.log("GETTING THE KNIFE");
    await promise3;
    console.log("cut the fruit");

    await time(2000);
    console.log(`${stock.liquids[0]} and ${stock.liquids[1]} was added`);

    await time(1000);
    console.log("start the machine");

    await time(2000);
    console.log(`ice-cream place on ${stock.holders[0]}`);

    await time(3000);
    console.log(`${stock.toppings[0]} was selected`);

    await time(2000);
    console.log("serve the ice-creeam");
  } catch (error) {
    console.log("customer left");
  } finally {
    console.log("shop was closed");
    clearInterval(intervalId);
  }
};

// ==== main ====
kitchen();

console.log("doing the dishes");
console.log("cleaning the table");
console.log("taking other orders");
