




anime.timeline({loop: true})
.add({
    //color change
    target: '.dancing',
    backgroundColor: ['#ff0000', '#00ff00'], // Animate background color from red to green
    duration: 1000,   // Duration of the animation (in milliseconds)
    easing: 'linear', // Easing function for the animation
    direction: 'alternate', // Alternate between colors
}).add({
    //brust animation
    targets: '.dancing',
    scale: [1, 1.5], // Animate scale from 1 to 1.5
    duration: 200,   // Duration of the animation (in milliseconds)
    easing: 'easeOutQuad',
    direction: 'alternate', // Alternate between scaling up and scaling down
  }).add({
    //rotate in clockwise
    targets: '.dancing',
    translateX: 2,
    translateY: 2,
    rotate: '1turn',
    duration: 1000,
    easing: 'easeInOutQuad',
  }).add({
    //wait for opposite rotation
    targets: '.dancing',
    duration: 1000,
  }).add({
    targets: '.dancing',
    translateX: 250,
    delay: anime.stagger(100), // Stagger animation by 100ms
    duration: 1000,
    easing: 'easeInOutQuad',
    loop: true
  }).add({
    //blinking animation
    targets: '.dancing',
    opacity: [0, 1], // Animate opacity from 0 to 1
    duration: 500,    // Duration of each half of the animation (in milliseconds)
    easing: 'easeInOutQuad',
    loop: true       // Repeat the animation infinitely
  }).add({
    targets: '.dancing',
    translateX: 2,
    translateY: 2,
    rotate: '-1turn',
    duration: 4000,
    easing: 'easeOutInQuad',
  });
  
  