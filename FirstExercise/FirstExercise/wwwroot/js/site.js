// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// localStorage.clear();
let allCards = document.getElementsByClassName('card');
console.log(allCards);
let likedCards = [];
likedCards = JSON.parse(localStorage.getItem('likedCards'));
if (likedCards == null) {
    likedCards = [];
}
console.log(likedCards);

for (let i = 0; i < allCards.length; i++) {
    let likeBtn = allCards[i].lastElementChild.childNodes[11];
    let productName = allCards[i].lastElementChild.childNodes[1].innerHTML;

    if (likedCards.includes(productName)) {
        likeBtn.classList.remove('heartIco');
        likeBtn.classList.add('heartIcoMarked');
    } else {
        likeBtn.classList.remove('heartIcoMarked');
        likeBtn.classList.add('heartIco');
    }
    likeBtn.addEventListener('click', function () {
        if (likeBtn.classList.contains('heartIco')) {
            likeBtn.classList.remove('heartIco');
            likeBtn.classList.add('heartIcoMarked');
            likedCards.push(productName);
            localStorage.setItem('likedCards', JSON.stringify(likedCards));
            console.log(likedCards);
        }
        else {
            likeBtn.classList.remove('heartIcoMarked');
            likeBtn.classList.add('heartIco');
            let index = likedCards.indexOf(productName);
            if (index > -1) {
                likedCards.splice(index, 1);
            }
            localStorage.setItem('likedCards', JSON.stringify(likedCards));
            console.log(likedCards);
        }
    })
}
let whatPage = document.getElementById("Favoritos");
if (whatPage != null) {
    for (let i = 0; i < allCards.length; i++) {
        let productName = allCards[i].lastElementChild.childNodes[1].innerHTML;
        if (!likedCards.includes(productName)) {
            allCards[i].remove();
            i--;
        }
    }
}
