function setColorStar(a, stars) {
    for (let i = 0; i < stars.length; i++) {
        stars[i].classList.remove('fas', 'fa-star-half-alt');
        stars[i].classList.add('far');
    }

    if (a === 0) {
    } else if (a > 0 && a <= 1) {
        stars[0].classList.add('fas', 'fa-star-half-alt');
    } else if (a > 1 && a <= 2) {
        stars[0].classList.add('fas');
    } else if (a > 2 && a <= 3) {
        stars[0].classList.add('fas');
        stars[1].classList.add('fas', 'fa-star-half-alt');
    } else if (a > 3 && a <= 4) {
        stars[0].classList.add('fas');
        stars[1].classList.add('fas');
    } else if (a > 4 && a <= 5) {
        stars[0].classList.add('fas');
        stars[1].classList.add('fas');
        stars[2].classList.add('fas', 'fa-star-half-alt');
    } else if (a > 5 && a <= 6) {
        stars[0].classList.add('fas');
        stars[1].classList.add('fas');
        stars[2].classList.add('fas');
    } else if (a > 6 && a <= 7) {
        stars[0].classList.add('fas');
        stars[1].classList.add('fas');
        stars[2].classList.add('fas');
        stars[3].classList.add('fas', 'fa-star-half-alt');
    } else if (a > 7 && a <= 8) {
        stars[0].classList.add('fas');
        stars[1].classList.add('fas');
        stars[2].classList.add('fas');
        stars[3].classList.add('fas');
    } else if (a > 8 && a <= 9) {
        stars[0].classList.add('fas');
        stars[1].classList.add('fas');
        stars[2].classList.add('fas');
        stars[3].classList.add('fas');
        stars[4].classList.add('fas', 'fa-star-half-alt');
    } else if (a > 9 && a <= 10) {
        stars[0].classList.add('fas');
        stars[1].classList.add('fas');
        stars[2].classList.add('fas');
        stars[3].classList.add('fas');
        stars[4].classList.add('fas');
    }
}

