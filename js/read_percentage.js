// Function to calculate and update reading progress
function updateReadingProgress() {
    var windowHeight = window.innerHeight;
    var documentHeight = document.body.scrollHeight;
    var scrollPosition = window.scrollY || window.pageYOffset || document.documentElement.scrollTop;
    var scrollPercent = (scrollPosition / (documentHeight - windowHeight)) * 100;

    // Update progress bar
    var progressBar = document.getElementById('readingProgress');
    progressBar.style.width = scrollPercent + '%';
    progressBar.textContent = Math.round(scrollPercent) + '%';
}

// Update reading progress when user scrolls
window.addEventListener('scroll', updateReadingProgress);

// Update reading progress on page load
window.addEventListener('load', updateReadingProgress);