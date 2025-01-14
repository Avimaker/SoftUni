// Number
let integerNumber = 10;
let decimalNumber = 3.14;
let negativeNumber = -10;
let maxPreciseNumber = Number.MAX_SAFE_INTEGER;
let maxDoublePrecisionNumber = Number.MAX_VALUE;
let notANumber = NaN;
let infinity = Infinity;

// String
let singleQuoteLiteral = 'Pesho';
let doubleQuoteLiteral = "Gosho";
let templateLiteral = `Stamat`;

// Undefined
let undf = undefined;

// Null
let empty = null;

// BigInt
let bigNumber = BigInt('9007199254740992');
let bigNumber2 = 9007199254740992n;

// Cast string to number
let intNumber = parseInt('10');
let floatNumber = parseFloat('3.14');
let parsedNumber = Number('101.1');
console.log(intNumber);
console.log(floatNumber);
console.log(parsedNumber);

// Not a Number
console.log(Number('Pesho'));
