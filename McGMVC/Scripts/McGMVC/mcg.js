﻿
$(document).ready(function() {
    $('.navbar li').removeClass('active');
    $('ul.nav > li > a[href="' + document.location.pathname + '"]').parent().addClass('active');
    
    //Add Book Mongo
    $(document).on('click','#saveBtnAddBookMongo', function() {
        var myBookTitle = $('#bookTitleInput').val();
        var myBookAuthor = $('#bookAuthorInput').val();
        $.get("/mongo/add", { title: myBookTitle, author: myBookAuthor }).done(function() {
            $('#addBookModal').modal("hide");
            window.location.href = "/mongo";
        });
    });

    $(document).on('click','#delBookMongoBtn', function () {
        var bookID = $(this).parent().parent().attr('id');
        //var bTitle = $(this).parent().parent().children("#bTitleRow").val();
        //var bAuthor = $(this).parent().parent().children("#bAuthorRow").val();
        //alert(bookID + bTitle + bAuthor);
        $.get("/mongo/delete", { id: bookID }).done(function () {
            window.location.href = "/mongo";
        });
    });
});
