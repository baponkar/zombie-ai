let currentIndex = 0;
const images = document.querySelectorAll('#anim-imageContainer img');
const dots = document.querySelectorAll('.dot');
const totalImages = images.length;

function showImage(index) {
    images.forEach((img, i) => {
        img.style.opacity = (i === index) ? '1' : '0';
    });
    updateDots(index);
    setTimeout(() => {
        currentIndex = (index + 1) % totalImages;
        // previousIndex = currentIndex - 1;
        // showImage(previousIndex)
        showImage(currentIndex);
    }, 2000); // Display each image for 2 seconds
}

function slideImages() {
    anime({
        targets: images[currentIndex],
        left: '-100%',
        duration: 1000,
        easing: 'easeInOutQuad',
        complete: function() {
            images[currentIndex].style.left = '100%'; 
            currentIndex = (currentIndex + 1) % totalImages;
            anime({
                targets: images[currentIndex],
                left: '0%',
                duration: 1000,
                easing: 'easeInOutQuad',
                complete: function() {
                    setTimeout(slideImages, 1000);
                }
            });
            updateDots(currentIndex);
        }
    });
}

function updateDots(index) {
    dots.forEach(dot => dot.classList.remove('active'));
    dots[index].classList.add('active');
}

setTimeout(slideImages, 1000);
