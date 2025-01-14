function solve(input) {
    let n = Number(input.shift());
    let farmers = new Map();

    for (let i = 0; i < n; i++) {
        let [name, workArea, tasks] = input.shift().split(' ');
        farmers.set(name, {
            workArea: workArea,
            tasks: tasks.split(',')
        });
    }

    for (let command of input) {
        if (command === "End") break;

        let [action, farmerName, arg1, arg2] = command.split(' / ');

        if (action === "Execute") {
            let workArea = arg1;
            let task = arg2;

            if (farmers.has(farmerName)) {
                let farmer = farmers.get(farmerName);

                if (farmer.workArea === workArea && farmer.tasks.includes(task)) {
                    console.log(`${farmerName} has executed the task: ${task}!`);
                } else {
                    console.log(`${farmerName} cannot execute the task: ${task}.`);
                }
            }
        } else if (action === "Change Area") {
            let newWorkArea = arg1;

            if (farmers.has(farmerName)) {
                let farmer = farmers.get(farmerName);
                farmer.workArea = newWorkArea;
                console.log(`${farmerName} has changed their work area to: ${newWorkArea}`);
            }
        } else if (action === "Learn Task") {
            let newTask = arg1;

            if (farmers.has(farmerName)) {
                let farmer = farmers.get(farmerName);

                if (farmer.tasks.includes(newTask)) {
                    console.log(`${farmerName} already knows how to perform ${newTask}.`);
                } else {
                    farmer.tasks.push(newTask);
                    console.log(`${farmerName} has learned a new task: ${newTask}.`);
                }
            }
        }
    }

    for (let [name, details] of farmers) {
        console.log(`Farmer: ${name}, Area: ${details.workArea}, Tasks: ${details.tasks.sort().join(', ')}`);
    }
}

// Example input

solve([
    "2",
    "John garden watering,weeding",
    "Mary barn feeding,cleaning",
    "Execute / John / garden / watering",
    "Execute / Mary / garden / feeding",
    "Learn Task / John / planting",
    "Execute / John / garden / planting",
    "Change Area / Mary / garden",
    "Execute / Mary / garden / cleaning",
    "End"
]
  

);


// solve([
//     "3",
//     "Alex apiary harvesting,honeycomb",
//     "Emma barn milking,cleaning",
//     "Chris garden planting,weeding",
//     "Execute / Alex / apiary / harvesting",
//     "Learn Task / Alex / beeswax",
//     "Execute / Alex / apiary / beeswax",
//     "Change Area / Emma / apiary",
//     "Execute / Emma / apiary / milking",
//     "Execute / Chris / garden / watering",
//     "Learn Task / Chris / pruning",
//     "Execute / Chris / garden / pruning",
//     "End"
// ]);