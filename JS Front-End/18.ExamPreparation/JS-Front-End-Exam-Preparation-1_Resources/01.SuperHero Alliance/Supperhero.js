function superheroAlliance(input) {
    const n = parseInt(input[0]);
    const superheroes = {};

    // Parse superhero data
    for (let i = 1; i <= n; i++) {
        const [name, powers, energy] = input[i].split("-");
        superheroes[name] = {
            powers: new Set(powers.split(",")),
            energy: parseInt(energy)
        };
    }

    const results = [];

    // Process commands
    for (let i = n + 1; i < input.length; i++) {
        const command = input[i];
        if (command === "Evil Defeated!") break;

        const [action, ...args] = command.split(" * ");

        if (action === "Use Power") {
            const [superheroName, power, energyRequired] = args;
            const energy = parseInt(energyRequired);

            if (
                superheroes[superheroName] &&
                superheroes[superheroName].powers.has(power) &&
                superheroes[superheroName].energy >= energy
            ) {
                superheroes[superheroName].energy -= energy;
                results.push(`${superheroName} has used ${power} and now has ${superheroes[superheroName].energy} energy!`);
            } else {
                results.push(`${superheroName} is unable to use ${power} or lacks energy!`);
            }
        } else if (action === "Train") {
            const [superheroName, trainingEnergy] = args;
            const energy = parseInt(trainingEnergy);

            if (superheroes[superheroName]) {
                const currentEnergy = superheroes[superheroName].energy;
                if (currentEnergy === 100) {
                    results.push(`${superheroName} is already at full energy!`);
                } else {
                    const energyGained = Math.min(energy, 100 - currentEnergy);
                    superheroes[superheroName].energy += energyGained;
                    results.push(`${superheroName} has trained and gained ${energyGained} energy!`);
                }
            }
        } else if (action === "Learn") {
            const [superheroName, newPower] = args;

            if (superheroes[superheroName]) {
                if (superheroes[superheroName].powers.has(newPower)) {
                    results.push(`${superheroName} already knows ${newPower}.`);
                } else {
                    superheroes[superheroName].powers.add(newPower);
                    results.push(`${superheroName} has learned ${newPower}!`);
                }
            }
        }
    }

    // Final output for each superhero
    for (const [superheroName, data] of Object.entries(superheroes)) {
        const powers = Array.from(data.powers).join(", ");
        const energy = data.energy;
        results.push(`Superhero: ${superheroName}`);
        results.push(` - Superpowers: ${powers}`);
        results.push(` - Energy: ${energy}`);
    }

    return results.join("\n");
}

// Example input
const input = [
    "2",
    "Iron Man-Repulsor Beams,Flight-100",
    "Thor-Lightning Strike,Hammer Throw-50",
    "Evil Defeated!"
];

// Execute and print the results
console.log(superheroAlliance(input));