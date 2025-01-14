window.addEventListener("load", solve);

function solve() {
    const nameInput = document.getElementById("name");
    const timeInput = document.getElementById("time");
    const descriptionInput = document.getElementById("description");
    const addButton = document.getElementById("add-btn");
    const previewList = document.getElementById("preview-list");
    const archiveList = document.getElementById("archive-list");

    // Disable form submission (default behavior of button inside form)
    addButton.type = "button";

    // Add event listener for Add button
    addButton.addEventListener("click", () => {
        const eventName = nameInput.value.trim();
        const timePeriod = timeInput.value.trim();
        const description = descriptionInput.value.trim();

        // Validate inputs
        if (!eventName || !timePeriod || !description) {
            return;
        }

        // Create list item for the preview list
        const li = document.createElement("li");

        const article = document.createElement("article");
        const h3 = document.createElement("h3");
        h3.textContent = eventName;

        const pTime = document.createElement("p");
        pTime.textContent = `Time: ${timePeriod}`;

        const pDescription = document.createElement("p");
        pDescription.textContent = `Description: ${description}`;

        article.appendChild(h3);
        article.appendChild(pTime);
        article.appendChild(pDescription);

        // Create buttons
        const editButton = document.createElement("button");
        editButton.textContent = "Edit";
        editButton.classList.add("edit-btn");

        const nextButton = document.createElement("button");
        nextButton.textContent = "Next";
        nextButton.classList.add("next-btn");

        li.appendChild(article);
        li.appendChild(editButton);
        li.appendChild(nextButton);
        previewList.appendChild(li);

        // Clear inputs and disable Add button
        nameInput.value = "";
        timeInput.value = "";
        descriptionInput.value = "";
        addButton.disabled = true;

        // Add functionality for Edit button
        editButton.addEventListener("click", () => {
            nameInput.value = eventName;
            timeInput.value = timePeriod;
            descriptionInput.value = description;
            li.remove();
            addButton.disabled = false;
        });

        // Add functionality for Next button
        nextButton.addEventListener("click", () => {
            li.removeChild(editButton);
            li.removeChild(nextButton);

            const archiveButton = document.createElement("button");
            archiveButton.textContent = "Archive";
            archiveButton.classList.add("archive-btn");
            li.appendChild(archiveButton);
            archiveList.appendChild(li);

            // Add functionality for Archive button
            archiveButton.addEventListener("click", () => {
                li.remove();
                addButton.disabled = false;
            });
        });
    });

    // Enable Add button only when all fields are filled
    [nameInput, timeInput, descriptionInput].forEach(input =>
        input.addEventListener("input", () => {
            addButton.disabled = !(
                nameInput.value.trim() &&
                timeInput.value.trim() &&
                descriptionInput.value.trim()
            );
        })
    );
}