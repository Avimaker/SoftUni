function addItem() {
    
    //create elements for items and input
    const itemsEl = document.querySelector('#items');
    const newInputText = document.querySelector('#newItemText');
    
    //create element for appending
    const liElement = document.createElement('li');
    //take the value for new element
    liElement.textContent = newInputText.value;
    //append the new element into DOM
    if  (!newInputText.value == '') {
        itemsEl.appendChild(liElement);
    }

    //reset input field
    newInputText.value = '';

    

    // console.log(itemsEl);
    // console.log(newInputText);
    // console.log(liElement);

}
