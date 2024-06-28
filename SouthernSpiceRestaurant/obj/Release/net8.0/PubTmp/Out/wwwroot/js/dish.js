//loading table on document ready.

// defining the function loadDataTable. Refer datatables.net for code below.
var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $("#tableData").DataTable({
        "ajax": {
            "url": "/admin/dish/getall",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "description", "width": "35%" },
            { "data": "price", "width": "10%" },
            { "data": "menuItems.name", "width": "10%" },

            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-100 btn-group btn-group-radius" role="group">
                                <a href="/Admin/Dish/CreateOrEditDish?id=${data}" class="btn custom-btn-black mx-2 rounded-2">
                                    <i class="bi bi-pencil-square">Edit</i>
                                </a>

                                <a onClick=Delete("/Admin/Dish/Delete/${data}") class="btn btn-danger mx-2 rounded-2">
                                    <i class="bi bi-trash">Delete</i>
                                </a>
                    </div>`
                       
                }
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    dataTable.ajax.reload();
                    TempData["success"] = "Dish deleted successfully." //TempData["KeyName"] is used to display a notification to user on successful creation, updation or deletion of menu.

                    ////Swal.fire({
                    ////    title: "Deleted!",
                    ////    text: "Your file has been deleted.",
                    ////    icon: "success"
                    //});
                }
            })

        }
    });
}


   