document.addEventListener('DOMContentLoaded', solve);

function solve() {
   
   // get element references 
   const formEl = document.querySelector('#task-input');
   const resultEl = document.querySelector('#content');
      
   // read text input 
   formEl.addEventListener('submit', e => {
      e.preventDefault(); // забраняваме на ентера или клика да презареди страницата
      const sections = formEl.querySelector('input[type="text"]').value.split(', ');

      // create <div> and <p> element

      sections.forEach(section => {
         const newDivEl = document.createElement("div");
         const newPEl = document.createElement("p");

         // Add text content to <p> element
         newPEl.textContent = section;
         newPEl.style.display = "none";

         // Append <p> to <div> element
         newDivEl.append(newPEl);
         newDivEl.addEventListener("click", e => {
            e.target.querySelector('p').style.display = "block";
         })

         // Append <div> to result
         resultEl.append(newDivEl);

      })

    
   });
   
   
   
   
   
   
   
}