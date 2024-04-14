function loadHotels(hotelArray, departureDate, returnDate ) {
    var hotelHTML = '';
    for (var i = 0; i < hotelArray.length; i++) {
        hotelHTML += '<tr>';
        hotelHTML += '<td><img src="/img/hotel-' + hotelArray[i].hotelId + '.jpg" width="160" class="img-fluid" alt="Hotel Image" /></td>';
        hotelHTML += '<td><a href="/Hotels/Details/' + hotelArray[i].hotelId + '">' + hotelArray[i].name + '</a></td>';
        hotelHTML += '<td>' + hotelArray[i].reviews + '</td>';
        hotelHTML += '<td>$' + hotelArray[i].price + '</td>';
        hotelHTML += '<td><a class="btn btn-success btn-sm" href="/Flights/Search?hotelId=' + hotelArray[i].hotelId + '&destination=' + hotelArray[i].location;
        if (departureDate) {
            hotelHTML += '&departureDate=' + departureDate;
        }
        if (returnDate) {
            hotelHTML += '&returnDate=' + returnDate;
        }
        hotelHTML += '">Book</a></td></tr>';
    }
    $('#hotelTable tbody').html(hotelHTML);
}

$(document).ready(function () {
    $('#hotelSearch').submit(function (e) {
        e.preventDefault();

        const departureDate = $('#departureDate').val();
        const returnDate = $('#returnDate').val();
        var formData = {
            departureDate: departureDate,
            returnDate: returnDate,
            maxPrice: $('#maxPrice').val(),
            reviews: $('#reviews').val(),
            location: $('#location').val(),
        };


        $.ajax({
            url: '/Hotels/GetHotels',
            method: 'POST',
            contentType: 'application/x-www-form-urlencoded',
            data: formData,
            success: function (response) {
                if (response) {
                    loadHotels(response, departureDate, returnDate);
                }
            },
            error: function (xhr, status, error) {
                alert("Error: " + error);
            }
        });

    });

});
