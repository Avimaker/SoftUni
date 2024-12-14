window.addEventListener("load", solve);

function solve() {
    
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
    
    const fields = [...document.querySelectorAll('#name, #time, #description')]; //spredwame oshte tuk
    const btnAddEl = document.querySelector('#add-btn');
    
    const listPreviewEl = document.querySelector('#preview-list');
    const listArchiveEl = document.querySelector('#archive-list');

    function createEntry({name, time, desc}) {
        const entryEl = createElement('li', {dataset: {name, time, desc}}, listPreviewEl);
        const articleEl = createElement('article', {}, entryEl);
        createElement('p', { textContent: name}, articleEl);
        createElement('p', { textContent: time}, articleEl);
        createElement('p', { textContent: desc}, articleEl);
        const buttonEl = createElement('div', {className: 'buttons'}, entryEl);
        createElement('button', {className: 'edit-btn', textContent: 'Edit', onclick: editHandler }, buttonEl);
        createElement('button', {className: 'next-btn', textContent: 'Next', onclick: nextHandler }, buttonEl);

    }

    btnAddEl.addEventListener('click', (e) => {
        e.preventDefault();

        // const [name, time , desc] = [...fields].map(field => field.value);
        const [name, time , desc] = fields.map(field => field.value); //sprednahme go oshte gore

        if (! name || ! time || ! desc) return;

        createEntry({name, time, desc});

        e.target.disabled = true;

        fields.forEach(field => field.value = '');
 
    } )    
    
    function editHandler(e) {
        const entryEl = e.target.closest('li');
        entryEl.remove();
        
        const values = [entryEl.dataset.name, entryEl.dataset.time, entryEl.dataset.desc];

        fields.forEach((field, index) => field.value = values[index]);
        btnAddEl.disabled = false; 
    }

    function nextHandler(e) {
        const entryEl = e.target.closest('li');
        entryEl.remove();

        entryEl.querySelector('div.buttons').remove();

        createElement('button', {className: 'archive-btn', textContent: 'Archive', onclick: archiveHandler}, entryEl);

        listArchiveEl.append(entryEl);


    }

    function archiveHandler(e) {
        const entryEl = e.target.closest('li');
        entryEl.remove();
        btnAddEl.disabled = false;
    }


}