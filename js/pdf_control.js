var currentPage = 1;
        var pdf = document.getElementById('pdf');

        function nextPage() {
            if (currentPage < pdf.contentDocument.numPages) {
                currentPage++;
                showPage(currentPage);
            }
        }

        function prevPage() {
            if (currentPage > 1) {
                currentPage--;
                showPage(currentPage);
            }
        }

        function showPage(pageNumber) {
            pdf.contentDocument.getElementById('page' + pageNumber).scrollIntoView();
        }