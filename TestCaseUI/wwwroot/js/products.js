// products.js
var BASEURL = "https://localhost:7013/api/"
function ProductCall(query) {
    $.ajax({

        url:
            BASEURL + "Product" + (query||""),
        type: "GET",
        success: function (data) {
            let x = JSON.stringify(data);
            let tablo = $('#veriTablosu tbody');
            tablo.empty(); // Mevcut tabloyu temizle

            data.forEach(function (product) {
                let satir = $('<tr>');
                satir.append('<td>' + product.id + '</td>');
                satir.append('<td>' + product.title + '</td>');
                satir.append('<td>' + product.description + '</td>');
                satir.append('<td>' + product.stockQuantity + '</td>');
                satir.append('<td>' + product.categoryId + '</td>');
                satir.append('<td>' + product.category?.name + '</td>');
                satir.append('<td>' + (product.isPublished ? 'Evet' : 'Hayır') + '</td>');
                satir.append('<td> <a href="/Products/ProductUpdate/' + product.id + '" class="btn btn-info btn-icon-split"><span class="text">Güncelle</span></a></td>');
                satir.append('<td> <button data-id="' + product.id +'" class="deletebtn btn btn-danger btn-icon-split "><span class="text">Sil</span></button></td>');
                tablo.append(satir);
            });
            console.log(x);
            $(".deletebtn").click(function () {
                var id = $(this).data("id")
                DeleteProduct(id)
            })
        },
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });
}
function ProductId(id) {
    var product = {

    };
    $.ajax({

        url:
            BASEURL + "Product/" + id,
        type: "GET",
        success: function (data) {
            let x = JSON.stringify(data);
            $('#title').val(data.title),
                $('#description').val(data.description),
                $('#stockQuantity').val(data.stockQuantity),
                $('#categorySelect').val(data.categoryId),

                console.log(x);
        },
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });
}
function addProduct() {
    var product = {
        title: $('#title').val(),
        description: $('#description').val(),
        stockQuantity: $('#stockQuantity').val(),
        categoryId: $('#categorySelect').val(),
    };
    console.log(JSON.stringify(product))
    $.ajax({
        url: BASEURL + "Product",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(product),
        success: function (response) {
            console.log("Ürün başarıyla eklendi:", response);
            alert("ürün eklendi")
        },
        error: function (error) {
            console.log("Ürün eklenirken hata oluştu:", error);
            alert("başarısız")
        }
    });
}
function UpdateProduct(id) {
    // Formdan veri al
    var product = {

        title: $('#title').val(),
        description: $('#description').val(),
        stockQuantity: $('#stockQuantity').val(),
        categoryId: $('#categorySelect').val(),
        id: id
        //isPublished: $('#isPublished').is(':checked')
    };
    console.log(JSON.stringify(product))
    // AJAX POST isteği
    $.ajax({
        url: BASEURL + "Product/" + id,
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(product),
        success: function (response) {
        },
        error: function (error) {
        }
    });
}


function DeleteProduct(id) {
    // Formdan veri al
    // AJAX POST isteği
    $.ajax({
        url: BASEURL + "Product/" + id,
        type: "DELETE",
        success: function (response) {
            console.log("silindi");
            window.location.reload();
        },
        error: function (error) {
        }
    });
}

function CategoryCall() {
    $.ajax({

        url:
            BASEURL + "Category",
        type: "GET",
        success: function (data) {
            let x = JSON.stringify(data);
            let tablo = $('#veriTablosu tbody');
            tablo.empty(); // Mevcut tabloyu temizle
            data.forEach(function (category) {
                let satir = $('<tr>');
                satir.append('<td>' + category.id + '</td>');
                satir.append('<td>' + category.name + '</td>');
                satir.append('<td>' + category.minStockQuantity + '</td>');
                satir.append('<td> <a href="/Categories/CategoryUpdate/' + category.id + '" class="btn btn-info btn-icon-split"><span class="text">Güncelle</span></a></td>');
                satir.append('<td> <button data-id="' + category.id + '" class="deletebtn btn btn-danger btn-icon-split "><span class="text">Sil</span></button></td>');
                tablo.append(satir);
            });
            console.log(x);
            $(".deletebtn").click(function () {
                var id = $(this).data("id")
                DeleteCategory(id)
            })
        },
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });
}
function CategoryId(id) {
    $.ajax({

        url:
            BASEURL + "Category/" + id,
        type: "GET",
        success: function (data) {
            let x = JSON.stringify(data);
            $('#name').val(data.name),
                $('#minStok').val(data.minStockQuantity),
                console.log(x);
        },
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });
}

function CategoryAdd() {
    // Formdan veri al
    var category = {
        name: $('#name').val(),
        minStockQuantity: $('#minStok').val(),
    };
    console.log(JSON.stringify(category))
    // AJAX POST isteği
    $.ajax({
        url: BASEURL + "Category",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(category),
        success: function (response) {
            console.log("Ürün başarıyla eklendi:", response);
        },
        error: function (error) {
            console.log("Ürün eklenirken hata oluştu:", error);
        }
    });
}

function CategoryUpdate(id) {
    // Formdan veri al
    var category = {
        id: id,
        name: $('#name').val(),
        minStockQuantity: $('#minStok').val(),
    };
    console.log(JSON.stringify(category))
    // AJAX POST isteği
    $.ajax({
        url: BASEURL + "Category/" + id,
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(category),
        success: function (response) {
            alert("ürün eklendi")
        },
        error: function (error) {
            alert("başarısız")
        }
    });
}

function DeleteCategory(id) {
    $.ajax({
        url: BASEURL + "Category/" + id,
        type: "DELETE",
        success: function (response) {
            console.log("silindi");
            window.location.reload();
        },
        error: function (error) {
            alert("Ürün bulunan kategori silinemez.")
        }
    });
}