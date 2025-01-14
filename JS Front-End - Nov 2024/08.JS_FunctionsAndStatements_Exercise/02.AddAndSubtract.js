function addAndSubstract(num1, num2, num3) {
    const addSum = (a, b) => a + b;
    const subtractSum = (a, b) => a - b;
    return subtractSum(addSum(num1, num2), num3);

}





console.log(addAndSubstract(23, 6, 10)); //	19

console.log(addAndSubstract(1, 17, 30)) //-12
console.log(addAndSubstract(42, 58, 100))//	0
