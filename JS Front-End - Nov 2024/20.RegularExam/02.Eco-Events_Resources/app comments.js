window.addEventListener("load", solve);

function solve() {
  // DOM Елементи
  const emailInput = document.getElementById("email");
  const eventInput = document.getElementById("event");
  const locationInput = document.getElementById("location");
  const nextBtn = document.getElementById("next-btn");

  const previewList = document.getElementById("preview-list");
  const eventList = document.getElementById("event-list");

  nextBtn.addEventListener("click", handleNext);

  function handleNext() {
      const email = emailInput.value.trim();
      const eventName = eventInput.value.trim();
      const location = locationInput.value.trim();

      // Validate inputs
      if (!email || !eventName || !location) {
          return; // Do nothing if any input is empty
      }

      // Create new list item
      const listItem = document.createElement("li");
      listItem.classList.add("application");

      const article = document.createElement("article");
      const emailElement = document.createElement("h4");
      emailElement.textContent = email;

      const eventElement = document.createElement("p");
      eventElement.innerHTML = `<strong>Event:</strong><br>"${eventName}"`;

      const locationElement = document.createElement("p");
      locationElement.innerHTML = `<strong>Location:</strong><br>"${location}"`;

      article.appendChild(emailElement);
      article.appendChild(eventElement);
      article.appendChild(locationElement);

      const editBtn = document.createElement("button");
      editBtn.textContent = "edit";
      editBtn.classList.add("action-btn", "edit");
      editBtn.addEventListener("click", () => handleEdit(listItem, email, eventName, location));

      const applyBtn = document.createElement("button");
      applyBtn.textContent = "apply";
      applyBtn.classList.add("action-btn", "apply");
      applyBtn.addEventListener("click", () => handleApply(listItem));

      listItem.appendChild(article);
      listItem.appendChild(editBtn);
      listItem.appendChild(applyBtn);

      previewList.appendChild(listItem);

      // Clear inputs and disable the Next button
      emailInput.value = "";
      eventInput.value = "";
      locationInput.value = "";
      nextBtn.disabled = true;
  }

  function handleEdit(listItem, email, eventName, location) {
      // Populate the input fields with the current data
      emailInput.value = email;
      eventInput.value = eventName;
      locationInput.value = location;

      // Remove the list item
      previewList.removeChild(listItem);

      // Enable the Next button
      nextBtn.disabled = false;
  }

  function handleApply(listItem) {
      // Remove the Edit and Apply buttons
      const buttons = listItem.querySelectorAll("button");
      buttons.forEach(button => button.remove());

      // Move the list item to the approved events list
      eventList.appendChild(listItem);

      // Enable the Next button
      nextBtn.disabled = false;
  }
}
