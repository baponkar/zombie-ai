const bgMusic = document.getElementById('bgMusic');
        const playButton = document.getElementById('playButton');
        const pauseButton = document.getElementById('pauseButton');

        playButton.addEventListener('click', function() {
            bgMusic.play();
        });

        pauseButton.addEventListener('click', function() {
            bgMusic.pause();
        });