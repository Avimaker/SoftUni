function solve(numbers) {
    let evenSum = 0;
    let oddSum = 0;

    numbers
        .filter(function (number) {
            return number % 2 === 0;
        })
        .forEach(function (number) {
            evenSum += number;
        });

    numbers
        .filter(function (number) {
            return number % 2 !== 0;
        })
        .forEach(function (number) {
            oddSum += number;
        });

        console.log(evenSum - oddSum);
}

solve([1, 2, 3, 4, 5, 6]);
