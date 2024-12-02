document.addEventListener('DOMContentLoaded', solve);

function solve() {
    
    // Задаваме константите за преобразуване
    const timeUnits = {
        days: 1,
        hours: 24,
        minutes: 24 * 60,
        seconds: 24 * 60 * 60,
    };
    
    // Грабваме всички полета и бутони
    const daysInput = document.querySelector('#days-input');
    const hoursInput = document.querySelector('#hours-input');
    const minutesInput = document.querySelector('#minutes-input');
    const secondsInput = document.querySelector('#seconds-input');
    
    // Добавяме обработка на всяка форма
    document.querySelectorAll('form').forEach((form) => {
        form.addEventListener('submit', handleConversion);
    });
    
    
    // Функция за конвертиране
    function convert(value, unit) {
        const days = value / timeUnits[unit];
        return {
            days: days,
            hours: days * timeUnits.hours,
            minutes: days * timeUnits.minutes,
            seconds: days * timeUnits.seconds,
        };
    }
    
    // Функция за обработка на събитие
    function handleConversion(e) {
        e.preventDefault(); // Спира презареждането на страницата

        // Вземаме input полето и неговата стойност
        const inputField = e.target.querySelector('input[type="number"]');
        const value = Number(inputField.value);
        // Определяме типа на мерната единица от ID-то на формата
        const unit = e.target.id; // Това ще върне "days", "hours", "minutes" или "seconds"
        
        if (isNaN(value) || value <= 0) return; // Пропускаме некоректни стойности

        const converted = convert(value, unit);
        
        // Задаваме преобразуваните стойности в полетата
        daysInput.value = converted.days.toFixed(2);
        hoursInput.value = converted.hours.toFixed(2);
        minutesInput.value = converted.minutes.toFixed(2);
        secondsInput.value = converted.seconds.toFixed(2);
    }
    
}