async function lockedProfile() {
    const main = document.getElementById('main');
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    try {
        // Изтегляне на данни от сървъра
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error('Failed to fetch profiles');
        }
        const data = await response.json();

        // Изчистване на основния контейнер
        main.innerHTML = '';

        // Създаване на профили
        Object.values(data).forEach((user, index) => {
            const profile = document.createElement('div');
            profile.className = 'profile';

            profile.innerHTML = `
                <img src="./iconProfile2.png" class="userIcon" />
                <label>Lock</label>
                <input type="radio" name="user${index + 1}Locked" value="lock" checked>
                <label>Unlock</label>
                <input type="radio" name="user${index + 1}Locked" value="unlock"><br>
                <hr>
                <label>Username</label>
                <input type="text" name="user${index + 1}Username" value="${user.username}" disabled readonly />
                <div class="user${index + 1}Details" style="display: none;">
                    <hr>
                    <label>Email:</label>
                    <input type="email" name="user${index + 1}Email" value="${user.email}" disabled readonly />
                    <label>Age:</label>
                    <input type="number" name="user${index + 1}Age" value="${user.age}" disabled readonly />
                </div>
                <button>Show more</button>
            `;

            const button = profile.querySelector('button');
            const detailsDiv = profile.querySelector(`.user${index + 1}Details`);
            const lockRadio = profile.querySelector(`input[value="lock"]`);
            const unlockRadio = profile.querySelector(`input[value="unlock"]`);

            // Слушател за бутона
            button.addEventListener('click', () => {
                if (unlockRadio.checked) {
                    if (detailsDiv.style.display === 'none') {
                        detailsDiv.style.display = 'block';
                        button.textContent = 'Hide it';
                    } else {
                        detailsDiv.style.display = 'none';
                        button.textContent = 'Show more';
                    }
                }
            });

            main.appendChild(profile);
        });
    } catch (error) {
        console.error('Error:', error.message);
    }
}