function solve(fruit, weight, price) {
    const kg = weight / 1000;
    const money = price * kg;
console.log(`I need $${money.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`);

}







solve('orange', 2500, 1.80)
//I need $4.50 to buy 2.50 kilograms orange.

solve('apple', 1563, 2.35)
//I need $3.67 to buy 1.56 kilograms apple.
