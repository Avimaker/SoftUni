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
    const inputs = [...document.querySelectorAll('form.laptop-info input')]; //real array
    
    const btnAddEl = document.querySelector('#add-btn');
    const btnClearEl = document.querySelector('#laptops-container button.clear'); 
    
    const listCheckEl = document.querySelector('#check-list');
    const listWishEl = document.querySelector('#laptops-list');
    
    btnAddEl.addEventListener('click', addHandler);
    btnClearEl.addEventListener('click', clearHandler);
    
    
    function createEntry({model, storage, price}) {
        //li.laptop-item > Article > p, p, p < button.btn.edit, button.btn.ok - взимам го от снимката в задачата
        
        // съсздаваме  li, след това ни трябва обект с пропъртитата, на кой елемент ще го добавим
        const entryEl = createElement('li', {className: 'laptop-item', dataset: {model, storage, price}}, listCheckEl );
        
        //съсздаваме article
        const articleEl = createElement('article', {}, entryEl);
        
        //съсздаваме p
        createElement('p', {textContent: model}, articleEl);
        createElement('p', {textContent: 'Memory: ' + storage + ' TB'}, articleEl);
        createElement('p', {textContent: 'Price: ' + price + '$'}, articleEl);
        
        //добавяме го към li което е entryEl
        createElement('button', {className: 'btn edit', textContent: 'edit', onclick: editHandler}, entryEl);
        createElement('button', {className: 'btn ok', textContent: 'ok', onclick: confirmHandler}, entryEl);
        
    }
    
    function addHandler(e) {
        e.preventDefault();
        //test
        // console.log(e.target);
        
        //деструктурираме и създаваме арей
        const [model, storage, price] = inputs.map(field => field.value);
        
        if (! model || ! storage || ! price) return;
        
        //test object
        // console.log({model, storage, price});
        
        //ако работи заместваме с функ createEntry
        createEntry({model, storage, price});
        
        //изчистваме стойностите на инпутите
        inputs.forEach(field => field.value = '');
        
        //блокираме бутон add
        btnAddEl.disabled = true;
        
    }
    
    function clearHandler(e) {
        e.preventDefault();

        listWishEl.innerHTML = '';
        
        // // тестваме в конзолата дали получаваме правилния бутон при клик
        // console.log(e.target);
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
    
    
    /*
    DOM Functions
    - createEntry
    Handlers
    - addHandler
    - clearHandler
    - editHandler
    - confirmHandler
    */
}