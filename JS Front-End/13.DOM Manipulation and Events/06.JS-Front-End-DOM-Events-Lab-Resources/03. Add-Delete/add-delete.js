function addItem() {
    // //create elements for items and input
    // const itemsEl = document.querySelector('#items');
    // const newInputText = document.querySelector('#newItemText');
    
    // //create element for appending
    // const liElement = document.createElement('li');
    // liElement.textContent = newInputText.value;
    
    // // Create delete button
    // const deleteButton = document.createElement('a');
    // deleteButton.textContent = ' [Delete]';
    // // deleteButton.setAttribute('href', '#');
    // deleteButton.href = '#';
    
    // //attach event to delete button
    // deleteButton.addEventListener("click", (e) => {
        //    e.currentTarget.parentElement.remove();
    // });
    
    // //append delete button to element
    // liElement.append(deleteButton);
    
    // //append the new element into DOM
    // if  (!newInputText.value == ' ') {
    //     itemsEl.appendChild(liElement);
    // }
    
    // //reset input field
    // newInputText.value = '';
    
    
    //Вариант 2
    // Вземаме елементите от DOM
    const itemsEl = document.querySelector('#items');
    const newInputText = document.querySelector('#newItemText');
    
    // Добавяме събитие за Enter
    newInputText.addEventListener("keypress", (e) => {
        if (e.key === 'Enter' && newInputText.value.trim() !== '') {
            const liElement = createListItem(newInputText.value);
            itemsEl.appendChild(liElement);
            
            // Нулираме полето за въвеждане
            newInputText.value = '';
        }
    });
    
    
    // Добавяме нов елемент при клик на бутона с Проверка за празен вход
    if (newInputText.value.trim() !== '') {
        // Създаваме нов <li> с бутон [Delete] и го добавяме към списъка
        const liElement = createListItem(newInputText.value);
        itemsEl.appendChild(liElement);
    }
    
    // Нулираме полето за въвеждане
    newInputText.value = '';
    
    
    
}

// Функция за създаване на нов <li> елемент с бутон [Delete]
function createListItem(text) {
    // Създаваме <li> елемент
    const liElement = document.createElement('li');
    liElement.textContent = text;
    
    // Създаваме бутон [Delete]
    const deleteButton = document.createElement('a');
    deleteButton.textContent = ' [Delete]';
    deleteButton.href = '#';
    
    // Добавяме събитие за изтриване
    deleteButton.addEventListener("click", (e) => {
        e.currentTarget.parentElement.remove(); // Премахваме целия <li>
    });
    
    // Добавяме бутона към <li>
    liElement.append(deleteButton);
    
    return liElement;
}
