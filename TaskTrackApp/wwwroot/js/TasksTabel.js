var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Todoes/GetAll' },
        "columns": [
            { data: 'taskTodoName', "width": "15%" },
            { data: 'taskTodoDescription', "width": "25%" },
            {
                data: 'taskTodoDate',
                "width": "10%",
                "render": function (data) {
                    return moment(data).format('YYYY-MM-DD');
                }
            },
            {
                data: 'taskTodoId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/Todoes/Edit?id=${data}" class="btn btn-warning mx-1"> <i class="bi bi-pencil-square"></i> Edit</a>               
                     <a href="/Todoes/Details?id=${data}" class="btn btn-primary mx-1"> <i class="bi bi-card-text"></i> Details</a>
                     <a onClick=Delete('/Todoes/Delete/${data}') class="btn btn-danger mx-1"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}
