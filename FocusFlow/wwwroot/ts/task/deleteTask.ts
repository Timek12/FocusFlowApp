﻿declare var Swal: any;

$(document).ready(function () {
    $('.delete-task').click(function () {
        const taskId: string = $(this).data('id');
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then((result: any) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Task/Delete',
                    type: 'POST',
                    data: { id: taskId },
                    success: () => {
                        Swal.fire({
                            title: "Deleted!",
                            text: "Your file has been deleted.",
                            icon: "success"
                        }).then(() => {
                            location.reload();
                        });
                    },
                    error: () => {
                        Swal.fire({
                            title: "Error!",
                            text: "Something went wrong.",
                            icon: "error"
                        });
                    }
                })
            }
        });
    })
});