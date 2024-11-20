// function solve(input) {

//     let emploees = input.reduce((person, currentValue) => {
    //         person[currentValue] = currentValue.length
//         return person;
//     }, {});

//     for (const person in emploees) {
//         console.log(`Name: ${person} -- Personal Number: ${person.length}`);
//     }

// }


// function solve(input) {

//     const emploees = [];

//     input.forEach((name) => {
    //         emploees.push({
//             name,
//             ID: name.length
//         })
//     });

//     emploees.forEach((emploee) => {
    //         console.log(`Name: ${emploee.name} -- Personal Number: ${emploee.ID}`);
//     })
// }




function solve(input) {
    
    function processEmployees(list){
        return list.reduce((person, currentValue) => {
            person[currentValue] = currentValue.length
            return person;
        }, {});
    }

    function printEmployees(employees) {
        for (const person in employees) {
            console.log(`Name: ${person} -- Personal Number: ${person.length}`);
        }
    }

    const employees = processEmployees(input);
    printEmployees(employees);
    
}






solve(['Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]);