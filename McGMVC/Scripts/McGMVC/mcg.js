
$(document).ready(function() {
    $('.navbar li').removeClass('active');
    $('ul.nav > li > a[href="' + document.location.pathname + '"]').parent().addClass('active');
    
    //Add Book Mongo
    $('#saveBtnAddBookMongo').on('click', function() {
        var myBookTitle = $('#bookTitleInput').val();
        var myBookAuthor = $('#bookAuthorInput').val();
        $.get("/mongo/add", { title: myBookTitle, author: myBookAuthor }).done(function() {
            window.location.reload(true);
        });
    });
});
