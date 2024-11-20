// Variable declaration
let age = 18;
let firstName = 'Gosho';
let isMale = true;

// Basic solve funciton
function solve(num1, num2) {
    console.log(num1 + num2);
}

// Execute solve function
solve(1, 2);

// Print on the console
console.log('My name is ' + firstName + '!');
console.log(`My name is ${firstName}!`);

// Fix numbers
let firstNumber = 3;
let secondNumber = 3.14159265359;
console.log(firstNumber.toFixed(2));
console.log(secondNumber.toFixed(2));

// Using const
const lastName = 'Papazov';

// Block scope
if (true) {
    let schoolName = 'SoftUni'; // varriable has block scope
    console.log(schoolName);
}

// console.log(schoolName); // Throws error not defined

// Outer block scope
if (true) {
    let outerVariable = 100;

    if (true) {
        let innerVariable = 200;
        console.log(outerVariable);
    }

    // console.log(innerVariable);
}
