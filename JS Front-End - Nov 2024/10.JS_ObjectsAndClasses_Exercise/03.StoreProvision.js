// function solve(stock, ordered) {

//     const storage = {};

//     for (let i = 0; i < stock.length; i+=2) {
//         storage[stock[i]] = Number(stock[i+1]);
//     }

//     for (let i = 0; i < ordered.length; i+=2) {
//         if(!storage.hasOwnProperty(ordered[i])) {
//             storage[ordered[i]] = 0;
//         }
//         storage[ordered[i]] += Number(ordered[i+1]);
//     }

//     // console.log(JSON.stringify(storage, 0 , 4)); //for test

//     for (const item in storage) {
//         console.log(`${item} -> ${storage[item]}`);
//     }
// }


function solve(stock, ordered) {
    const storage = [... stock, ... ordered ].reduce((storage, product, i, array) => {
        if (i % 2 == 0) storage[product] = (storage[product] || 0) + Number(array[i + 1]);
        return storage;
    }, {});

    // for (const item in storage) {
    //     console.log(`${item} -> ${storage[item]}`);
    // }
    
    Object.entries(storage).forEach(([product, quantity]) => {
        console.log(`${product} -> ${quantity}`);    
    });
}


solve(['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'])