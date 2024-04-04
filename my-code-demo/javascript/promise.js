// run this with terminal or node js interpreter
// a restaurant needs to prepare the order BEFORE serving it
let stock = {
  fruits: ["strawberry", "grapes", "apple", "banana"],
  liquids: ["water", "ice"],
  holders: ["cone", "cup", "stick"],
  toppings: ["chocolate", "peanuts"],
};

let isShopOpen = true;

let order = (time, work) =>
  new Promise((resolve, reject) => {
    if (isShopOpen) {
      setTimeout(() => {
        resolve(work());
      }, time);
    } else {
      reject(console.log("our shop is closed"));
    }
  });

// ==============
// ==== main ====
order(2000, () => console.log(`${stock.fruits[0]} was ordered`))
  .then(() => order(0, () => console.log("production has started")))
  .then(() => order(2000, () => console.log("the fruit was chopped")))
  .then(() =>
    order(1000, () =>
      console.log(`${stock.liquids[0]} and  ${stock.liquids[1]} was selected`)
    )
  )
  .then(() => order(1000, () => console.log("start the machine")))
  .then(() =>
    order(2000, () =>
      console.log(`ice-cream was placed on ${stock.holders[0]}`)
    )
  )
  .then(() =>
    order(3000, () => console.log(`${stock.toppings[0]} was selected`))
  )
  .then(() => order(1000, () => console.log("ice-cream was served")))

  // when isShopOpen = false
  .catch(() => console.log("customer left"))

  // close the shop in any case
  .finally(() => console.log("day ended, shop is closed"));
