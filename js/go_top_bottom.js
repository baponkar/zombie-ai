// Show/hide scroll buttons based on scroll position
window.onscroll = function() {
    scrollFunction();
};

function scrollFunction() {
    var goTopButton = document.getElementById("goTopButton");
    var goBottomButton = document.getElementById("goBottomButton");

    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        goTopButton.style.display = "block";
    } else {
        goTopButton.style.display = "none";
    }

    if ((window.innerHeight + window.pageYOffset) >= document.body.offsetHeight - 20) {
        goBottomButton.style.display = "none";
    } else {
        goBottomButton.style.display = "block";
    }
}

// Smooth scroll to top
function goToTop() {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
}

// Smooth scroll to bottom
function goToBottom() {
    window.scrollTo({
        top: document.body.scrollHeight,
        behavior: 'smooth'
    });
}