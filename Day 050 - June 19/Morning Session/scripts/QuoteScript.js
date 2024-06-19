const quotesPerPage = 5;
let currentPage = 1;
let totalQuotes = 0;
var currentQuotes = [];

async function fetchQuotes(skip = 0, limit = quotesPerPage) {
    const response = await fetch(`https://dummyjson.com/quotes?limit=${limit}&skip=${skip}`);
    const data = await response.json();
    totalQuotes = data.total;
    return data.quotes;
}

function renderQuotes(quotes) {
    const quoteContainer = document.getElementById('quote-container');
    quoteContainer.innerHTML = '';

    quotes.forEach(quote => {
        const quoteElement = document.createElement('div');
        quoteElement.classList.add('col-md-4','card','shadow-lg','h-200','my-3');
        quoteElement.innerHTML = `
                <div class="card-body">
                    <blockquote class="blockquote mb-0">
                        <p><em>"${quote.quote}"</em></p>
                        <footer class="blockquote-footer"><strong>${quote.author}</strong></footer>
                    </blockquote>
                </div>
        `;
        quoteContainer.appendChild(quoteElement);
    });
}



function renderPagination() {
    const totalPages = Math.ceil(totalQuotes / quotesPerPage);
    const pagination = document.getElementById('pagination');
    pagination.innerHTML = '';

    const prevItem = document.createElement('li');
    prevItem.classList.add('page-item');
    if (currentPage === 1) {
        prevItem.classList.add('disabled');
    }
    prevItem.innerHTML = `
        <a class="page-link text-decoration-none text-dark" href="#">Previous</a>
    `;
    prevItem.addEventListener('click', (e) => {
        e.preventDefault();
        if (currentPage > 1) {
            currentPage--;
            updateQuotes();
        }
    });
    pagination.appendChild(prevItem);

    const currentPageItem = document.createElement('li');
    currentPageItem.classList.add('page-item');
    currentPageItem.innerHTML = `
        <a class="page-link text-decoration-none text-dark" href="#">${currentPage}</a>
    `;
    pagination.appendChild(currentPageItem);

    const nextItem = document.createElement('li');
    nextItem.classList.add('page-item');
    if (currentPage === totalPages) {
        nextItem.classList.add('disabled');
    }
    nextItem.innerHTML = `
        <a class="page-link text-decoration-none text-dark" href="#">Next</a>
    `;
    nextItem.addEventListener('click', (e) => {
        e.preventDefault();
        if (currentPage < totalPages) {
            currentPage++;
            updateQuotes();
        }
    });
    pagination.appendChild(nextItem);
}

async function updateQuotes() {
    const skip = (currentPage - 1) * quotesPerPage;
    const quotes = await fetchQuotes(skip, quotesPerPage);
    renderQuotes(quotes);
    renderPagination();
}

async function findQuote(authorName) {
    try {
        const response = await fetch(`https://dummyjson.com/quotes?limit=1454`);
        const data = await response.json();
        
        const quotes = data.quotes;
        const filteredQuotes = quotes.filter(quote => quote.author.toLowerCase().includes(authorName.toLowerCase()));
        currentQuotes = filteredQuotes;
        displayQuotes(filteredQuotes);
    } catch (error) {
        console.error('Error fetching quotes:', error);
    }
}

function displayQuotes(quotes) {
    const quoteContainer = document.getElementById('quote-container');
    quoteContainer.innerHTML = '';
    const pagination = document.getElementById('pagination');
    pagination.innerHTML = '';

    if (quotes.length == 0) {
        quoteContainer.innerHTML = '<p>No quotes found for this author.</p>';
        return;
    }
    console.log(quotes);

    quotes.forEach(quote => {
        const quoteElement = document.createElement('div');
        quoteElement.classList.add('col-md-4','card','shadow-lg','h-200','my-3');
        quoteElement.innerHTML = `
                <div class="card-body">
                    <blockquote class="blockquote mb-0">
                        <p>${quote.quote}</p>
                        <footer class="blockquote-footer">${quote.author}</footer>
                    </blockquote>
                </div>
        `;
        quoteContainer.appendChild(quoteElement);
    });
}

updateQuotes();

const authorInput = document.getElementById('search-input');
authorInput.addEventListener('input', async function() {
    const authorName = this.value.trim();
    if (authorName.length === 0) {
        displayQuotes([]);
        return;
    }
    const quotesByAuthor = await findQuote(authorName);
});

// Function to sort quotes by author's name in ascending order
function sortQuotesAscending() {
    currentQuotes.sort((a, b) => a.author.toLowerCase().localeCompare(b.author.toLowerCase()));
    displayQuotes(currentQuotes);
}

// Function to sort quotes by author's name in descending order
function sortQuotesDescending() {
    currentQuotes.sort((a, b) => b.author.toLowerCase().localeCompare(a.author.toLowerCase()));
    displayQuotes(currentQuotes);
}

document.getElementById('sort-asc-btn').addEventListener('click', sortQuotesAscending);
document.getElementById('sort-desc-btn').addEventListener('click', sortQuotesDescending);