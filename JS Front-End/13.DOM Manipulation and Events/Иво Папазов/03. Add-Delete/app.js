function addItem() {
    // Get element references
    const itemsElement = document.getElementById('items');
    const newItemTextElement = document.getElementById('newItemText');

    // Create new element with textContent of the input
    const liElement = document.createElement('li');
    liElement.textContent = newItemTextElement.value;

    // Create delete button
    const deleteButton = document.createElement('a');
    deleteButton.textContent = '[Delete]';
    // deleteButton.setAttribute('href', '#');
    deleteButton.href = '#';

    // Attach event to delete button
    deleteButton.addEventListener('click', (e) => {
        // liElement.remove(); // Tight coupling NEY
        e.currentTarget.parentElement.remove(); // Loose coupling YEY
    });

    // Add button to liElement
    liElement.append(deleteButton);

    // Attach liElement to DOM
    itemsElement.appendChild(liElement);

    // clean up input
    newItemTextElement.value = '';
}
