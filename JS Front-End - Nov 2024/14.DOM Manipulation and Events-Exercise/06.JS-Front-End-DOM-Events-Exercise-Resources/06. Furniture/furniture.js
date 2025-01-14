document.addEventListener('DOMContentLoaded', solve);

function solve() {
  // Извличане на ключовите елементи от DOM
  const inputArea = document.querySelector('#input textarea');
  const generateButton = document.querySelector('#input input[type="submit"]');
  const tableBody = document.querySelector('table tbody');
  const resultArea = document.querySelector('#shop textarea');
  const buyButton = document.querySelector('#shop input[type="submit"]');

  // Генериране на мебели
  generateButton.addEventListener('click', (event) => {
      event.preventDefault(); // Предотвратяване на презареждане на страницата

      const furnitureData = JSON.parse(inputArea.value);

      furnitureData.forEach(furniture => {
          const row = document.createElement('tr');

          row.innerHTML = `
              <td><img src="${furniture.img}" /></td>
              <td><p>${furniture.name}</p></td>
              <td><p>${furniture.price}</p></td>
              <td><p>${furniture.decFactor}</p></td>
              <td><input type="checkbox" /></td>
          `;

          tableBody.appendChild(row);
      });
  });

  // Обработване на покупката
  buyButton.addEventListener('click', (event) => {
      event.preventDefault(); // Предотвратяване на презареждане на страницата

      const selectedFurniture = Array.from(tableBody.querySelectorAll('tr'))
          .filter(row => row.querySelector('input[type="checkbox"]').checked);

      const boughtFurniture = selectedFurniture.map(row => {
          return row.querySelector('td:nth-child(2) p').textContent;
      });

      const totalPrice = selectedFurniture.reduce((sum, row) => {
          return sum + Number(row.querySelector('td:nth-child(3) p').textContent);
      }, 0);

      const totalDecorationFactor = selectedFurniture.reduce((sum, row) => {
          return sum + Number(row.querySelector('td:nth-child(4) p').textContent);
      }, 0);

      const averageDecorationFactor = selectedFurniture.length > 0
          ? totalDecorationFactor / selectedFurniture.length
          : 0;

      // Показване на резултатите в текстовото поле
      resultArea.value = `Bought furniture: ${boughtFurniture.join(', ')}
Total price: ${totalPrice.toFixed(2)}
Average decoration factor: ${averageDecorationFactor}`;
  });
}