function solve() {
  const input = document.querySelector('#text').value;
  const currentCase = document.querySelector('#naming-convention').value;

  let words = input.toLowerCase().split(' ');

  let resultEl = [];

  switch (currentCase) {
    case 'Camel Case':
      resultEl = words[0];
      for (let i = 1; i < words.length; i++) {
          resultEl += words[i][0].toUpperCase() + words[i].slice(1);   
      }
      break;
  case 'Pascal Case':
      for (let i = 0; i < words.length; i++) {
          resultEl += words[i][0].toUpperCase() + words[i].slice(1);   
      }
      break;

    default:
      resultEl = 'Error!';
      break;
  }

  document.querySelector('#result').textContent = resultEl;
  
}