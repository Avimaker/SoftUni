// Aritmetic operators
console.log(5 + 10); // addition operator, result: 15
console.log(5 + '10'); // concatenation operator, result: 510
console.log(1 + 2 + '3'); // 33
console.log('1' + 2 + 3); // 123

// division
console.log(9 / 2); // 4.5

// modulo
console.log(9 % 2);

// Exponentiation
console.log(10 ** 2);

// Comparison operators
let a = 5;
let b = '5';
console.log(a == b); // equality operator, result: true, equality with enabled coercion
console.log(a === b); // identity operator, result: false, equality with disabled coercion
console.log(a != b); // inequality operator, result: false, inequality with enabled coercion
console.log(a !== b); // strict inequality operator, result: true, inqality with disabled coercion

// ternary operator
console.log(a == b ? 'Equal with coercion' : 'Not equal');

// if else statement
let number = 10;
if (number < 20) {
    console.log('Number is less than 20');
} else if (number < 30) { 
    console.log('Number is less than 30 and greater or equal than 20');
} else {
    console.log('Number is equal or greater than 30');
}

// switch
let color = 'pink';
switch (color) {
    case 'red': 
        console.log('The roses are red');
        break;
    case 'blue':
        console.log('The violets are blue');
        break;
    case 'pink':
        console.log('This poem makes no sense');
        break;
    case 'brown':
        console.log('Microwave');
        break;
    default:
        console.log('Ti si roza ti si krem...');
        break;
}

// Logical operators
console.log(!true); // Not operator, result: false
console.log(!!true); // Not operator, result: true

// And logical operator
// true && false -> false
// false && true -> false
// false && false -> false
// true && true -> true

// Or logical operator
// true || false -> true
// false || true -> true
// true || true -> true
// false || false -> false

// Rule! Comparison operators have greater priority than logical operators

// Typeof operator
console.log(typeof 5);
console.log(typeof 'Pesho');
console.log(typeof true);
console.log(typeof 1000001n);
console.log(typeof undefined);
console.log(typeof Symbol('pesho'));
console.log(typeof null);

// Truthy values
console.log(Boolean('Pesho')); // Non empty arrays are truthy
console.log(Boolean([])); // true
console.log(Boolean({}));// true

// Falsy values
console.log(Boolean(false));
console.log(Boolean(0));
console.log(Boolean(NaN));
console.log(Boolean(''));
console.log(Boolean(null));
console.log(Boolean(undefined));

// Incrementation and decrementation
let c = 1;
c++;
console.log(c);
