function printMatrix(input) {
   const result = ((input + ' ').repeat(input) + '\n').repeat(input); 
    console.log(result);
}

printMatrix(5);