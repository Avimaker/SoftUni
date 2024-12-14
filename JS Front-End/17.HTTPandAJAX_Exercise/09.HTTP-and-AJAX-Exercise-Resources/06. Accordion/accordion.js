document.addEventListener('DOMContentLoaded', solution);

function solution() {
    const main = document.getElementById('main');
    const listUrl = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const detailsUrl = 'http://localhost:3030/jsonstore/advanced/articles/details/';

    // Проверка дали основният контейнер съществува
    if (!main) {
        console.error('Main container not found!');
        return;
    }


    // Заявка за заглавията
    fetch(listUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error(`Failed to fetch article list. Status: ${response.status}`);
            }
            return response.json();
        })
        .then(articles => {
            if (!articles || articles.length === 0) {
                console.error('No articles found!');
                return;
            }

            // Създаване на статии
            articles.forEach(article => {
                const accordion = document.createElement('div');
                accordion.className = 'accordion';

                accordion.innerHTML = `
                    <div class="head">
                        <span>${article.title}</span>
                        <button class="button" id="${article._id}">More</button>
                    </div>
                    <div class="extra" style="display: none;">
                        <p></p>
                    </div>
                `;

                const button = accordion.querySelector('.button');
                button.addEventListener('click', () => {
                    const extraDiv = accordion.querySelector('.extra');
                    const contentParagraph = extraDiv.querySelector('p');

                    if (button.textContent === 'More') {
                        fetch(detailsUrl + article._id)
                            .then(response => {
                                if (!response.ok) {
                                    throw new Error(`Failed to fetch article details. Status: ${response.status}`);
                                }
                                return response.json();
                            })
                            .then(details => {
                                contentParagraph.textContent = details.content;
                                extraDiv.style.display = 'block';
                                button.textContent = 'Less';
                            })
                            .catch(error => console.error('Error fetching details:', error.message));
                    } else {
                        extraDiv.style.display = 'none';
                        button.textContent = 'More';
                    }
                });

                main.appendChild(accordion);
            });
        })
        .catch(error => console.error('Error fetching articles:', error.message));

}