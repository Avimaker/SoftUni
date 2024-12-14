function getInfo() {
    
    
    // Get references to necessary DOM elements
    const stopIdInput = document.getElementById('stopId');
    const stopNameDiv = document.getElementById('stopName');
    const busesList = document.getElementById('buses');
    
    // Clear previous results
    stopNameDiv.textContent = '';
    busesList.innerHTML = '';
    
    // Extract the entered stop ID
    const stopId = stopIdInput.value;
    
    // Define the API URL
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;
    
    // Fetch the bus stop information
    fetch(url)
    .then((response) => {
        if (!response.ok) {
            throw new Error('Request failed');
        }
        return response.json();
    })
    .then((data) => {
        // Display the bus stop name
        stopNameDiv.textContent = data.name;
        
        // Display the buses and their arrival times
        for (const busId in data.buses) {
            const time = data.buses[busId];
            const listItem = document.createElement('li');
            listItem.textContent = `Bus ${busId} arrives in ${time} minutes`;
            busesList.appendChild(listItem);
        }
    })
    .catch(() => {
        // Handle errors by displaying "Error" and clearing the list
        stopNameDiv.textContent = 'Error';
        busesList.innerHTML = '';
    });
}