function deleteByEmail() {
    // Get input, result and table element references
    const customerTableElement = document.getElementById('customers');
    const inputElement = document.querySelector('input[type=text][name=email]');
    const resultElement = document.getElementById('result');

    // Get input text value
    const searchEmail = inputElement.value;

    // Get all td elements
    const tdElements = customerTableElement.querySelectorAll('tbody td:last-child');

    // Search for email
    const searchElement = Array.from(tdElements).find(el => el.textContent === searchEmail);

    // remove element if found and print result
    if (searchElement) {
        searchElement.parentElement.remove();
        resultElement.textContent = 'Deleted.';
    } else {
        resultElement.textContent = 'Not found.';
    }
}
