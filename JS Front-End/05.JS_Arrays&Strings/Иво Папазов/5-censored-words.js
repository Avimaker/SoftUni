function solve(text, word) {
    const result = text.replaceAll(word, '*'.repeat(word.length));

    console.log(result);
}

function solveWithoutReplaceAll(text, word) {
    while (text.includes(word)) {
        text = text.replace(word, '*'.repeat(word.length));
    }

    console.log(text);
}

solveWithoutReplaceAll('A small sentence with some small words', 'small');
