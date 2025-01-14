function solve(numberOfPeople, groupType, dayOfTheWeek) {
    
    const sFriday = 8.45;
    const sSaturday = 9.80;
    const sSunday =	10.46;
    
    const bFriday =	10.90;
    const bSaturday = 15.60;
    const bSunday =	16;
    
    const rFriday =	15;
    const rSaturday = 20;
    const rSunday =	22.50;
    
    let price;
    
    switch(groupType){
        case 'Students':
            if (dayOfTheWeek == 'Friday'){
                price = numberOfPeople * sFriday;
            }
            else if (dayOfTheWeek == 'Saturday'){
                price = numberOfPeople * sSaturday;
            }
            else if (dayOfTheWeek == 'Sunday'){
                price = numberOfPeople * sSunday;
            }

            if (numberOfPeople >= 30) {
                price *= 0.85;
            }
        break;

        case 'Business':
            if (dayOfTheWeek == 'Friday'){
                price = numberOfPeople * bFriday;
                if (numberOfPeople >= 100) {
                    price -= (bFriday * 10);
                }
            }
            else if (dayOfTheWeek == 'Saturday'){
                price = numberOfPeople * bSaturday;
                if (numberOfPeople >= 100) {
                    price -= (bSaturday * 10);
                }
 
            }
            else if (dayOfTheWeek == 'Sunday'){
                price = numberOfPeople * bSunday;
                if (numberOfPeople >= 100) {
                    price -= (bSunday * 10);
                }
            }
        break;

        case 'Regular':
            if (dayOfTheWeek == 'Friday'){
                price = numberOfPeople * rFriday;
            }
            else if (dayOfTheWeek == 'Saturday'){
                price = numberOfPeople * rSaturday;
            }
            else if (dayOfTheWeek == 'Sunday'){
                price = numberOfPeople * rSunday;
            }

            if (numberOfPeople >= 10 && numberOfPeople <= 20 ) {
                price *= 0.95;
            }
        break;
        
    }
    
    console.log(`Total price: ${price.toFixed(2)}`);
}



solve(30,"Students", "Sunday")      // Total price: 266.73
solve(40, "Regular", "Saturday")    // Total price: 800.00
