window.addEventListener("load", solve);

function solve() {

    // Get references to DOM elements
const addBtn = document.querySelector('#add-btn');
const clearBtn = document.querySelector('.clear');
const modelInput = document.querySelector('#laptop-model');
const storageInput = document.querySelector('#storage');
const priceInput = document.querySelector('#price');
const checkList = document.querySelector('#check-list');
const laptopList = document.querySelector('#laptops-list');

// Add button click event
addBtn.addEventListener('click', () => {
    const model = modelInput.value.trim();
    const storage = storageInput.value.trim();
    const price = priceInput.value.trim();

    if (!model || !storage || !price) {
        return; // Do nothing if any field is empty
    }

    const li = document.createElement('li');
    li.className = 'laptop-item';

    const article = document.createElement('article');
    article.innerHTML = `
        <p>${model}</p>
        <p>Memory: ${storage} TB</p>
        <p>Price: ${price}$</p>
    `;

    const editBtn = document.createElement('button');
    editBtn.className = 'btn edit';
    editBtn.textContent = 'edit';

    const okBtn = document.createElement('button');
    okBtn.className = 'btn ok';
    okBtn.textContent = 'ok';

    li.appendChild(article);
    li.appendChild(editBtn);
    li.appendChild(okBtn);
    checkList.appendChild(li);

    // Disable Add button and clear input fields
    addBtn.disabled = true;
    modelInput.value = '';
    storageInput.value = '';
    priceInput.value = '';

    // Edit button functionality
    editBtn.addEventListener('click', () => {
        modelInput.value = model;
        storageInput.value = storage;
        priceInput.value = price;

        li.remove();
        addBtn.disabled = false;
    });

    // Ok button functionality
    okBtn.addEventListener('click', () => {
        li.removeChild(editBtn);
        li.removeChild(okBtn);
        laptopList.appendChild(li);
        addBtn.disabled = false;
    });
});

// Clear button functionality
clearBtn.addEventListener('click', () => {
    location.reload(); // Reload the application
});


}