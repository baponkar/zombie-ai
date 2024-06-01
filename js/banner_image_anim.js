// JavaScript
const image = document.getElementById('animatedImage');

function startVanishAnimation() {
    image.style.animation = 'vanish 2s forwards';
}

function startReloadAnimation() {
    image.style.animation = 'reload 2s forwards';
}

function startAnimationLoop() {
    startVanishAnimation();
    setTimeout(() => {
        startReloadAnimation();
    }, 2000); // Timing should match the vanish animation duration
}

setInterval(startAnimationLoop, 4000); // Adjust interval timing based on the total duration of vanish and reload
