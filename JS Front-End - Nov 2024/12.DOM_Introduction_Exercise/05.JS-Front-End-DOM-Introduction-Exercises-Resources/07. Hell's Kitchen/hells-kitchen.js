function solve() {
    const input = document.querySelector('#inputs textarea').value;
    
    const outputBestRest = document.querySelector('#outputs #bestRestaurant p');
    const outputBestWorkers = document.querySelector('#outputs #workers p');
    
    if (!input) return;
    
    console.log(input);
    
    const restaurants = JSON.parse(input)
    .reduce((acc, entry) => {
        const [name, workersData] = entry.split(' - ');
        const workers = workersData.split(', ')
        .map(workersData => {
            const [name, slary] = workersData.split(' ');
            return {name, salary: Number(slary)};
        });
        acc[name] ??= {workers: []} 
        acc[name].workers.push(...workers);
        
        return acc;
    }, {})
    
    console.log(restaurants);
    
    function getAvgSalary(restaurantsData) {
        const allSalaries = restaurantsData.workers
        .reduce((allSalaries, worker) => allSalaries + worker.salary, 0);        
        return allSalaries / restaurantsData.workers.length;
    }
    
    const [ bestRestaurantKey ] = Object.keys(restaurants)
    .sort((a, b) => getAvgSalary(restaurants[b]) - getAvgSalary(restaurants[a]));
    
    const bestWorkers = restaurants[bestRestaurantKey].workers
    .sort((a, b) => b.salary - a.salary);
    
    outputBestRest.textContent = `Name: ${bestRestaurantKey} `;
    outputBestRest.textContent += `Average Salary: ${getAvgSalary(restaurants[bestRestaurantKey]).toFixed(2)} `;
    outputBestRest.textContent += `Best Salary: ${bestWorkers[0].salary.toFixed(2)}`;
    
    outputBestWorkers.textContent = bestWorkers.map(w => `Name: ${w.name} With Salary: ${w.salary}`).join(' ');
}