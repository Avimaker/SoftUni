function sumNumbersFromArray (array) {
    return array. reduce(function (sum, element, index){
        return sum + element;
    }, 0);
}

console.log( sumNumbersFromArray ([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]) );