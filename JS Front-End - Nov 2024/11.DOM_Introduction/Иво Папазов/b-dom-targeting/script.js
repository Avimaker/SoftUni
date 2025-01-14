// First targeting method - by id
const moveListElement = document.getElementById('movie-list');
console.log(moveListElement);

// Second targeting method - by class name
const headingElements = document.getElementsByClassName('heading'); // Live HTMLCollection is the result

console.log(headingElements[0]); // it can be access by index
    
for (const headingElement of headingElements) { // it's iterable
    console.log(headingElement);
}

// Third targeting method - by tag name
const movieListElements = document.getElementsByTagName('li'); // Returns Live HTMLCollection
console.log(movieListElements);

// Fourth targeting method - by css selector
const favouriteMovieElement = document.querySelector('#movie-list li:first-child'); // Returns single element
console.log(favouriteMovieElement.textContent);

const allMovieElements = document.querySelectorAll('#movie-list li'); // Returns Static NodeList
console.log(allMovieElements); // Acceass by index or iterate with for-of

const liveNodeList = moveListElement.childNodes; // Returns live NodeList;

// Convert NodeList or HTMLCollection to array
const allMovieElementsArray = Array.from(allMovieElements);
// const allMovieElementsArray = [...allMovieElements]; // Equivalent convert
console.log(allMovieElementsArray);
