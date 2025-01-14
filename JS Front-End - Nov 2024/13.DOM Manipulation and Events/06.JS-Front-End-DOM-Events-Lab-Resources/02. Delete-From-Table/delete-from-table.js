function deleteByEmail() {
     // Get input, result and table element references
    const customersEl = document.querySelectorAll('#customers tbody td:last-child');
    const emailInputEl = document.querySelector('input[name="email"]');
    const resultEl = document.querySelector('#result');
    
    // Get input text value
    const emailEl = emailInputEl.value;

    // if nothing fullfilled - nothing happened
    if (emailEl == '') return;

    // search for email in array of mails
    const foundEmail = Array.from(customersEl).find(el => el.textContent === emailEl);
    

    // if email has founded we delete it and print
    if (foundEmail) {
        foundEmail.parentElement.remove();
        resultEl.textContent = 'Deleted.';
    } else {
        resultEl.textContent = 'Not found.';
    }
    
    //reset input value
    emailInputEl.value = '';

    
}
