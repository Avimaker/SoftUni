// //Var 1
// function solve (array, step) {
    
//     const newArr = [];
    
//     for (let i = 0; i < array.length; i++) {
//         if (i % step === 0) newArr.push(array[i])             
//         }
    
//     return newArr;
// }

// //Var 2
// function solve (array, step) {
    
//     const newArr = [];
    
//     array.forEach(function( element, index) {
//         if (index % step === 0) newArr.push(array[index])             
//     });
//     return newArr;
// }

// //Var 3
// function solve (array, step) {
//     return array.filter(function (el, index) {
//         return index % step === 0;
//     });
// }

//Var 4
function solve (array, step) {
    return array.filter((e, i) => i % step === 0);
}


console.log( solve(['5', '20', '31', '4', '20'], 2)); //['5', '31', '20']
console.log( solve(['dsa', 'asd', 'test', 'tset'], 2)); //['dsa', 'test']
console.log( solve(['1', '2', '3', '4', '5'], 6)); //['1']
