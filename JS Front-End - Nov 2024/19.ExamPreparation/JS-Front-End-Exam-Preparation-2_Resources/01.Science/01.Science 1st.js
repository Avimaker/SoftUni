function runExperiment(input) {
    let n = parseInt(input[0]);  // Number of chemicals
    let chemicals = {};  // Object to store chemicals with their details

    // Reading the chemicals and their quantities
    for (let i = 1; i <= n; i++) {
        let [name, quantity] = input[i].split(' # ');
        chemicals[name] = { quantity: parseInt(quantity), formula: null };
    }

    // Processing commands
    for (let i = n + 1; i < input.length; i++) {
        let command = input[i];

        if (command === 'End') {
            // End command: Print all chemicals with their quantities and formulas
            for (let name in chemicals) {
                if (chemicals[name].formula) {
                    console.log(`Chemical: ${name}, Quantity: ${chemicals[name].quantity}, Formula: ${chemicals[name].formula}`);
                } else {
                    console.log(`Chemical: ${name}, Quantity: ${chemicals[name].quantity}`);
                }
            }
            break;
        }

        let parts = command.split(' # ');

        if (parts[0] === 'Mix') {
            // Mix command: Mix two chemicals
            let chemical1 = parts[1];
            let chemical2 = parts[2];
            let amount = parseInt(parts[3]);

            if (chemicals[chemical1] && chemicals[chemical2] &&
                chemicals[chemical1].quantity >= amount && chemicals[chemical2].quantity >= amount) {
                // Both chemicals have enough quantity
                chemicals[chemical1].quantity -= amount;
                chemicals[chemical2].quantity -= amount;
                console.log(`${chemical1} and ${chemical2} have been mixed. ${amount} units of each were used.`);
            } else {
                // One or both chemicals do not have enough quantity
                console.log(`Insufficient quantity of ${chemical1}/${chemical2} to mix.`);
            }

        } else if (parts[0] === 'Replenish') {
            // Replenish command: Replenish a chemical's quantity
            let chemical = parts[1];
            let amount = parseInt(parts[2]);

            if (chemicals[chemical]) {
                let newQuantity = chemicals[chemical].quantity + amount;
                if (newQuantity > 500) {
                    let addedAmount = 500 - chemicals[chemical].quantity;
                    chemicals[chemical].quantity = 500;
                    console.log(`${chemical} quantity increased by ${addedAmount} units, reaching maximum capacity of 500 units!`);
                } else {
                    chemicals[chemical].quantity = newQuantity;
                    console.log(`${chemical} quantity increased by ${amount} units!`);
                }
            } else {
                // Chemical not found
                console.log(`The Chemical ${chemical} is not available in the lab.`);
            }

        } else if (parts[0] === 'Add Formula') {
            // Add Formula command: Add a formula to a chemical
            let chemical = parts[1];
            let formula = parts[2];

            if (chemicals[chemical]) {
                chemicals[chemical].formula = formula;
                console.log(`${chemical} has been assigned the formula ${formula}.`);
            } else {
                // Chemical not found
                console.log(`The Chemical ${chemical} is not available in the lab.`);
            }
        }
    }
}

// Example Input 1
runExperiment([
    '4',
    'Water # 200',
    'Salt # 100',
    'Acid # 50',
    'Base # 80',
    'Mix # Water # Salt # 50',
    'Replenish # Salt # 150',
    'Add Formula # Acid # H2SO4',
    'End'
]);

// Example Input 2
runExperiment([
    '3',
    'Sodium # 300',
    'Chlorine # 100',
    'Hydrogen # 200',
    'Mix # Sodium # Chlorine # 200',
    'Replenish # Sodium # 250',
    'Add Formula # Sulfuric Acid # H2SO4',
    'Add Formula # Sodium # Na',
    'Mix # Hydrogen # Chlorine # 50',
    'End'
]);