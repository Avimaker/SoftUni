function callback() {
    console.log('Second');
}

function main() {
    console.log('First');

    setTimeout(callback, 0);
    
    console.log('Third');
}

main();
