function solve() {
    const input = document.querySelector('#input');
    const output = document.querySelector('#output');
    
    const sentences = input.value.split('. ');
    const sentPerPar = 3;

    const numberOfParagraphs = Math.ceil(sentences.length / sentPerPar);

    let out = '';
      
    for (let i = 0; i < numberOfParagraphs; i++) {
      const start = i * sentPerPar;
      const end = start + sentPerPar;
      
      // out += '<p>';
      // out += sentences.slice(start, end).join('. ');
      // out += '</p>';

      out += `<p> ${sentences.slice(start, end).join('. ')} </p>`;

    }
    output.innerHTML = out;
}
