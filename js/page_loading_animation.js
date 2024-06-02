
    // Initialize Lottie animation
    var animation = lottie.loadAnimation({
      container: document.getElementById('lottie'), // the DOM element to render the animation
      renderer: 'svg',
      loop: true,
      autoplay: true,
      path: 'loading_anim.json' // the path to the animation json
    });

    // Hide the loader and show the content once the page is fully loaded
    window.addEventListener('load', function() {
      document.getElementById('loading').style.display = 'none';
      document.getElementById('content').style.display = 'block';
    });
  