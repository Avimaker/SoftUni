// Create promise
const marriagePromise = new Promise((resolve, reject) => {
    setTimeout(() => {
        if (Math.random() < 0.5) {
            resolve('Just Married!');
        } else {
            reject('It\'s me, it\'s not you!');
        }
    }, 2000);
});

// Pending state
console.log(marriagePromise);

// Consume promise
marriagePromise
    .then((result) => { // fufilled state
        console.log(result);
    })
    .catch((reason) => { // failed state
        console.log('Merriage canceled: ', reason);
    })
    .finally(() => {
        console.log('Pay the wedding');
    })

// Promise all - if one rejects all rejects
Promise.all([
    marriagePromise,
    Promise.resolve('Some promise resolved'),
    'Pesho',
    // Promise.reject('failed opperation'),
    20,
])
    .then((result) => {
        console.log(result);
    })
    .catch(err => {
        console.log(err);
    })

// Promise.allSettled - some may reject
Promise.allSettled([
    marriagePromise,
    Promise.resolve('Some promise resolved'),
    'Pesho',
    Promise.reject('failed opperation'),
    20,
])
    .then((result) => {
        console.log(result);
    })
    .catch(err => {
        console.log(err);
    })

// Promise.race() - resolves the fastest
