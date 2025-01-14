function solve(text, word) {
    // const pattern = /\bis\b/g;
    const pattern = new RegExp(`\\b${word}\\b`, 'g');
    
    const result = text.match(pattern) || [];

    console.log(result.length);
}

solve('az toi ti toi tq to nie vie az az az',
'te'
);


