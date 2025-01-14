window.addEventListener("load", solve);

function solve() {
    
    // функция за създаване на елементи
    function createElement(tag, properties, container){
        const element = document.createElement(tag);
        
        Object.keys(properties).forEach(key => {
            if ( typeof properties[key] === 'object') {
                Object.assign(element[key], properties[key]);
            } else {
                element[key] = properties[key];
            }
        });
        
        if (container) container.append(element);
        
        return element;
    }
    
    // Елементи
    // const inputs = document.querySelectorAll('form.laptop-info input'); //node list
    const inputs = [...document.querySelectorAll('#type, #age, #gender')]; //real array
    
    const btnAddEl = document.querySelector('#adopt-btn');
    
    const listCheckEl = document.querySelector('#adopted-list');
    
    btnAddEl.addEventListener('click', addHandler);
    
    
    function addHandler(e) {
        e.preventDefault();
        //test
        // console.log(e.target);
        
        //деструктурираме и създаваме арей
        const [type, age, gender] = inputs.map(field => field.value);
        
        if (! type || ! age || ! gender) return;
        
        //test object
        // console.log({type, age, gender});
        
        //ако работи заместваме с функ createEntry
        createEntry({type, age, gender});
        
        //изчистваме стойностите на инпутите
        inputs.forEach(field => field.value = '');
        
        //блокираме бутон add
        btnAddEl.disabled = true;
        
    }
    
    function createEntry({type, age, gender}) {
        //li.laptop-item > Article > p, p, p < button.btn.edit, button.btn.ok - взимам го от снимката в задачата
        
        // съсздаваме  li, след това ни трябва обект с пропъртитата, на кой елемент ще го добавим
        const entryEl = createElement('li', { dataset: {type, age, gender}}, listCheckEl );
        
        //съсздаваме article
        const articleEl = createElement('article', {}, entryEl);
        
        //съсздаваме p
        createElement('p', {textContent: 'Pet:' + type}, articleEl);
        createElement('p', {textContent: 'Gender: ' + gender}, articleEl);
        createElement('p', {textContent: 'Age: ' + age}, articleEl);
        
        //добавяме го към li което е entryEl
        const buttonsEl = createElement('div', { className: 'buttons'}, entryEl);
        createElement('button', { className: 'edit-btn', textContent: 'Edit', onclick: editHandler }, buttonsEl);
        createElement('button', { className: 'done-btn', textContent: 'Done', onclick: confirmHandler }, buttonsEl);
        
    }
    
    function editHandler(e) {
        //с тази функция връщаме обратно стойностите в инпут
        e.preventDefault();
        
        // //тестваме в конзолата дали получаваме правилния бутон при клик
        // console.log(e.target);
        
        //така ще получим достъп нагоре до първотоо li и инфото в него 
        const entryEl = e.target.closest('li'); //entryEl  е обект
        
        //по този начин имаме достъп до dataset property и правиме обект values
        const values = Object.values(entryEl.dataset);
        
        // // тест да видим какво има в dataset
        // console.log(JSON.stringify(entryEl.dataset, 0, 2));
        
        // //тест да погледна масивите
        // console.log(inputs, values);
        
        //закачваме на самите полета за всеки инпут от първия масив взимам стойността от втория и му я прикачвам като се движим по индекси
        inputs.forEach((field, index) => field.value = values[index]);
        
        entryEl.remove(); // маха го от листа
        
        btnAddEl.disabled = false;
        
    }
    
    function confirmHandler(e) {
        e.preventDefault();
        
        // //тестваме в конзолата дали получаваме правилния бутон при клик
        // console.log(e.target);
        
        //така ще получим достъп нагоре до първотоо li и инфото в него 
        const entryEl = e.target.closest('li'); //entryEl  е обект
        
        // маха бутоните
        entryEl.querySelectorAll('button').forEach(btn => btn.remove());
        
        // тук добавям clear бутона
        createElement('button', {className: 'clear-btn', textContent: 'Clear', onclick: clearHandler}, entryEl);
        
        btnAddEl.disabled = false;
        
    }
    
    function clearHandler(e) {
        const entryEl = e.target.closest('li');
        entryEl.remove();
        
        btnAddEl.disabled = false;
    }
    
}
