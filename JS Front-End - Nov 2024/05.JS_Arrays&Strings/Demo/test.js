
function solve(num1, num2, num3) {
    console.log(num1 + num2);
}

solve(2, 2)

const names = ['Pesho', 'Gosho', 'Sasho'];

for (const name of names) {
    console.log(name);
}

const cars = ['BMW', 'Audi', 'VW', 'Opel']
console.log(cars);

const lastCar = cars.pop();

console.log(cars);
console.log(lastCar);


const removedCars = cars.splice(1, 1);
console.log(removedCars)
console.log(cars);

const number = 1000;
const binary = number.toString(2);
console.log(binary);

const hexa = number.toString(16);
console.log(hexa);

