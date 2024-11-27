function addItem() {
    // get element references ul and input
    const itemsElement = document.getElementById('items');
    const inputElement = document.getElementById('newItemText');

    // read text input 
    const itemText = inputElement.value;

    // create li element for the ul
    const liElement = document.createElement('li');
    
    // Add text content to li element
    liElement.textContent = itemText;

    // append li element to the ul
    itemsElement.appendChild(liElement);

    // clear input value
    inputElement.value = '';
}
