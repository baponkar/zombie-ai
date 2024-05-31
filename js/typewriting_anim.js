/*This is creating typewriting effect animation by javascript*/

var textWrapper = document.querySelector('.typewritter .letters');
			textWrapper.innerHTML = textWrapper.textContent.replace(/\S/g, "<span class='letter'>$&</span>");

			anime.timeline({loop: true})
			.add({
				targets: '.typewritter .line',
				scaleX: [0,1],
				opacity: [0.5,1],
				easing: "easeInOutExpo",
				duration: 900
			}).add({
				targets: '.typewritter .letter',
				opacity: [0,1],
				translateX: [40,0],
				translateZ: 0,
				scaleX: [0.3, 1],
				easing: "easeOutExpo",
				duration: 800,
				offset: '-=600',
				delay: (el, i) => 150 + 25 * i
			}).add({
				targets: '.typewritter',
				opacity: 0,
				duration: 1000,
				easing: "easeOutExpo",
				delay: 4000
			});