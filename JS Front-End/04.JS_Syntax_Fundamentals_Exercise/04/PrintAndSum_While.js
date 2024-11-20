function solve(num1, num2) {
    
    let sum = 0;
    let count = (num2 - num1) + 1;
    let tempNumber = num1;
    let result = '';  // Създаваме низ, в който ще добавяме числата

    while (count > 0) {
        result += tempNumber + ' ';  // Добавяме числото към низа с интервал
        sum += tempNumber;
        tempNumber++;
        count--;
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
             