
console.log(dishes);


//for (var i = 0; i < dishes.length; i++)
//{
//    var dish = dishes[i];
//    var infoBtn = '#infoBtn_' + dish.id;

//    var modalTitleId = '#modal-title_' + dish.id;

//    var dishName = '#dishName_' + dish.id;
//    $(infoBtn).on('click', function () {

//        $(modalTitleId).html($(dishName).val());

//        $(modalToggle).appendTo("body").modal('show');


//    });
//}

//$('#closeBtn').on('click', function () {
//    $('#exampleModalCenter').modal('hide');
//});

//$('#mainCloseBtn').on('click', function () {
//    $('#exampleModalCenter').modal('hide');
//});


//$('#infoBtn_1').on('click', function () {

//    $('.exampleModalCenterTitle').appendTo("body").modal('show');

//});



for (var i = 0; i < dishes.length; i++)
{
    var dish = dishes[i];
    var addToCartBtn = "#addToCartBtn_" + dish.id;
    var quantityBtn = "#quantityBtn_" + dish.id;
    $(addToCartBtn).on('click', function () {
        $(addToCartBtn).hide();
        $(quantityBtn).removeClass('d-none');
    });
}