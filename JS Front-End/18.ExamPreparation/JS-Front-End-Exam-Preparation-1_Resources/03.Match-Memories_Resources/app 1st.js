document.addEventListener('DOMContentLoaded', () => {
    const addMatchButton = document.getElementById('add-match');
    const editMatchButton = document.getElementById('edit-match');
    const loadMatchesButton = document.getElementById('load-matches');
    const hostInput = document.getElementById('host');
    const scoreInput = document.getElementById('score');
    const guestInput = document.getElementById('guest');
    const matchList = document.getElementById('list');

    let currentMatchId = null;

    // Load all matches from the server
    loadMatchesButton.addEventListener('click', () => {
        fetch('http://localhost:3030/jsonstore/matches/')
            .then(res => res.json())
            .then(matches => {
                matchList.innerHTML = ''; // Clear the list
                Object.values(matches).forEach(match => {
                    const matchElement = createMatchElement(match);
                    matchList.appendChild(matchElement);
                });
            });
    });

    // Add a new match
    addMatchButton.addEventListener('click', () => {
        const host = hostInput.value;
        const score = scoreInput.value;
        const guest = guestInput.value;

        if (!host || !score || !guest) {
            alert('Please fill in all fields');
            return;
        }

        const matchData = {
            host,
            score,
            guest
        };

        fetch('http://localhost:3030/jsonstore/matches/', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(matchData)
        })
        .then(() => {
            clearForm();
            loadMatchesButton.click(); // Reload matches after adding
        });
    });

    // Edit an existing match
    editMatchButton.addEventListener('click', () => {
        const host = hostInput.value;
        const score = scoreInput.value;
        const guest = guestInput.value;

        if (!host || !score || !guest) {
            alert('Please fill in all fields');
            return;
        }

        const matchData = {
            host,
            score,
            guest
        };

        fetch(`http://localhost:3030/jsonstore/matches/${currentMatchId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(matchData)
        })
        .then(() => {
            clearForm();
            loadMatchesButton.click(); 
        });
    });

    // Delete a match
    function deleteMatch(matchId) {
        fetch(`http://localhost:3030/jsonstore/matches/${matchId}`, {
            method: 'DELETE'
        })
        .then(() => {
            loadMatchesButton.click(); 
        });
    }

    // Function to create a match element in the list
    function createMatchElement(match) {
        const li = document.createElement('li');
        li.classList.add('match');

        const divInfo = document.createElement('div');
        divInfo.classList.add('info');
        divInfo.innerHTML = `
            <p>${match.host}</p>
            <p>${match.score}</p>
            <p>${match.guest}</p>
        `;

        const divBtns = document.createElement('div');
        divBtns.classList.add('btn-wrapper');

        const changeBtn = document.createElement('button');
        changeBtn.classList.add('change-btn');
        changeBtn.textContent = 'Change';
        changeBtn.addEventListener('click', () => {
            hostInput.value = match.host;
            scoreInput.value = match.score;
            guestInput.value = match.guest;

            currentMatchId = match._id;
            addMatchButton.disabled = true;
            editMatchButton.disabled = false;
        });

        const deleteBtn = document.createElement('button');
        deleteBtn.classList.add('delete-btn');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', () => {
            deleteMatch(match._id);
        });

        divBtns.appendChild(changeBtn);
        divBtns.appendChild(deleteBtn);

        li.appendChild(divInfo);
        li.appendChild(divBtns);

        return li;
    }

    // Clear the form inputs and reset buttons
    function clearForm() {
        hostInput.value = '';
        scoreInput.value = '';
        guestInput.value = '';
        addMatchButton.disabled = false;
        editMatchButton.disabled = true;
        currentMatchId = null;
    }
});