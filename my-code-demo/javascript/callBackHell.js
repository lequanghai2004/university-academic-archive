// run this with terminal or node js interpreter
// a restaurant needs to prepare the order BEFORE serving it
let stock = {
  fruits: ["strawberry", "grapes", "apple", "banana"],
  liquids: ["water", "ice"],
  holders: ["cone", "cup", "stick"],
  toppings: ["chocolate", "peanuts"],
};

// ---- this function must take place first ----
let order = (fruitId, callProduction) => {
  // placing the order takes 2 sec !!
  setTimeout(() => {
    console.log(`${stock.fruits[fruitId]} was selected`);
    callProduction();
  }, 2000);
};

// ---- this is invoked only after order() finished ----
// the following task MUST BE performed IN ORDER
// chopping fruit takes 2 sec
// adding water and ice takes 1 sec
// starting the machine takes 1 sec
// selecting container takes 2 sec
// selecting topping takes 3 sec
// serving the ice-cream takes 2 sec
let production = () => {
  setTimeout(() => {
    console.log(`production has started`);

    setTimeout(() => {
      console.log("the fruit has been chopped");

      setTimeout(() => {
        console.log(`${stock.liquids[0]} and ${stock.liquids[1]} was added`);

        setTimeout(() => {
          console.log(`machine was started`);

          setTimeout(() => {
            console.log(`ice-cream was placed on ${stock.holders[0]}`);

            setTimeout(() => {
              console.log(`${stock.toppings[0]} was added as topping`);

              setTimeout(() => {
                console.log("serve ice-cream");
              }, 2000);
            }, 3000);
          }, 2000);
        }, 1000);
      }, 1000);
    }, 2000);
  }, 0);
};

// ==================
// ====== main ======x
order(0, production);
