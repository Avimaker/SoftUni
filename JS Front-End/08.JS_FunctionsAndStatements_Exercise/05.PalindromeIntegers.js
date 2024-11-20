function PalindromeIntegers(numbers) {

    const isPalindrome = (num) => {
        const stringNumber = num.toString();
        const strNumReversed = stringNumber.split('').reverse().join('');

        return stringNumber === strNumReversed;
   };
     
   numbers.forEach(n => console.log(isPalindrome(n)));

}


PalindromeIntegers([123,323,421,121])	
// false
// true
// false
// true

console.log('--------');

PalindromeIntegers([32,2,232,1010])
// false
// true
// true
// false
