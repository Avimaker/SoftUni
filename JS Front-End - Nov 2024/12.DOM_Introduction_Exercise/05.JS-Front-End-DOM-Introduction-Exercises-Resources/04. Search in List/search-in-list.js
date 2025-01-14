function solve() {
   const towns = document.querySelectorAll('#towns li');
   const searchText = document.querySelector('#searchText').value.toLowerCase();
   const result = document.querySelector('#result');
   
   if (searchText == '') return;
      
   towns.forEach(town => {
      town.classList.remove('match');
      town.style.fontWeight = 'normal';
      town.style.textDecoration = "none";   
      
      if (town.textContent.toLowerCase().includes(searchText)){
         town.classList.add('match');
         town.style.fontWeight = 'bold';
         town.style.textDecoration = "underline";
      }
   });
   
   result.textContent = `${document.querySelectorAll('.match').length} matches found`;
}

