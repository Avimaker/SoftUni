function solve(input) {
    
    let list = [];

    input.forEach(lineInput => {
        let [name, level, items] = lineInput.split(' / ');
        
        // level = parseInt(level, 10);
        level = Number(level);
        // items = items.split(', '); //няма нужда да се сплитва

        const hero = {name, level, items}

        list.push(hero);  
    });
    
    list.sort((a, b) => a.level - b.level);

    // console.log(JSON.stringify(list, 0, 2));

    list.forEach(hero => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    })
}










solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]);

// Hero: Hes
// level => 1
// items => Desolator, Sentinel, Antara
// Hero: Derek
// level => 12
// items => BarrelVest, DestructionSword
// Hero: Isacc
// level => 25
// items => Apple, GravityGun
