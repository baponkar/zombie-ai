const images = document.querySelectorAll('#imageContainer img');
let currentIndex = 0;

function transitionImages() {
    images[currentIndex].classList.remove('tearoff');

            currentIndex = (currentIndex + 1) % images.length;

            images[currentIndex].classList.add('tearoff');
}

setInterval(transitionImages, 3000); // Change image every 3 seconds