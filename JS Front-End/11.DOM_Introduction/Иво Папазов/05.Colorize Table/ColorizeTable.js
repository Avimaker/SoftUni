function colorize() {
    // Solution 1 - With iteration
    // const tableElement = document.querySelector('table tbody');
    // const tableRowElemens = tableElement.children;

    // for (let i = 0; i < tableRowElemens.length; i += 2) {
    //     tableRowElemens[i].style.backgroundColor = 'teal';
    // }

    // Solution 2 - With css selector
    const evenTableRowElements = document.querySelectorAll('table tbody tr:nth-child(even)')

    for (const trElement of evenTableRowElements) {
        trElement.style.backgroundColor = 'teal';
    }
}
