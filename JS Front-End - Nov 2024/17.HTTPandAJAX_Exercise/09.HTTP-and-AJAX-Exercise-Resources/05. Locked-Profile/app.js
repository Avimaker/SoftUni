function lockedProfile() {
    const main = document.getElementById('main');
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    // Fetch данни от сървъра
    fetch(url)
        .then((response) => {
            if (!response.ok) {
                throw new Error('Failed to fetch profiles');
            }
            return response.json();
        })
        .then((data) => {
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
                    <div class="hidden-info" style="display: none;">
                        <hr>
                        <label>Email:</label>
                        <input type="email" name="user${index + 1}Email" value="${user.email}" disabled readonly />
                        <label>Age:</label>
                        <input type="number" name="user${index + 1}Age" value="${user.age}" disabled readonly />
                    </div>
                    <button>Show more</button>
                `;

                const button = profile.querySelector('button');
                const hiddenInfo = profile.querySelector('.hidden-info');
                const lockRadio = profile.querySelector(`input[value="lock"]`);
                const unlockRadio = profile.querySelector(`input[value="unlock"]`);

                // Обработка на бутона "Show more"
                button.addEventListener('click', () => {
                    if (unlockRadio.checked) {
                        if (hiddenInfo.style.display === 'none') {
                            hiddenInfo.style.display = 'block';
                            button.textContent = 'Hide it';
                        } else {
                            hiddenInfo.style.display = 'none';
                            button.textContent = 'Show more';
                        }
                    }
                });

                main.appendChild(profile);
            });
        })
        .catch((error) => {
            console.error('Error:', error.message);
        });
}