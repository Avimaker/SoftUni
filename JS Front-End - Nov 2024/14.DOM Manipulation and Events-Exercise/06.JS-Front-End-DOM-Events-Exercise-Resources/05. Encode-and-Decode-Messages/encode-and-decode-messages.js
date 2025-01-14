document.addEventListener('DOMContentLoaded', solve);

function solve() {
    // Извличане на елементите от DOM
    const encodeTextarea = document.querySelector('#encode textarea');
    const encodeButton = document.querySelector('#encode button');
    const decodeTextarea = document.querySelector('#decode textarea');
    const decodeButton = document.querySelector('#decode button');

    // Функция за кодиране на съобщението
    encodeButton.addEventListener('click', (event) => {
        event.preventDefault(); // Предотвратяване на презареждането на страницата

        const message = encodeTextarea.value;
        const encodedMessage = Array.from(message)
            .map(char => String.fromCharCode(char.charCodeAt(0) + 1)) // Добавяме 1 към ASCII кода
            .join('');

        // Прехвърляне на кодирането в целевото поле
        decodeTextarea.value = encodedMessage;
        encodeTextarea.value = ''; // Изчистване на полето за изпращане
    });

    // Функция за декодиране на съобщението
    decodeButton.addEventListener('click', (event) => {
        event.preventDefault(); // Предотвратяване на презареждането на страницата

        const encodedMessage = decodeTextarea.value;
        const decodedMessage = Array.from(encodedMessage)
            .map(char => String.fromCharCode(char.charCodeAt(0) - 1)) // Изваждаме 1 от ASCII кода
            .join('');

        // Замяна на кодирането с декодиран текст
        decodeTextarea.value = decodedMessage;
    });
}