// function oddAndEvenSum(number) {
//     const digits = Math.abs(number).toString().split('').map(Number);

//     const evenSum = digits.filter(d => d % 2 === 0).reduce((result, d) => result + d, 0);
//     const oddSum = digits.filter(d => d % 2 !== 0).reduce((result, d) => result + d, 0);

//     console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
// }


//foreach 

function oddAndEvenSum(number) {
    const digits = Math.abs(number).toString().split('').map(n => Number(n));

    let evenSum = 0, oddSum = 0;

    digits.forEach(d => (d % 2 == 0) ? evenSum += d : oddSum += d);

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}




oddAndEvenSum(1000435)	//            Odd sum = 9, Even sum = 4
oddAndEvenSum(3495892137259234)	// Odd sum = 54, Even sum = 22
