
function solve(input) {
    
    const zippedArray = [];
    const initArrLength = input.length;
    
    input.sort((a, b) => a - b);

    for (let i = 0; i < initArrLength; i++) {
        if (i % 2 == 0) {
            const element = input.shift();
            zippedArray.push(element);
        } else {
            const element = input.pop();
            zippedArray.push(element);
        }
        
    }

    return zippedArray;

}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));


	//[-3, 65, 1, 63, 3, 56, 18, 52, 31, 48]  