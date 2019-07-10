
// List & Add & Edit Dashboard
function deleteUserDash(id) {
    $.get("/Admin/User/DeleteUser/" + id,
        function () {
            $("#div-list-user").load("/Admin/Dashboard/ListUser");
        });
}

function lockUserDash(id) {
    $.get("/Admin/User/LockUser/" + id,
        function () {
            $("#div-list-user").load("/Admin/Dashboard/ListUser");
        });
}

function deleteProductDash(id) {
    $.get("/Admin/Product/DeleteProduct/" + id,
        function () {
            $("#div-list-product").load("/Admin/Dashboard/ListProduct");
        });
}

// List & Add & Edit Product
function showAddProduct() {
    $("#div-product-container").load("/Admin/Product/AddProduct");
}

function showEditProduct(id) {
    $("#div-product-container").load("/Admin/Product/EditProduct/" + id);
}

function showEditCategory(id) {
    $("#div-action-category").load("/Admin/Product/EditCategory/" + id);
}

function showEditGallery(id) {
    $("#div-action-gallery").load("/Admin/Product/EditGallery/" + id);
}

function showAddCategory() {
    $("#div-action-category").load("/Admin/Product/AddCategory");
}

function showAddGallery() {
    $("#div-action-gallery").load("/Admin/Product/AddGallery");
}

function DeleteCategory(id) {
    $.get("/Admin/Product/DeleteCategory/" + id,
        function () {
            $("#div-list-category").load("/Admin/Product/ListCategory");
        });
}

function DeleteGallery(id) {
    $.get("/Admin/Product/DeleteGallery/" + id,
        function () {
            //$("#div-list-gallery").load("/Admin/Product/ListGallery");
        });
}

function showListProduct() {
    $("#div-product-container").load("/Admin/Product/ListProduct");
}

function loadListCategory() {
    $("#div-list-category").load("/Admin/Product/ListCategory");
    $("#div-action-category").load("/Admin/Product/AddCategory");
}

function loadListGallery(id) {
    $("#div-list-gallery").load("/Admin/Product/ListGallery/" + id);
    $("#div-action-gallery").load("/Admin/Product/AddGallery/" + id);
}

function readURLProduct(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img-preview-product').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$("#input-img-product").change(function () {
    readURLProduct(this);
});

function readURLGallery(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img-preview-gallery').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$("#input-img-gallery").change(function () {
    readURLGallery(this);
});

function readURLSlider(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img-preview-slider').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$("#input-img-slider").change(function () {
    readURLSlider(this);
});

function deleteProduct(id) {
    $.get("/Admin/Product/DeleteProduct/" + id,
        function () {
            $("#div-product-container").load("/Admin/Product/ListProduct");
        });
}

// List & Add & Edit Trakt
function showAddTrakt() {
    $("#div-trakt-container").load("/Admin/Trakt/AddTrakt");
}

function showEditTrakt(id) {
    $("#div-trakt-container").load("/Admin/Trakt/EditTrakt/" + id);
}

function showEditTCategory(id) {
    $("#div-action-tcategory").load("/Admin/Trakt/EditCategory/" + id);
}

function showAddTCategory() {
    $("#div-action-tcategory").load("/Admin/Trakt/AddCategory");
}

function DeleteTCategory(id) {
    $.get("/Admin/Trakt/DeleteCategory/" + id,
        function () {
            $("#div-list-tcategory").load("/Admin/Trakt/ListCategory");
        });
}

function showListTrakt() {
    $("#div-trakt-container").load("/Admin/Trakt/ListTrakt");
}

function loadListTCategory() {
    $("#div-list-tcategory").load("/Admin/Trakt/ListCategory");
    $("#div-action-tcategory").load("/Admin/Trakt/AddCategory");
}

function readURLTrakt(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img-preview-trakt').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$("#input-img-trakt").change(function () {
    readURLTrakt(this);
});

function readURLTSlider(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img-preview-tslider').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$("#input-img-tslider").change(function () {
    readURLTSlider(this);
});

function lockTrakt(id) {
    $.get("/Admin/Trakt/LockTrakt/" + id,
        function () {
            $("#div-trakt-container").load("/Admin/Trakt/ListTrakt");
        });
}

function deleteTrakt(id) {
    $.get("/Admin/Trakt/DeleteTrakt/" + id,
        function () {
            $("#div-trakt-container").load("/Admin/Trakt/ListTrakt");
        });
}

$('#chk-show-tslider').click(function () {
    if ($(this).is(':checked')) {
        $("#div-image-tslider").show();
    } else {
        $("#div-image-tslider").hide();
    }
});

function changePageTrakt(id) {
    $("#div-trakt-container").load("/Admin/Trakt/ListTrakt?page=" + id + "");
}

// List & Add & Edit User
function showAddUser() {
    $("#div-user-container").load("/Admin/User/AddUser");
}

function showEditUser(id) {
    $("#div-user-container").load("/Admin/User/EditUser/" + id);
}

function showListUser() {
    $("#div-user-container").load("/Admin/User/ListUser");
}

function deleteUser(id) {
    $.get("/Admin/User/DeleteUser/" + id,
        function () {
            $("#div-user-container").load("/Admin/User/ListUser");
        });
}

function lockUser(id) {
    $.get("/Admin/User/LockUser/" + id,
        function () {
            $("#div-user-container").load("/Admin/User/ListUser");
        });
}

function readURLUser(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img-preview-user').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$("#input-img-user").change(function () {
    readURLUser(this);
});

