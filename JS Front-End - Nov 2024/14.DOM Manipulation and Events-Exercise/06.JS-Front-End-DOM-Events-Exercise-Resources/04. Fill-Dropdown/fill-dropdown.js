document.addEventListener('DOMContentLoaded', solve);

function solve() {
    // Вземаме референции към елементите от DOM
    const textInput = document.getElementById('newItemText');
    const valueInput = document.getElementById('newItemValue');
    const menu = document.getElementById('menu');
    const form = document.querySelector('form');

    // Добавяме обработчик на събитие за изпращане на формата
    form.addEventListener('submit', (event) => {
        event.preventDefault(); // Предотвратяваме презареждането на страницата

        const text = textInput.value.trim();
        const value = valueInput.value.trim();

        if (text && value) {
            // Създаваме нов <option> елемент
            const option = document.createElement('option');
            option.textContent = text;
            option.value = value;

            // Добавяме го към <select> елемента
            menu.appendChild(option);

            // Изчистваме входните полета
            textInput.value = '';
            valueInput.value = '';
        }
    });
}