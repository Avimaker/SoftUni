function solve(records) {
    const parkingLot = new Set();

    for (const record of records) {
        // Разделяне на записа на действие и номер на автомобил
        const [direction, carNumber] = record.split(',').map(part => part.trim());

        if (direction === 'IN') {
            parkingLot.add(carNumber); // Добавяне на автомобил в паркинга
        } else if (direction === 'OUT') {
            parkingLot.delete(carNumber); // Премахване на автомобил от паркинга
        }
    }

    if (parkingLot.size === 0) {
        console.log("Parking Lot is Empty");
    } else {
        // Сортиране и отпечатване на автомобилните номера
        [...parkingLot]
            .sort((a, b) => a.localeCompare(b)) // Сортиране в лексикографски ред
            .forEach(car => console.log(car)); // Отпечатване на всеки номер
    }
}


solve([
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU'
]);

solve(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'OUT, CA1234TA']
    );