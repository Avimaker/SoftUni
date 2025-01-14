function solve(firstNumber, secondNumber, operator) {
    let result;
    switch (operator) {
        case '+':
            result = firstNumber + secondNumber;
            break;
        case '-':
            result = firstNumber - secondNumber;
            break;
        default:
            break;
    }
}

function hackySolve(firstNumber, secondNumber, operator) {
    let expression = `${firstNumber} ${operator} ${secondNumber}`;

    let result = eval(expression); // !Don't do this at home!!!
    console.log(result);
}

hackySolve(5, 6, '+');
