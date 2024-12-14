window.addEventListener("load", solve);

function solve() {
  // Елементи
  const addBtn = document.getElementById("add-btn");
  const laptopModelInput = document.getElementById("laptop-model");
  const storageInput = document.getElementById("storage");
  const priceInput = document.getElementById("price");
  const checkList = document.getElementById("check-list");
  const laptopsList = document.getElementById("laptops-list");
  const clearBtn = document.querySelector(".btn.clear");

  // Добавяне на лаптоп в списъка
  addBtn.addEventListener("click", () => {
      const model = laptopModelInput.value.trim();
      const storage = storageInput.value.trim();
      const price = priceInput.value.trim();

      // Проверка за валидност на въведените данни
      if (!model || !storage || !price) return;

      // Преобразуване на съхранението в GB или TB
      let storageText = "";
      const storageValue = parseInt(storage);

      if (storageValue >= 1000) {
          const storageInTB = (storageValue / 1000).toFixed(1); // Преобразуваме в TB
          storageText = `Memory: ${storageInTB} TB`;
      } else {
          storageText = `Memory: ${storageValue} GB`; // Ако е по-малко от 1000 GB
      }

      // Създаване на нов елемент за списъка
      const li = document.createElement("li");
      li.classList.add("laptop-item");
      li.innerHTML = `
          <article>
              <p>${model}</p>
              <p>${storageText}</p>
              <p>Price: ${price}$</p>
          </article>
          <button class="btn edit">edit</button>
          <button class="btn ok">ok</button>
      `;

      // Добавяне на събития за бутоните (edit и ok)
      const editBtn = li.querySelector(".edit");
      const okBtn = li.querySelector(".ok");

      // Редактиране на лаптоп
      editBtn.addEventListener("click", () => {
          laptopModelInput.value = model;
          storageInput.value = storage;
          priceInput.value = price;
          // Премахване на елемента от списъка
          checkList.removeChild(li);
          addBtn.disabled = false;
      });

      // Преместване на лаптопа в списъка с желаните лаптопи
      okBtn.addEventListener("click", () => {
          checkList.removeChild(li);
          li.querySelector(".edit").remove();
          li.querySelector(".ok").remove();
          laptopsList.appendChild(li);
          addBtn.disabled = false;
      });

      // Добавяне на новия лаптоп в списъка
      checkList.appendChild(li);

      // Изчистване на полетата и деактивиране на бутона "Add"
      addBtn.disabled = true;
      laptopModelInput.value = "";
      storageInput.value = "";
      priceInput.value = "";
  });

  // Изчистване на списъка с желаните лаптопи
  clearBtn.addEventListener("click", () => {
      laptopsList.innerHTML = "";
      location.reload();
  });
}