// JavaScript
const image = document.getElementById('animatedImage');

function startRollOutAnimation() {
    image.style.animation = 'rollOut 2s forwards';
}

function startRollInAnimation() {
    image.style.animation = 'rollIn 2s forwards';
}

function startAnimationLoop() {
    startRollOutAnimation();
    setTimeout(() => {
        startRollInAnimation();
    }, 2000); // Timing should match the roll out animation duration
}

setInterval(startAnimationLoop, 4000); // Adjust interval timing based on the total duration of roll out and roll in
