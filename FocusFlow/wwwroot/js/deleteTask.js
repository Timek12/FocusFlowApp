"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var sweetalert2_1 = require("sweetalert2");
$(document).ready(function () {
    $('.delete-task').click(function () {
        var taskId = $(this).data('id');
        console.log(taskId);
        sweetalert2_1.default.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then(function (result) {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Task/Delete',
                    type: 'POST',
                    data: { id: taskId },
                    success: function () {
                        sweetalert2_1.default.fire({
                            title: "Deleted!",
                            text: "Your file has been deleted.",
                            icon: "success"
                        }).then(function () {
                            location.reload();
                        });
                    },
                    error: function () {
                        sweetalert2_1.default.fire({
                            title: "Error!",
                            text: "Something went wrong.",
                            icon: "error"
                        });
                    }
                });
            }
        });
    });
});
//# sourceMappingURL=deleteTask.js.map