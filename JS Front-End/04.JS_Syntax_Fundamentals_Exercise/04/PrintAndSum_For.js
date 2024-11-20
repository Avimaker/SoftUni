function solve(num1, num2) {
    
    let sum = 0;
    let result = '';  // Създаваме низ, в който ще добавяме числата

    for ( let i = num1; i <= num2; i++) {
        result += i + ' '; //добавяме числото в стринга със спейс
        sum += i;
    }

    console.log(result.trim()); // Печатаме числата на един ред
    console.log(`Sum: ${sum}`);
}

solve(5, 10) //	5 6 7 8 9 10
             // Sum: 45
solve(0, 26) //	0 1 2 … 26
             //Sum: 351
solve(50, 60)//	50 51 52 53 54 55 56 57 58 59 60
             //Sum: 605
             