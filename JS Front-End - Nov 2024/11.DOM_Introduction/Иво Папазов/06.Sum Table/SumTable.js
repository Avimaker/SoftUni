function sumTable() {
    // Solution 1
    // const resultElemnt = document.getElementById('sum');

    // const trElements = document.querySelectorAll('table tbody tr');
    // let sum = 0;

    // for (const trElement of trElements) {
    //     const secondElement = trElement.children[1];

    //     if (secondElement.tagName === 'TD' && secondElement.id !== 'sum') {
    //         const price = Number(secondElement.textContent);
    //         sum += price;
    //     }
    // }

    // resultElemnt.textContent = sum;

    // Solution 2 - fancy solution
    const resultElemnt = document.getElementById('sum');
    const tdElements = document.querySelectorAll('table tr td:nth-child(2):not(#sum)');

    resultElemnt.textContent = Array
        .from(tdElements)
        .reduce((sum, td) => sum + Number(td.textContent), 0);;
}
