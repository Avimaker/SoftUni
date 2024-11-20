function solve() {
   const searchField = document.querySelector('#searchField').value.toLowerCase().trim();
   const students = document.querySelectorAll('table tbody tr');

   if (searchField == '') return;

   students.forEach(student => {
      console.log(student.textContent);
      student.classList.remove('select');

      if (student.textContent.toLowerCase().includes(searchField)) {
         student.classList.add('select');
      }
      
   });


}