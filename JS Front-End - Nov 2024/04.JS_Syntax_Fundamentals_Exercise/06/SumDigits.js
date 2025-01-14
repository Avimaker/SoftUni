function solve(num) {
    
    const stringFromNumber = num.toString(); //правим масив
    
    let sum = 0;
    for (let i = 0; i < stringFromNumber.length; i++) {
        sum += Number(stringFromNumber[i]); //взимаме стойност от масива и я кастваме към §исло
    }
    console.log(sum);
}


solve(245678)
