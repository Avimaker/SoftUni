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
    const inputs = [...document.querySelectorAll('form.registerEvent input')]; //real array
    
    const btnAddEl = document.querySelector('#next-btn');

    const listCheckEl = document.querySelector('#preview-list');
    const listWishEl = document.querySelector('#event-list');

    btnAddEl.addEventListener('click', addHandler);
    
    function createEntry({email, event, location}) {
        //li.application > Article > h4, p, > strong, br, "event" <> p, > strong, br, "event" < action.btn.edit, action.btn.applay - взимам го от снимката в задачата
        
        // съсздаваме  li, след това ни трябва обект с пропъртитата, на кой елемент ще го добавим
        const entryEl = createElement('li', {className: 'application', dataset: {email, event, location}}, listCheckEl );
        
        //съсздаваме article
        const articleEl = createElement('article', {}, entryEl);
        
        //съсздаваме h4
        createElement('h4', {textContent: email}, articleEl);

        //съсздаваме p
        const pEl = createElement('p', {}, articleEl);

        createElement('strong', {textContent: 'Event:'}, pEl);
        createElement('br', {}, pEl);
        createElement('p', {textContent: event}, pEl);
        
        const p2El = createElement('p', {}, articleEl);
        createElement('strong', {textContent: 'Location:'}, p2El);
        createElement('br', {}, p2El);
        createElement('p', {textContent: location}, p2El);
        
        //добавяме го към li което е entryEl
        createElement('button', {className: 'action-btn edit', textContent: 'edit', onclick: editHandler}, entryEl);
        createElement('button', {className: 'action-btn applay', textContent: 'applay', onclick: confirmHandler}, entryEl);
        
    }

    function addHandler(e) {
        e.preventDefault();
        //test
        // console.log(e.target);
        
        //деструктурираме и създаваме арей
        const [email, event, location] = inputs.map(field => field.value);
        
        if (! email || ! event || ! location) return;
        
        //test object
        // console.log({email, event, location});
        
        //ако работи заместваме с функ createEntry
        createEntry({email, event, location});
        
        //изчистваме стойностите на инпутите
        inputs.forEach(field => field.value = '');
        
        //блокираме бутон add
        btnAddEl.disabled = true;
        
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
        
        entryEl.remove(); // маха го от листа, но остава в паметта
        
        // тук го взима в паметта и маха бутоните
        entryEl.querySelectorAll('button').forEach(btn => btn.remove());
        
        // взимаме го от паметта без бутони и го добявяме в списъка
        listWishEl.append(entryEl);
       
        btnAddEl.disabled = false;
        
    }

}