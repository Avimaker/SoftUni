function solve(jsonArray) {
    const dictionary = {};

    // Обработваме всяка JSON-строка в масива
    for (const jsonString of jsonArray) {
        const entry = JSON.parse(jsonString); // Парсираме JSON в обект
        const term = Object.keys(entry)[0]; // Вземаме ключа (термина)
        const definition = entry[term]; // Вземаме стойността (дефиницията)
        
        dictionary[term] = definition; // Добавяме/презаписваме термина в речника
    }

    // Сортираме речника по ключовете (термините)
    const sortedTerms = Object.keys(dictionary).sort((a, b) => a.localeCompare(b));

    // Отпечатваме термина и дефиницията
    for (const term of sortedTerms) {
        console.log(`Term: ${term} => Definition: ${dictionary[term]}`);
    }
}

solve([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
    ]
    );
