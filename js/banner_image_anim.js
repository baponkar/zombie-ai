// JavaScript
const image = document.getElementById('animatedImage');

function startRollOutAnimation() {
    image.style.animation = 'rollOut 2s forwards';
}

function startRollInAnimation() {
    image.style.animation = 'rollIn 2s forwards';
}

function startAnimationLoop() {
    startVanishAnimation();
    setTimeout(() => {
        startReloadAnimation();
    }, 2000); // Timing should match the roll out animation duration
}

function startVanishAnimation(){
    image.style.animation = "vanish 2s forwards"
}

function startReloadAnimation(){
    image.style.animation = "reload 2s forwards"
}



setInterval(startAnimationLoop, 4000); // Adjust interval timing based on the total duration of roll out and roll in
