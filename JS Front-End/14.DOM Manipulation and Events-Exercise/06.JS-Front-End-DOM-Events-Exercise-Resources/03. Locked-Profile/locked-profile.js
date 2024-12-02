document.addEventListener('DOMContentLoaded', solve);

function solve() {
    // Извличане на всички профили
    const profiles = document.querySelectorAll('.profile');

    profiles.forEach(profile => {
        // Намиране на ключовите елементи за работа
        const lockRadio = profile.querySelector('input[type="radio"][id$="Lock"]');
        const unlockRadio = profile.querySelector('input[type="radio"][id$="Unlock"]');
        const hiddenFields = profile.querySelector('.hidden-fields');
        const button = profile.querySelector('button');

        // Добавяне на обработчик на бутона
        button.addEventListener('click', () => {
            if (unlockRadio.checked) {
                // Проверка дали информацията е скрита или показана
                if (hiddenFields.style.display === 'block') {
                    hiddenFields.style.display = 'none';
                    button.textContent = 'Show more';
                } else {
                    hiddenFields.style.display = 'block';
                    button.textContent = 'Hide it';
                }
            }
        });
    });
}