// API functions

function loadResources(baseUrl, onSuccess) {
    fetch(baseUrl)
    .then(response => response.json())
    .then(onSuccess)
    .catch(error => console.error('Error: ', error));
}

function createResource(baseUrl, resource, onSuccess) {
    fetch(baseUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(resource)
    })
    .then(response => response.json())
    .then(onSuccess)
    .catch(error => console.error('Error: ', error));
}

function updateResource(baseUrl, resource, onSuccess) {
    fetch(baseUrl + resource._id, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(resource)
    })
    .then(response => response.json())
    .then(onSuccess)
    .catch(error => console.error('Error: ', error));
}

function deleteResource(baseUrl, resource, onSuccess) {
    fetch(baseUrl + resource._id, {
        method: 'DELETE'
    })
    .then(response => response.json())
    .then(onSuccess)
    .catch(error => console.error('Error: ', error));
}

// UTIL(create elements) functions

function createElement(tag, properties, container) {
    const element = document.createElement(tag)
    
    Object.keys(properties).forEach(key => {
        if (key === 'dataset') {
            Object.keys(properties.dataset).forEach(dataKey => {
                element.dataset[dataKey] = properties.dataset[dataKey];
            });
        } else if (typeof properties[key] === 'object') {
            element[key] ??= {};
            Object.assign(element[key], properties[key]);
        } else {
            element[key] = properties[key];
        }
    });
    
    if ( container ) container.append(element);
    
    return element;
}


function init() {
    // Global variables
    
    const baseUrl = 'http://localhost:3030/jsonstore/workout/';
    
    const inputs = [...document.querySelectorAll('#workout, #location, #date')];
    
    const btnAddEntryEl = document.querySelector('#add-workout');
    const btnEditEntryEl = document.querySelector('#edit-workout');
    
    const listEntriesEl = document.querySelector('#list');
    
    // attach event handlers
    btnAddEntryEl.addEventListener('click', createHandler);
    btnEditEntryEl.addEventListener('click', updateHandler);
    
    // DOM function
    
    function loadEntries() {
        listEntriesEl.innerHTML = '';
        loadResources(baseUrl, (result) => {
            // //test
            // console.log(result);
            Object.values(result).forEach(createEntry);
        });
    }
    
    function createEntry({ workout, location, date, _id }) {
        // // test
        // console.log({model, service, date, _id});

        // from screenshot
        // div.container > h2, h3, h3, div buttons-container > button.change-btn, button.delete-btn

        const entryEl = createElement('div', { className: 'container', dataset: { workout, location, date, _id }}, listEntriesEl);
        createElement('h2', { textContent: workout }, entryEl);
        createElement('h3', { textContent: location }, entryEl);
        createElement('h3', { textContent: date }, entryEl);
        const buttonsEl = createElement('div', { id: 'buttons-container' }, entryEl);
        createElement('button', { className: 'change-btn', textContent: 'Change', onclick: changeHandler }, buttonsEl);
        createElement('button', { className: 'delete-btn', textContent: 'Delete', onclick: deleteHandler }, buttonsEl);
    }
    
    function deleteEntry({ _id }) {
        const entryEl = listEntriesEl.querySelector(`.container[data-_id="${_id}"]`);
        if (entryEl) entryEl.remove();
    }
    
    // Event handlers

    function createHandler(e) {
        e.preventDefault();

        const [ workout, location, date ] = inputs.map(field => field.value);

        if ( ! workout || ! location || ! date ) return;

        const resourceObj = { workout, location, date };

        createResource(baseUrl, resourceObj, (result) => {
            createEntry(result);
        });

        inputs.forEach(field => field.value = '');
    }

    // ne raboti
    function changeHandler(e) {
        const entryEl = e.target.closest('.container');
        const values = Object.values(entryEl.dataset);

        entryEl.classList.add('active');

        inputs.forEach((field, index) => field.value = values[index]);

        // entryEl.remove();

        btnAddEntryEl.disabled = true;
        btnEditEntryEl.disabled = false;
        
    }

    function updateHandler(e) {
        e.preventDefault();

        const [ workout, location, date ] = inputs.map(field => field.value);

        if ( ! workout || ! location || ! date ) return;

        const entryEl = listEntriesEl.querySelector('.active');

        const resourceObj = { workout, location, date, _id: entryEl.dataset._id };

        updateResource(baseUrl, resourceObj, (result) => {
            loadEntries();
            inputs.forEach(field => field.value = '');
            btnAddEntryEl.disabled = false;
            btnEditEntryEl.disabled = true;
        });
    }

    function deleteHandler(e) {
        const entryEl = e.target.closest('.container');
        if (!entryEl) return;
    
        const { _id } = entryEl.dataset;
    
        deleteResource(baseUrl, { _id }, (result) => {
            deleteEntry({ _id });
        });
    }

    loadEntries();
    
}

document.addEventListener('DOMContentLoaded', init);