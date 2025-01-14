function logTruthiness(val) {
    if (val) {
        console.log('Truthy!');
    } else {
        console.log('Falsy');
    }
}

console.log(typeof nan);
logTruthiness(NaN);
console.log(typeof undefined);
logTruthiness(undefined);
console.log(typeof 0);
logTruthiness(0);
console.log(typeof '');
logTruthiness('');

console.log(typeof {});
logTruthiness({});
console.log(typeof []);
logTruthiness([]);