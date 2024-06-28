$('.modalBtn').on('click', function () {
    var dishId = $(this).data('id');
    $('#idHolder').html(dishId);
    var dishName = $('#dishName').val();
    $('#modal-body').html(dishName);


    
    $('#exampleModalCenter').appendTo("body").modal('show');
});

$('#closeBtn').on('click', function () {
    $('#exampleModalCenter').modal('hide');
});

$('#mainCloseBtn').on('click', function () {
    $('#exampleModalCenter').modal('hide');
});



