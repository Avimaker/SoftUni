document.addEventListener('DOMContentLoaded', () => {

    function loadMatches(baseUrl, onSuccess) {
        fetch(baseUrl)
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
    }

    function createMatch(baseUrl, match, onSuccess) {
        fetch(baseUrl, {
            method: 'POST',
            body: JSON.stringify(match)
        })
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
    }

    function updateMatch(baseUrl, match, onSuccess) {
        fetch(baseUrl + match._id, {
            method: 'PUT',
            body: JSON.stringify(match)
        })
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
    }

    function deleteMatch(baseUrl, match, onSuccess) {
        fetch(baseUrl + match._id, {
            method: 'DELETE'
        })
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
    }

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

    //start
    
    const baseUrl = 'http://localhost:3030/jsonstore/matches/';

    // правиме масив от всички филдове и го спредваме
    const fields = [...document.querySelectorAll('#form form input[type="text"]')]; 

    //тест
    // console.log(fields);

    const btnAddMatchEl = document.querySelector('#add-match');
    const btnEditMatcEl = document.querySelector('#edit-match');
 
    const listEl = document.querySelector('#list');
    
    btnAddMatchEl.addEventListener('click', createHandler);
    btnEditMatcEl.addEventListener('click', updateHandler);


    // func load entry
    function loadEntries() {
        listEl.innerHTML = ''; //nulirame spisaka
        loadMatches(baseUrl, (result) => {
            // console.log(result);//test
            Object.values(result).forEach(createEntry); 
        } ); 
    }
    loadEntries();
    
    //func create entry
    function createEntry({host, score, guest, _id}) {
        const entryEl = createElement('li', {className: 'match', dataset: {host, score, guest, _id}}, listEl);
        const infoEl = createElement('div', {clasName: 'info'}, entryEl);
        createElement('p', { textContent: host}, infoEl);
        createElement('p', { textContent: score}, infoEl);
        createElement('p', { textContent: guest}, infoEl);
        const buttonEl = createElement('div', {className: 'btn-wrapper'}, entryEl);
        createElement('button', {className: 'change-btn', textContent: 'Change', onclick: editHandler }, buttonEl);
        createElement('button', {className: 'delete-btn', textContent: 'Delete', onclick: deleteHandler }, buttonEl);
    }

    //func delete entry
    function deleteEntry({host, score, guest, _id}) {
        listEl.querySelector(`li[data-_id="${_id}"]`).remove();
    }

    //func create handler
    function createHandler(e) {
        e.preventDefault();
        
        const [host, score, guest] = fields.map(field => field.value);

        if (! host || ! score || ! guest) return;

        const match = {host, score, guest};

        createMatch(baseUrl, match, (result) => {
            createEntry(result);
        });

        fields.forEach(field => field.value = '');

    }

    //editHandler func
    function editHandler(e) {
        const entryEl = e.target.closest('li');
        const values = Object.values(entryEl.dataset);
        // const match = Object.assign({}, entryEl.dataset);

        entryEl.classList.add('active');

        fields.forEach((field, index) => field.value = values[index]);
        // fields.forEach((field, index) => field.value = Object.values(match)[index]);
    
        btnAddMatchEl.disabled = true;
        btnEditMatcEl.disabled = false;
    
    }
    
    // update handler
    function updateHandler(e) {
        e.preventDefault();
        // debugger;

        const [host, score, guest] = fields.map(field => field.value);

        if (! host || ! score || ! guest) return;

        const entryEl = listEl.querySelector('li.active');

        const match = {host, score, guest, _id: entryEl.dataset._id};

        updateMatch(baseUrl, match, (result) => {
            loadEntries();
            fields.forEach(field => field.value = '');
            btnAddMatchEl.disabled = false;
            btnEditMatcEl.disabled = true;
        
        });


    }



    //deleteHandler func
    function deleteHandler(e) {
        const entryEl = e.target.closest('li');
        
        const match = Object.assign({}, entryEl.dataset);
       
        deleteMatch(baseUrl, match, (result) => {
            deleteEntry(result);
        });
    }


    

});