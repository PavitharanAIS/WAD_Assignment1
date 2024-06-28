for (i = 1; i <= 10; i++)
{
    var swiper1 = new Swiper("#mySwiper_" + i, {
        slidesPerView: 3,
        spaceBetween: 30,
        loop: true,
        slidesPerGroup: 1,
        grabCursor: true,
        keyboard: {
            enabled: true,
        },
        breakpoints: {
            0: {
                slidesPerView: 3,
                slidesPerGroup: 1,
            },
            769: {
                slidesPerView: 3,
                slidesPerGroup: 3,
            },

        },
        navigation: {
            nextEl: "#swiper-button-next_" + i,
            prevEl: "#swiper-button-prev_" + i,
        },
        pagination: {
            el: "#swiper-pagination_" + i,
            clickable: true,
        },
    });
}

