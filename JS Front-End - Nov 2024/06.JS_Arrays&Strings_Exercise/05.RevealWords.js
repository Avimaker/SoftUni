function solve(words, sentence) {
        const wordsArrey = words.split(', ')
        
        for (const w of wordsArrey) {
                sentence = sentence.replace('*'.repeat(w.length), w)
        }
        
        console.log(sentence);
 }










// solve('great', 'softuni is ***** place for learning new programming languages');	
// //softuni is great place for learning new programming languages

solve('great, learning', 'softuni is ***** place for ******** new programming languages');
//softuni is great place for learning new programming languages