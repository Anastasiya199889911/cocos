/*
Bootstable
 @description  Javascript library to make HMTL tables editable, using Bootstrap
 @version 1.1
 @autor Tito Hinostroza
*/
//"use strict";
////Global variables
////var params = null;  		//Parameters
//var colsEdi = null;
//var newColHtml = '<div class="btn-group pull-right">' +
//    '<button id="bEdit" type="button" class="btn btn-sm btn-primary" onclick="rowEdit(this);">' +
//    '<i class="fa fa-pencil"> </i>' +
//    '</button>' +
//    '<button id="bElim" type="button" class="btn btn-sm btn-default"  onclick="rowElim(this);">' +
//    '<i class="fa fa-trash"> </i>' +
//    '</button>' +
//    '<button id="bAcep" type="button" class="btn btn-sm btn-primary"  onclick="rowAcep(this); "style="display: none;"">' +
//    '<i class="fa fa-check"> </i>' +
//    '</button>' +
//    '<button id="bCanc" type="button" class="btn btn-sm btn-default"  onclick="rowCancel(this);"style="display: none;"">' +
//    '<i class="fa fa-times"> </i>' +
//    '</button>' +
//    '</div>';
//var colEdicHtml = '<td name="buttons" style="vertical-align:middle">' + newColHtml + '</td>';
//$.fn.SetEditable = function (options) {
//    var defaults = {
//        columnsEd: null,         //Index to editable columns. If null all td editables. Ex.: "1,2,3,4,5"
//        $addButton: null,        //Jquery object of "Add" button
//        onEdit: function () { },   //Called after edition
//        onBeforeDelete: function () { }, //Called before deletion
//        onDelete: function () { }, //Called after deletion
//        onAdd: function () { }     //Called when added a new row
//    };
//    params = $.extend(defaults, options);
//    var $rows = this.find('thead tr');
//    var $row;
//    var rowCount = $rows.length + 0;
//    var newTh = $('<th></th>').text("Действия").attr("name", "buttons");
//    if (rowCount > 1) {
//        $row = $rows.first();
//        newTh.attr("rowspan", rowCount);
//        console.debug(newTh);
//    } else $row = $rows;
//    $row.append(newTh);  //encabezado vacío
//    this.find('tbody tr').append(colEdicHtml);
//    var $tabedi = this;   //Read reference to the current table, to resolve "this" here.
//    //Process "addButton" parameter
//    if (params.$addButton != null) {
//        //Se proporcionó parámetro
//        params.$addButton.click(function () {
//            rowAddNew($tabedi.attr("id"));
//        });
//    }
//    //Process "columnsEd" parameter
//    if (params.columnsEd != null) {
//        //Extract felds
//        colsEdi = params.columnsEd.split(',');
//    }
//};
//function IterarCamposEdit($cols, tarea) {
//    //Itera por los campos editables de una fila
//    var n = 0;
//    $cols.each(function () {
//        n++;
//        if ($(this).attr('name') == 'buttons') return;  //excluye columna de botones
//        if (!EsEditable(n - 1)) return;   //noe s campo editable
//        tarea($(this));
//    });
//    function EsEditable(idx) {
//        //Indica si la columna pasada está configurada para ser editable
//        if (colsEdi == null) {  //no se definió
//            return true;  //todas son editable
//        } else {  //hay filtro de campos
//            //alert('verificando: ' + idx);
//            for (var i = 0; i < colsEdi.length; i++) {
//                if (idx == colsEdi[i]) return true;
//            }
//            return false;  //no se encontró
//        }
//    }
//}
//function FijModoNormal(but) {
//    $(but).parent().find('#bAcep').hide();
//    $(but).parent().find('#bCanc').hide();
//    $(but).parent().find('#bEdit').show();
//    $(but).parent().find('#bElim').show();
//    var $row = $(but).parents('tr');  //accede a la fila
//    $row.attr('id', '');  //quita marca
//}
//function FijModoEdit(but) {
//    $(but).parent().find('#bAcep').show();
//    $(but).parent().find('#bCanc').show();
//    $(but).parent().find('#bEdit').hide();
//    $(but).parent().find('#bElim').hide();
//    var $row = $(but).parents('tr');  //accede a la fila
//    $row.attr('id', 'editing');  //indica que está en edición
//}
//function ModoEdicion($row) {
//    if ($row.attr('id') == 'editing') {
//        return true;
//    } else {
//        return false;
//    }
//}
//function rowAcep(but) {
//    //Acepta los cambios de la edición
//    var $row = $(but).parents('tr');  //accede a la fila
//    var $cols = $row.find('td');  //lee campos
//    if (!ModoEdicion($row)) return;  //Ya está en edición
//    //Está en edición. Hay que finalizar la edición
//    IterarCamposEdit($cols, function ($td) {  //itera por la columnas
//        var cont = $td.find('input').val(); //lee contenido del input
//        $td.html(cont);  //fija contenido y elimina controles
//    });
//    FijModoNormal(but);
//    params.onEdit($row);
//}
//function rowCancel(but) {
//    //Rechaza los cambios de la edición
//    var $row = $(but).parents('tr');  //accede a la fila
//    var $cols = $row.find('td');  //lee campos
//    if (!ModoEdicion($row)) return;  //Ya está en edición
//    //Está en edición. Hay que finalizar la edición
//    IterarCamposEdit($cols, function ($td) {  //itera por la columnas
//        var cont = $td.find('div').html(); //lee contenido del div
//        $td.html(cont);  //fija contenido y elimina controles
//    });
//    FijModoNormal(but);
//}
//function rowEdit(but) {  //Inicia la edición de una fila
//    var $row = $(but).parents('tr');  //accede a la fila
//    var $cols = $row.find('td');  //lee campos
//    if (ModoEdicion($row)) return;  //Ya está en edición
//    //Pone en modo de edición
//    IterarCamposEdit($cols, function ($td) {  //itera por la columnas
//        var cont = $td.html(); //lee contenido
//        var div = '<div style="display: none;">' + cont + '</div>';  //guarda contenido
//        var input = '<input class="form-control input-sm"  value="' + cont + '">';
//        $td.html(div + input);  //fija contenido
//    });
//    FijModoEdit(but);
//}
//function rowElim(but) {  //Elimina la fila actual
//    var $row = $(but).parents('tr');  //accede a la fila
//    params.onBeforeDelete($row);
//    $row.remove();
//    params.onDelete();
//}
//function rowAddNew(tabId) {  //Agrega fila a la tabla indicada.
//    var $tab_en_edic = $("#" + tabId);  //Table to edit
//    var $filas = $tab_en_edic.find('tbody template');
//    var template = true;
//    if ($filas.length == 0) {
//        $filas = $tab_en_edic.find('tbody tr');
//        template = false;
//    }
//    if ($filas.length == 0) {
//        //No hay filas de datos. Hay que crearlas completas
//        var $row = $tab_en_edic.find('thead tr');  //encabezado
//        if ($row.length > 1)
//            $row = $row.last();
//        var $cols = $row.find('th');  //lee campos
//        if (!$cols.is('[name="buttons"]'))
//            $cols = $cols.add($('<th name="buttons"></th>'));
//        //construye html
//        var htmlDat = '';
//        $cols.each(function () {
//            if ($(this).attr('name') == 'buttons') {
//                //Es columna de botones
//                htmlDat = htmlDat + colEdicHtml;  //agrega botones
//            } else {
//                htmlDat = htmlDat + '<td></td>';
//            }
//        });
//        $tab_en_edic.find('tbody').append('<tr>' + htmlDat + '</tr>');
//    } else {
//        //Hay otras filas, podemos clonar la última fila, para copiar los botones
//        var $ultFila = null;
//        if (template) {
//            $ultFila = $tab_en_edic.find('template');
//            var parent = $ultFila.parent();
//            $ultFila = $("<tr></tr>").html($ultFila.html());
//            if ($ultFila.find('td#buttons').length == 0) {
//                $ultFila.append($("<td>").append(newColHtml));
//            }
//            parent.append($ultFila);
//        } else {
//            $ultFila = $tab_en_edic.find('tr:last');
//            $ultFila.clone().appendTo($ultFila.parent());
//            $ultFila = $tab_en_edic.find('tr:last');
//            var $cols = $ultFila.find('td');  //lee campos
//            $cols.each(function () {
//                if ($(this).attr('name') == 'buttons') {
//                    //Es columna de botones
//                } else {
//                    $(this).html('');  //limpia contenido
//                }
//            });
//        }
//    }
//    params.onAdd();
//}
//function TableToCSV(tabId, separator) {  //Convierte tabla a CSV
//    var datFil = '';
//    var tmp = '';
//    var $tab_en_edic = $("#" + tabId);  //Table source
//    $tab_en_edic.find('tbody tr').each(function () {
//        //Termina la edición si es que existe
//        if (ModoEdicion($(this))) {
//            $(this).find('#bAcep').click();  //acepta edición
//        }
//        var $cols = $(this).find('td');  //lee campos
//        datFil = '';
//        $cols.each(function () {
//            if ($(this).attr('name') == 'buttons') {
//                //Es columna de botones
//            } else {
//                datFil = datFil + $(this).html() + separator;
//            }
//        });
//        if (datFil != '') {
//            datFil = datFil.substr(0, datFil.length - separator.length);
//        }
//        tmp = tmp + datFil + '\n';
//    });
//    return tmp;
//}


//$('.carousel').carousel({
//    interval: 2000
//  })


//  function myFunction() {
//    var x = document.getElementById("myTopnav");
//    if (x.className === "topnav") {
//      x.className += " responsive";
//    } else {
//      x.className = "topnav";
//    }
//  }


//$(document).ready(function(){
//  $("#liDropdown").hover( ()=>{
//    if($("#liDropdown").hasClass("show")){
//      $("#liDropdown").removeClass("show")
//      $("#divDropdown-menu").removeClass("show")
//      document.getElementById("navbarDropdown1").setAttribute("aria-expanded", "false")

//    }else{
//      if($("#liDropdown").hasClass("active")){
//        document.getElementById("liDropdown").setAttribute("class","nav-item dropdown show active")
//      }
//      else{
//        document.getElementById("liDropdown").setAttribute("class","nav-item dropdown show")
//      }
//      document.getElementById("navbarDropdown1").setAttribute("aria-expanded", "true")
//      document.getElementById("divDropdown-menu").setAttribute("class","dropdown-menu show")
//    } 

//  } 
//)
//})


//function subForm(){
//    $.ajax({
//        type: "POST",
//        url: '/a',

//        data: JSON.stringify(
//            {
//                login: document.getElementById("inputEmail").value,
//                pass: document.getElementById("inputPassword").value
//            }
//        ),//
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (response) {
//            // localStorage.setItem('Authorization', response.token)

//            //  Headers.append('Authorization', response.token)
//             document.location.href = "/adminNews"
//        },
//        error: function (response) {

//        }
//    });



//}

//function exitAdm(){

//    $.ajax({
//        type: "POST",
//        url: '/exit',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (response) {
//            // localStorage.setItem('Authorization', response.token)

//            //  Headers.append('Authorization', response.token)
//            document.location.href ='/'
//        },
//        error: function (response) {

//        }
//    })

//}

//function sendSubNews(){

//    document.getElementById("subHidden").click();
//}


//$('#formId').on('submit', function(e){
//    e.preventDefault()
//    var formData = new FormData(this)

//    $.ajax({
//        type: 'POST',
//        url: '/adminNews',
//        data:formData,
//        processData:false,
//        contentType:false,
//        success: function(r){
//            alert('Успешно добавлено!')
//            document.location.href ='/adminNews'
//        },
//        error: function(er){
//            console.log(er);
//            alert('Упс, что то пошло не так')
//        }
//    })
//})

//function sendSubCourses(){

//    document.getElementById("subHidden").click();
//}

//$('#coursesFormId').on('submit', function(e){
//    e.preventDefault()
//    var formData = new FormData(this)

//    $.ajax({
//        type: 'POST',
//        url: '/adminCourses',
//        data:formData,
//        processData:false,
//        contentType:false,
//        success: function(r){
//            alert('Успешно добавлено!')
//            document.location.href ='/adminCourses'
//        },
//        error: function(er){
//            console.log(er);
//            alert('Упс, что то пошло не так')
//        }
//    })
//})


//function sendSubTeacher(){

//    document.getElementById("subHidden").click();
//}

//$('#teacherFormId').on('submit', function(e){
//    e.preventDefault()
//    var formData = new FormData(this)

//    $.ajax({
//        type: 'POST',
//        url: '/adminTeacher',
//        data:formData,
//        processData:false,
//        contentType:false,
//        success: function(r){
//            alert('Успешно добавлено!')
//            document.location.href ='/adminTeacher'
//        },
//        error: function(er){
//            console.log(er);
//            alert('Упс, что то пошло не так')
//        }
//    })
//})
//function sendSubProduct(){

//    document.getElementById("subHidden").click();
//}

//$('#productFormId').on('submit', function(e){
//    console.log('344556')
//    e.preventDefault()
//    var formData = new FormData(this)
//    $.ajax({
//        type: 'POST',
//        url: '/adminProduct',
//        data:formData,
//        processData:false,
//        contentType:false,
//        success: function(r){
//            alert('Успешно добавлено!')
//            document.location.href ='/adminProduct'
//        },
//        error: function(er){
//            console.log(er);
//            alert('Упс, что то пошло не так')
//        }
//    })
//})

//function sendSubContact(){

//    document.getElementById("subHidden").click();
//}

//$('#contactFormId').on('submit', function(e){
//    e.preventDefault()
//    var formData = new FormData(this)

//    $.ajax({
//        type: 'POST',
//        url: '/adminContact',
//        data:formData,
//        processData:false,
//        contentType:false,
//        success: function(r){
//            alert('Успешно добавлено!')
//            document.location.href ='/adminContact'
//        },
//        error: function(er){
//            console.log(er);
//            alert('Упс, что то пошло не так')
//        }
//    })
//})

//function sendSubService(){

//    document.getElementById("subHidden").click();
//}

//$('#serviceFormId').on('submit', function(e){
//    e.preventDefault()
//    var formData = new FormData(this)

//    $.ajax({
//        type: 'POST',
//        url: '/adminService',
//        data:formData,
//        processData:false,
//        contentType:false,
//        success: function(r){
//            alert('Успешно добавлено!')
//            document.location.href ='/adminService'
//        },
//        error: function(er){
//            console.log(er);
//            alert('Упс, что то пошло не так')
//        }
//    })
//})

//function activElem(elemRef){
//$(".active").removeClass('active')
//document.getElementById(elemRef).setAttribute("class", "active")

//}


//$('#tableAdminNews').SetEditable({
//    columnsEd: "0,1,2" //editable columns

//  })


//  function NewsUpdate(idNews){

//    document.getElementById("recipient-name").value =  document.getElementById("tdTitle"+idNews).value
//    document.getElementById("message-text").value =  document.getElementById("tdText"+idNews).value
//    document.getElementById("idNewsId").value = idNews

//  }

//  function ContactUpdate(idContact){

//    document.getElementById("typeContact").value =  document.getElementById("tdTitle"+idContact).value
//    document.getElementById("message-text").value =  document.getElementById("tdText"+idContact).value
//    document.getElementById("idContactId").value = idContact

//  }
//  function TeacherUpdate(idTeacher){

//    document.getElementById("recipient-name").value =  document.getElementById("tdTitle"+idTeacher).value
//    document.getElementById("message-text").value =  document.getElementById("tdText"+idTeacher).value
//    document.getElementById("idTeacherId").value = idTeacher

//  }

//  function ProductUpdate(idProduct){

//    document.getElementById("recipient-name").value =  document.getElementById("tdTitle"+idProduct).value
//    document.getElementById("recipient-text").value =  document.getElementById("tdText"+idProduct).value
//    document.getElementById("message-text").value =  document.getElementById("tdPrice"+idProduct).value
//    document.getElementById("idProductId").value = idProduct

//  }
//  function ServiceUpdate(idService){

//    document.getElementById("recipient-name").value =  document.getElementById("tdTitle"+idService).value
//    document.getElementById("recipient-text").value =  document.getElementById("tdText"+idService).value
//    document.getElementById("message-text").value =  document.getElementById("tdPrice"+idService).value
//    document.getElementById("idServiceId").value = idService

//  }

//  function CourseUpdate(idCourse){

//    document.getElementById("courseName").value =  document.getElementById("tdTitle"+idCourse).value
//    document.getElementById("courseDescription").value =  document.getElementById("tdText"+idCourse).value
//    var t=document.getElementById("tdDate"+idCourse).value
//    // t=formatDate(t)
//    document.getElementById("dateStart").value =  document.getElementById("tdDate"+idCourse).value
//    document.getElementById("price").value =  document.getElementById("tdPrice"+idCourse).value
//    document.getElementById("duration").value =  document.getElementById("tdDuration"+idCourse).value
//    document.getElementById("teacher").value =  document.getElementById("tdIdTeacher"+idCourse).value
//    document.getElementById("level").value =  document.getElementById("tdForNewbies"+idCourse).value
//    document.getElementById("idCourseId").value = idCourse

//}




$('#submit_btn').click(function () {
    var login = document.getElementById('login').value;
    var password = document.getElementById('password').value;
    if (login !== '' && password !== '') {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: '/Admin/LoginAdmin/',
            data: {
                login: login,
                password: password
            },
            success: function (data) {
                if (data === 'ok')
                    window.location.href = '/Admin/Orders';
                else
                    alert('Пользователь не найден или не является администратором');
                //outputFilmComment(data);
            },
            error: function (data) {
                alert('Error');
            }
        })
    }
});

$('#saveCharact').click(function () {

    var id = document.getElementById('id').value;
    var name = document.getElementById('name').value;
    var headphones = $('#headphones:checked').val();
    var acoustics = $('#acoustics:checked').val();
    var cables = $('#cables:checked').val();
    var drives = $('#drives:checked').val();
    var backpacksAndBags = $('#backpacksAndBags:checked').val();
    var smartWatch = $('#smartWatch:checked').val();
    var smartHouse = $('#smartHouse:checked').val();



    //var password = document.getElementById('password').value;
    //if (login !== '' && password !== '') {
    if (id === "") {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: '/Admin/AddCharacteristic/',
            data: {
                name: name,
                headphones: headphones,
                acoustics: acoustics,
                cables: cables,
                drives: drives,
                backpacksAndBags: backpacksAndBags,
                smartWatch: smartWatch,
                smartHouse: smartHouse
            },
            success: function (data) {
                alert('ok');
                //document.getElementById('name').value = '';
                //document.getElementById('id').value = '';
                $('#cancelChar').click();
                //outputCharacteristics(data);
                window.location.href = '/Admin/Characteristics';
            },
            error: function (data) {
                alert('Error');
            }
        });
    }
    else {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: '/Admin/UpdateCharacteristic/',
            data: {
                id:id,
                name: name,
                headphones: headphones,
                acoustics: acoustics,
                cables: cables,
                drives: drives,
                backpacksAndBags: backpacksAndBags,
                smartWatch: smartWatch,
                smartHouse: smartHouse
            },
            success: function (data) {
                alert('ok');
                $('#cancelChar').click();
                window.location.href = '/Admin/Characteristics';
            },
            error: function (data) {
                alert('Error');
            }
        });
    }
    //}
});

//function outputCharacteristic(data) {
//    var table = document.getElementById('chTable');
//    var tr = document.createElement('tr');
//    tr.setAttribute('class', 'tableElem');
//    var td1 = document.createElement('td');
//    td1.textContent = data[0];
//    tr.insertAdjacentHTML('beforeend', td1.outerHTML);

//    for (var i = 2; i <= 8; i++) {
//        var td2 = document.createElement('td');
//        var input2 = document.createElement('input');
//        input2.setAttribute('type', 'checkbox');
//        if (data[i] === "1")
//            input2.setAttribute('checked', '');
//        input2.setAttribute('disabled', '');
//        td2.insertAdjacentHTML('beforeend', input2.outerHTML);


//        tr.insertAdjacentHTML('beforeend', td2.outerHTML);
//    }
//    var td3 = document.createElement('td');
//    var i3 = document.createElement('i');
//    i3.setAttribute('class', 'fas fa-pencil-alt');
//    td3.insertAdjacentHTML('beforeend', i3.outerHTML);
//    tr.insertAdjacentHTML('beforeend', td3.outerHTML);

//    var td4 = document.createElement('td');
//    var input4 = document.createElement('input');
//    input4.setAttribute('type', 'hidden');
//    input4.setAttribute('id', 'deleteid');
//    input4.setAttribute('value', data[0]);
//    td4.insertAdjacentHTML('beforeend', input4.outerHTML);
//    var i4 = document.createElement('i');
//    i4.setAttribute('class', 'fas fa-pencil-alt');
//    td4.insertAdjacentHTML('beforeend', i4.outerHTML);
//    tr.insertAdjacentHTML('beforeend', td4.outerHTML);



//    table.insertAdjacentHTML('beforeend', tr.outerHTML);

//}

$('.deleteCharBtn').click(function () {
    var id = $(this).prev().val();
    $.ajax({
        type: "GET",
        dataType: "json",
        url: '/Admin/DeleteCharacteristic/',
        data: {
            id: id
        },
        success: function (data) {
            alert('ok');
            //document.getElementById('name').value = '';
            //outputCharacteristics(data);
            window.location.href = '/Admin/Characteristics';
        },
        error: function (data) {
            alert('Error');
        }
    });
});
$('.updateCharBtn').click(function () {
    var name = $(this).prev().val();
    var id = $(this).prev().prev().val();
    var elem = $(this).prev().prev().prev().val();
    $('.plus-btn').click();
    document.getElementById('id').value =id;
    document.getElementById('name').value = name;
    var el = elem.split(',');
    if (el[0] === "value")
        document.getElementById('headphones').setAttribute('checked', 'false');
    if (el[1] === "value")
        document.getElementById('acoustics').setAttribute('checked', 'checked');
    if (el[2] === "value")
        document.getElementById('cables').setAttribute('checked', 'checked');
    if (el[3] === "value")
        document.getElementById('drives').setAttribute('checked', 'checked');
    if (el[4] === "value")
        document.getElementById('backpacksAndBags').setAttribute('checked', 'checked');
    if (el[5] === "value")
        document.getElementById('smartWatch').setAttribute('checked', 'checked');
    if (el[6] === "value")
        document.getElementById('smartHouse').setAttribute('checked', 'checked');
});
$('#cancelChar').click(function () {

    document.getElementById('id').value = "";
    document.getElementById('name').value = "";
    document.getElementById('headphones').removeAttribute('checked');
    document.getElementById('acoustics').removeAttribute('checked');
    document.getElementById('cables').removeAttribute('checked');
    document.getElementById('drives').removeAttribute('checked');
    document.getElementById('backpacksAndBags').removeAttribute('checked');
    document.getElementById('smartWatch').removeAttribute('checked');
    document.getElementById('smartHouse').removeAttribute('checked');
});
//function outputCharacteristics(data) {
//    var table = document.getElementById('chTable');
//    $('.tableElem').remove();
//    for (var i = 0; i < data.length; i=i+2) {
//        var tr = document.createElement('tr');
//        tr.setAttribute('class', 'tableElem');
//        var td1 = document.createElement('td');
//        td1.textContent = data[i][0];
//        tr.insertAdjacentHTML('beforeend', td1.outerHTML);
//        for (var j = 0; j <= 6; j++) {
//            var td2 = document.createElement('td');
//            var input2 = document.createElement('input');
//            input2.setAttribute('type', 'checkbox');
//            if (data[i+1][j] === "1")
//                input2.setAttribute('checked', '');
//            input2.setAttribute('disabled', '');
//            td2.insertAdjacentHTML('beforeend', input2.outerHTML);
//            tr.insertAdjacentHTML('beforeend', td2.outerHTML);
//        }



//        var td3 = document.createElement('td');
//        var input31 = document.createElement('input');
//        input31.setAttribute('type', 'hidden');
//        input31.setAttribute('id', 'deleteid');
//        input31.setAttribute('value', data[i + 1][0] + ',' + data[i + 1][1] + ',' + data[i + 1][2] + ',' + data[i + 1][3] + ',' + data[i + 1][4] + ',' + data[i + 1][5] + ',' + data[i + 1][6]);
//        td3.insertAdjacentHTML('beforeend', input31.outerHTML);
//        var input32 = document.createElement('input');
//        input32.setAttribute('type', 'hidden');
//        input32.setAttribute('id', 'deleteid');
//        input32.setAttribute('value', data[i][1]);
//        td3.insertAdjacentHTML('beforeend', input32.outerHTML);
//        var input33 = document.createElement('input');
//        input33.setAttribute('type', 'hidden');
//        input33.setAttribute('id', 'deleteid');
//        input33.setAttribute('value', data[i][0]);
//        td3.insertAdjacentHTML('beforeend', input33.outerHTML);
//        var i3 = document.createElement('i');
//        i3.setAttribute('class', 'fas fa-pencil-alt updateCharBtn');
//        td3.insertAdjacentHTML('beforeend', i3.outerHTML);
//        tr.insertAdjacentHTML('beforeend', td3.outerHTML);

//        var td4 = document.createElement('td');
//        var input4 = document.createElement('input');
//        input4.setAttribute('type', 'hidden');
//        input4.setAttribute('id', 'deleteid');
//        input4.setAttribute('value', data[i][1]);
//        td4.insertAdjacentHTML('beforeend', input4.outerHTML);
//        var sp = document.createElement('button');
//        sp.setAttribute('class', 'deleteCharBtn');
//        var i4 = document.createElement('i');
//        i4.setAttribute('class', 'fas fa-trash-alt');
//        sp.insertAdjacentHTML('beforeend', i4.outerHTML);
//        td4.insertAdjacentHTML('beforeend', sp.outerHTML);
//        tr.insertAdjacentHTML('beforeend', td4.outerHTML);



//        table.insertAdjacentHTML('beforeend', tr.outerHTML);
//    }

//}


//$('#saveProduct').click(function () {
//    var type = document.getElementById('prod_type').value;
//    var id = document.getElementById('id').value;
//    var name = document.getElementById('name').value;
//    var price = document.getElementById('price').value;
//    var count = document.getElementById('count').value;
//    var description = document.getElementById('description').value;

//    var charact = document.getElementsByClassName('char_prod_text');
//    var char_list = [];
//    for (var i = 0; i < charact.length; i++) {
//        char_list.push(charact[i].value);
//    }

//    var charactName = document.getElementsByClassName('char_prod_label');
//    var charName_list = [];
//    for (var j = 0; j < charactName.length; j++) {
//        charName_list.push(charactName[j].textContent);
//    }

//    var files = document.getElementById('photo').files;
//    var photo_file = document.getElementById('photo_file').value;
//    var data = new FormData();
//    data.append('prodType', type);
//    data.append('id', id);
//    data.append('name', name);
//    data.append('price', price);
//    data.append('count', count);
//    data.append('description', description);
//    data.append('charact', char_list);
//    data.append('charactName', charName_list);
//    data.append('photo_file', photo_file);
//    if (files.length > 0) {
//        if (window.FormData !== undefined) {

//            for (var x = 0; x < files.length; x++) {
//                data.append("file" + x, files[x]);
//            }
//        }
//    }
//    else {
//        data.append("file", "");
//    }

//                $.ajax({
//                    type: "POST",
//                    url: '/Admin/AddProduct/',
//                    contentType: false,
//                    processData: false,
//                    data: data,
//                    success: function (result) {
//                        alert("ok");
//                        window.location.href = '/Admin/Headphones';
//                    },
//                    error: function (xhr, status, p3) {
//                        alert("error");
//                    }
//                });
//    //    } else {
//    //        alert("Браузер не поддерживает загрузку файлов HTML5!");
//    //    }
//    //}
//});
$('.deleteProdBtn').click(function () {
    var id = $(this).prev().val();
    var titleID = document.getElementById('point_id').value;
    $.ajax({
        type: "GET",
        dataType: "json",
        url: '/Admin/DeleteProduct/',
        data: {
            id: id
        },
        success: function (data) {
            alert('ok');
            //document.getElementById('name').value = '';
            //outputCharacteristics(data);
            if (titleID === "1")
                window.location.href = '/Admin/Headphones';
            if (titleID === "2")
                window.location.href = '/Admin/Acoustics';
            if (titleID ==="3")
                window.location.href = '/Admin/Cables';
            if (titleID === "4")
                window.location.href = '/Admin/Drives';
            if (titleID === "5")
                window.location.href = '/Admin/BackpacksAndBags';
            if (titleID === "6")
                window.location.href = '/Admin/SmartWatch';
            if (titleID === "7")
                window.location.href = '/Admin/SmartHouse';
        },
        error: function (data) {
            alert('Error');
        }
    });
});
$('#authorization_user').click(function () {
    document.getElementById('error').setAttribute('class', 'alert alert-warning mt-4 d-none');
    var login = document.getElementById('login').value;
    var pass = document.getElementById('pass').value;
    if (login !== "" && pass !== "") {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: '/Products/Authorization/',
            data: {
                login: login,
                pass:pass
            },
            success: function (data) {
                alert('ok');
                if (data === "ok") {
                    window.location.href = '/User/Index';
                }
                else {
                    document.getElementById('error').textContent = "Пользователь не найден!";
                    document.getElementById('error').setAttribute('class', 'alert alert-warning mt-4');
                }
                //document.getElementById('name').value = '';
                //outputCharacteristics(data);
            },
            error: function (data) {
                alert('Error');
            }
        });
    }
    else {
        document.getElementById('error').textContent = "Заполнены не все поля!";
        document.getElementById('error').setAttribute('class', 'alert alert-warning mt-4');
    }
});
$('#registration_user').click(function () {
    document.getElementById('error').setAttribute('class', 'alert alert-warning mt-4 d-none');
    var login = document.getElementById('login').value;
    var pass = document.getElementById('pass').value;
    if (login !== "" && pass !== "") {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: '/Products/Registration/',
            data: {
                login: login,
                pass: pass
            },
            success: function (data) {
                alert('ok');
                if (data === "ok") {
                    alert('Регистрация успешна. Выполните вход!');
                }
                else {
                    document.getElementById('error').textContent = "Пользователь с таким логином уже зарегистрирован!";
                    document.getElementById('error').setAttribute('class', 'alert alert-warning mt-4');
                }
                //document.getElementById('name').value = '';
                //outputCharacteristics(data);
            },
            error: function (data) {
                alert('Error');
            }
        });
    }
    else {
        document.getElementById('error').textContent = "Заполнены не все поля!";
        document.getElementById('error').setAttribute('class', 'alert alert-warning mt-4');
    }
});

$('.descriprion').click(function () {
    document.getElementById('desc1').setAttribute('class', 'row col-12 ml-0 mr-0 p-0');
    document.getElementById('page').setAttribute('class', 'row col-12 ml-0 mr-0 p-0 d-none');
});

$('.charact').click(function () {
    document.getElementById('desc1').setAttribute('class', 'row col-12 ml-0 mr-0 p-0 d-none'); //убрать страницу с описанием
    document.getElementById('page').setAttribute('class', 'row col-12 ml-0 mr-0 p-0'); //показать страницу с остальными

    document.getElementById('charact').setAttribute('class', 'about-product-point m-0 charact active-point'); //выделить характеристики
    document.getElementById('desc_char1').setAttribute('class', 'row col-12 ml-0 mr-0 about-tech-title pl-5 pr-5'); //показать характеристики
    document.getElementById('desc_char2').setAttribute('class', 'row col-12 ml-0 mr-0 about-tech-text pl-5 pr-5');
    document.getElementById('desc_char3').setAttribute('class', 'row col-12 ml-0 mr-0 about-tech-footer pl-5 pr-5');

    document.getElementById('photo').setAttribute('class', 'about-product-point m-0 photo'); //не выделить фото
    var photo = document.getElementsByClassName('desc_photo'); //скрыть фото
    for (var i = 0; i < photo.length; i++) {
        photo[i].setAttribute('class', 'row col-12 justify-content-center ml-0 mr-0 about-tech-title pl-5 pr-5 desc_photo d-none');
    }

    document.getElementById('comment').setAttribute('class', 'about-product-point m-0 comment'); //не выделить комментарии
    var t = document.getElementById('desc_comment_title');
    if (t !== null) {
        t.setAttribute('class', 'row col-12 justify-content-start ml-0 mr-0 about-tech-title pl-5 pr-5 d-none'); //скрыть комментарии
    }
    document.getElementById('desc_comment').setAttribute('class', 'row col-12 justify-content-center ml-0 mr-0 about-tech-title pl-5 pr-5 d-none');
});

$('.photo').click(function () {
    document.getElementById('desc1').setAttribute('class', 'row col-12 ml-0 mr-0 p-0 d-none'); //убрать страницу с описанием
    document.getElementById('page').setAttribute('class', 'row col-12 ml-0 mr-0 p-0'); //показать страницу с остальными

    document.getElementById('charact').setAttribute('class', 'about-product-point m-0 charact'); //не выделить характеристики
    document.getElementById('desc_char1').setAttribute('class', 'row col-12 ml-0 mr-0 about-tech-title pl-5 pr-5 d-none'); //скрыть характеристики
    document.getElementById('desc_char2').setAttribute('class', 'row col-12 ml-0 mr-0 about-tech-text pl-5 pr-5 d-none');
    document.getElementById('desc_char3').setAttribute('class', 'row col-12 ml-0 mr-0 about-tech-footer pl-5 pr-5 d-none');

    document.getElementById('photo').setAttribute('class', 'about-product-point m-0 photo active-point'); // выделить фото
    var photo = document.getElementsByClassName('desc_photo'); //показать фото
    for (var i = 0; i < photo.length; i++) {
        photo[i].setAttribute('class', 'row col-12 justify-content-center ml-0 mr-0 about-tech-title pl-5 pr-5 desc_photo');
    }

    document.getElementById('comment').setAttribute('class', 'about-product-point m-0 comment'); //не выделить комментарии
    if (t !== null) {
        t.setAttribute('class', 'row col-12 justify-content-start ml-0 mr-0 about-tech-title pl-5 pr-5 d-none'); //скрыть комментарии
    }
    document.getElementById('desc_comment').setAttribute('class', 'row col-12 justify-content-center ml-0 mr-0 about-tech-title pl-5 pr-5 d-none');
});

$('.comment').click(function () {
    document.getElementById('desc1').setAttribute('class', 'row col-12 ml-0 mr-0 p-0 d-none'); //убрать страницу с описанием
    document.getElementById('page').setAttribute('class', 'row col-12 ml-0 mr-0 p-0'); //показать страницу с остальными

    document.getElementById('charact').setAttribute('class', 'about-product-point m-0 charact'); //не выделить характеристики
    document.getElementById('desc_char1').setAttribute('class', 'row col-12 ml-0 mr-0 about-tech-title pl-5 pr-5 d-none'); //скрыть характеристики
    document.getElementById('desc_char2').setAttribute('class', 'row col-12 ml-0 mr-0 about-tech-text pl-5 pr-5 d-none');
    document.getElementById('desc_char3').setAttribute('class', 'row col-12 ml-0 mr-0 about-tech-footer pl-5 pr-5 d-none');

    document.getElementById('photo').setAttribute('class', 'about-product-point m-0 photo'); //не выделить фото
    var photo = document.getElementsByClassName('desc_photo'); //скрыть фото
    for (var i = 0; i < photo.length; i++) {
        photo[i].setAttribute('class', 'row col-12 justify-content-center ml-0 mr-0 about-tech-title pl-5 pr-5 desc_photo d-none');
    }

    document.getElementById('comment').setAttribute('class', 'about-product-point m-0 comment active-point'); //выделить комментарии
    if (t !== null) {
        t.setAttribute('class', 'row col-12 justify-content-start ml-0 mr-0 about-tech-title pl-5 pr-5'); //показать комментарии
    }
    document.getElementById('desc_comment').setAttribute('class', 'row col-12 justify-content-center ml-0 mr-0 about-tech-title pl-5 pr-5');
});

window.onload = function () {
    var is_ = document.getElementById('is_auth').value;
    var url = '';
    if (is_ === "0") {
        url = '/Products/SelectBasket/';
    }
    else {
        url = '/User/SelectBasket/';
    }
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        success: function (data) {
            ountput_basket(data);
        },
        error: function (data) {
            alert('Error');
        }
    });
};

$('.sale_btn').click(function () {
    var is_ = document.getElementById('is_auth').value;
    var id = document.getElementById('id_product').value;
    var url = '';
    if (is_ === "0") {
        url = '/Products/AddBacket/';
    }
    else {
        url = '/User/AddBacket/';
    }
        $.ajax({
            type: "GET",
            dataType: "json",
            url: url,
            data: {
                id: id
            },
            success: function (data) {
                if (data === "error") {
                    alert("Данный товар уже добавлен в корзину!");
                }
                else {
                    ountput_basket(data);
                }
            },
            error: function (data) {
                alert('Error');
            }
        });
        
});
$('.sale_btn_list').click(function () {
    //var is_ = document.getElementById('is_auth').value;
    var id = $(this).prev().val();
    $.ajax({
        type: "GET",
        dataType: "json",
        url: '/User/AddBacket/',
        data: {
            id: id
        },
        success: function (data) {
            if (data === "error") {
                alert("Данный товар уже добавлен в корзину!");
            }
            else {
                ountput_basket(data);
            }
        },
        error: function (data) {
            alert('Error');
        }
    });
});
$('.list_trash').click(function () {
    //var is_ = document.getElementById('is_auth').value;
    var id = $(this).prev().val();
    $.ajax({
        type: "GET",
        dataType: "json",
        url: '/User/DeleteInList/',
        data: {
            id: id
        },
        success: function (data) {
            window.location.href = '/User/ListWishes';
            //if (data === "error") {
            //    alert("Данный товар уже добавлен в корзину!");
            //}
            //else {
            //    ountput_basket(data);
            //}
        },
        error: function (data) {
            alert('Error');
        }
    });
});


function ountput_basket(data) {
    var elem = document.getElementsByClassName('basketelem');
    for (var j = 0; j < elem.length; j=j+0)
        elem[j].remove();

    var parent = document.getElementById('basket_body');
    var final_count = 0;
    if (data.length === 0) {
        document.getElementById('checkout_page').setAttribute('disabled', '');
    }
    else {
        document.getElementById('checkout_page').removeAttribute('disabled');
    }
    for (var i = 0; i < data.length; i++) {
        var div1 = document.createElement('div');
        div1.setAttribute('class', 'col-12 basketelem');

        var div2 = document.createElement('div');
        div2.setAttribute('class', 'row col-12');

        var div_img = document.createElement('div');
        div_img.setAttribute('class', 'col-3');
        var img = document.createElement('img');
        img.setAttribute('class', 'w-100');
        img.setAttribute('src', data[i].photo.slice(1));
        div_img.insertAdjacentHTML('beforeend', img.outerHTML);


        var div_name = document.createElement('div');
        div_name.setAttribute('class', 'col-8');
        var label_name = document.createElement('label');
        label_name.setAttribute('class', 'modal-class');
        label_name.textContent = data[i].name;
        div_name.insertAdjacentHTML('beforeend', label_name.outerHTML);

        var div_trash = document.createElement('div');
        div_trash.setAttribute('class', 'col-1');
        var input_id = document.createElement('input');
        input_id.setAttribute('type', 'hidden');
        input_id.setAttribute('value', data[i].id_product);
        div_trash.insertAdjacentHTML('beforeend', input_id.outerHTML);
        var i_trash = document.createElement('i');
        i_trash.setAttribute('class', 'fas fa-trash-alt delete_btn');
        i_trash.style.fontSize = '1.5rem';
        div_trash.insertAdjacentHTML('beforeend', i_trash.outerHTML);

        div2.insertAdjacentHTML('beforeend', div_img.outerHTML);
        div2.insertAdjacentHTML('beforeend', div_name.outerHTML);
        div2.insertAdjacentHTML('beforeend', input_id.outerHTML);
        div2.insertAdjacentHTML('beforeend', div_trash.outerHTML);

        var div3 = document.createElement('div');
        div3.setAttribute('class', 'row col-12');

        var div4 = document.createElement('div');
        div4.setAttribute('class', 'col-12');

        var div5 = document.createElement('div');
        div5.style.cssFloat = 'right';

        var i_minus = document.createElement('i');
        i_minus.setAttribute('class', 'fas fa-minus minus_btn');
        i_minus.style.fontSize = '1.5rem';

        var label_count = document.createElement('label');
        label_count.setAttribute('class', 'pr-3 pl-3');
        label_count.style.fontSize = '1.5rem';
        label_count.textContent = data[i].count;

        var i_plus = document.createElement('i');
        i_plus.setAttribute('class', 'fas fa-plus plus_btn');
        i_plus.style.fontSize = '1.5rem';

        var label_price = document.createElement('label');
        label_price.setAttribute('class', 'pl-5');
        label_price.style.fontSize = '1.7rem';
        label_price.style.color = 'rgb(253,80,46)';
        label_price.textContent = data[i].price * data[i].count + ' руб';
        final_count = final_count + (data[i].price * data[i].count);


        div5.insertAdjacentHTML('beforeend', i_minus.outerHTML);
        div5.insertAdjacentHTML('beforeend', input_id.outerHTML);
        div5.insertAdjacentHTML('beforeend', label_count.outerHTML);
        div5.insertAdjacentHTML('beforeend', i_plus.outerHTML);
        div5.insertAdjacentHTML('beforeend', label_price.outerHTML);

        div4.insertAdjacentHTML('beforeend', div5.outerHTML);
        div3.insertAdjacentHTML('beforeend', div4.outerHTML);
                                   
        div1.insertAdjacentHTML('beforeend', div2.outerHTML);
        div1.insertAdjacentHTML('beforeend', div3.outerHTML);
        var hr = document.createElement('hr');
        div1.insertAdjacentHTML('beforeend', hr.outerHTML);



        parent.insertAdjacentHTML('beforeend', div1.outerHTML);
    }
    document.getElementById('final_count').textContent = final_count + ' руб';
    //alert(data);
    var basket_count = document.getElementsByClassName('badge-light');
    for (var k = 0; k < basket_count.length; k++) {
        basket_count[k].textContent = data.length;
    }
}

$('div#basket_body').on('click', '.minus_btn', function () {
    var is_ = document.getElementById('is_auth').value;
    var url = '';
    if (is_ === "0") {
        url = '/Products/MinusProductCount/';
    }
    else {
        url = '/User/MinusProductCount/';
    }
    id = $(this).next().val();
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        data: {
            id: id
        },
        success: function (data) {
            if (data === "error") {
                alert("Минимальное количество 1!");
            }
            else {
                ountput_basket(data);
            }
        },
        error: function (data) {
            alert('Error');
        }
    });
});
$('div#basket_body').on('click', '.plus_btn', function () {
    id = $(this).prev().prev().val();
    var is_ = document.getElementById('is_auth').value;
    var url = '';
    if (is_ === "0") {
        url = '/Products/AddProductCount/';
    }
    else {
        url = '/User/AddProductCount/';
    }
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        data: {
            id: id
        },
        success: function (data) {
            if (data === "error") {
                alert("Количества больше нет!");
            }
            else {
                ountput_basket(data);
            }
        },
        error: function (data) {
            alert('Error');
        }
    });
});
$('div#basket_body').on('click', '.delete_btn', function () {
    id = $(this).prev().val();
    var is_ = document.getElementById('is_auth').value;
    var url = '';
    if (is_ === "0") {
        url = '/Products/DeleteProductInBasket/';
    }
    else {
        url = '/User/DeleteProductInBasket/';
    }
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        data: {
            id: id
        },
        success: function (data) {
            ountput_basket(data);
        },
        error: function (data) {
            alert('Error');
        }
    });
});
$('.order_trash').click(function () {
    var id = $(this).prev().val();
    $.ajax({
        type: "GET",
        dataType: "json",
        url: '/Admin/DeleteOrder/',
        data: {
            id:id
        },
        success: function (data) {
            window.location.href = '/Admin/Orders/';

        },
        error: function (data) {
            alert('Error');
        }
    });
});
$('#order_submit').click(function () {
    var is_ = document.getElementById('is_auth').value;
    document.getElementById('error').setAttribute('class', 'alert alert-warning mt-4 d-none');
    var fio = document.getElementById('fio').value;
    var email = document.getElementById('email').value;
    var phone = document.getElementById('phone').value;
    var url = '';
    var href = '';
    if (fio === "" || email === "" || phone === "") {
        document.getElementById('error').textContent = "Заполнены не все поля!";
        document.getElementById('error').setAttribute('class', 'alert alert-warning mt-4');
    }
    else {
        if (is_ === "0") {
            url = '/Products/SendOrder/';
            href = '/Products';
        }
        else {
            url = '/User/SendOrder/';
            href = '/User';
        }
        $.ajax({
            type: "GET",
            dataType: "json",
            url: url,
            data: {
                fio: fio,
                email: email,
                phone:phone
            },
            success: function (data) {
                alert("Заявка успешно отправлена!");
                window.location.href = href;

            },
            error: function (data) {
                alert('Error');
            }
        });
    }
});
$('#comment_save_btn').click(function () {
    var id = document.getElementById('id_product').value;
    var plus = document.getElementById('plus_text').value;
    var minus = document.getElementById('minus_text').value;
    var comment = document.getElementById('comment_text').value;
    $.ajax({
        type: "GET",
        dataType: "json",
        url: '/User/SendComment/',
        data: {
            id: id,
            plus: plus,
            minus: minus,
            comment:comment
        },
        success: function (data) {
            output_comment(data);
            alert("ok");
            document.getElementById('comment_cancel').click();
            document.getElementById('plus_text').value="";
            document.getElementById('minus_text').value="";
            document.getElementById('comment_text').value="";
        },
        error: function (data) {
            alert('Error');
        }
    });
});
function output_comment(data) {
    var parent = document.getElementById('desc_comment');
    var t = document.getElementsByClassName('about-tech-comment');
    for (var j = 0; j < t.length; j = j + 0) {
        t[j].remove();
    }
    for (var i = 0; i < data.length; i=i+4) {
        var div1 = document.createElement('div');
        div1.setAttribute('class', 'row col-12 about-tech-comment');

        var div_date = document.createElement('div');
        div_date.setAttribute('class', 'col-12 col-cm-12 col-md-12 col-lg-12 col-xl-12 m-0 p-0');
        var label_date = document.createElement('label');
        label_date.setAttribute('class', 'about-prod-comment-date');
        label_date.textContent = data[i];
        div_date.insertAdjacentHTML('beforeend', label_date.outerHTML);

        var div_comment = document.createElement('div');
        div_comment.setAttribute('class', 'col-12 col-cm-12 col-md-12 col-lg-12 col-xl-12 m-0 p-0');
        var label_comment = document.createElement('label');
        label_comment.setAttribute('class', 'about-prod-comment-text1');
        label_comment.textContent = data[i+1];
        div_comment.insertAdjacentHTML('beforeend', label_comment.outerHTML);

        var div_plus= document.createElement('div');
        div_plus.setAttribute('class', 'col-12 col-cm-12 col-md-12 col-lg-12 col-xl-12 m-0 p-0');
        var i_plus = document.createElement('i');
        i_plus.setAttribute('class', 'fas fa-plus plus');
        var label_plus = document.createElement('label');
        label_plus.setAttribute('class', 'about-prod-comment-text2');
        label_plus.textContent = data[i+2];
        div_plus.insertAdjacentHTML('beforeend', i_plus.outerHTML);
        div_plus.insertAdjacentHTML('beforeend', label_plus.outerHTML);

        var div_minus = document.createElement('div');
        div_minus.setAttribute('class', 'col-12 col-cm-12 col-md-12 col-lg-12 col-xl-12 m-0 p-0');
        var i_minus = document.createElement('i');
        i_minus.setAttribute('class', 'fas fa-minus minus');
        var label_minus = document.createElement('label');
        label_minus.setAttribute('class', 'about-prod-comment-text2');
        label_minus.textContent = data[i+3];
        div_minus.insertAdjacentHTML('beforeend', i_minus.outerHTML);
        div_minus.insertAdjacentHTML('beforeend', label_minus.outerHTML);


        div1.insertAdjacentHTML('beforeend', div_date.outerHTML);
        div1.insertAdjacentHTML('beforeend', div_comment.outerHTML);
        div1.insertAdjacentHTML('beforeend', div_plus.outerHTML);
        div1.insertAdjacentHTML('beforeend', div_minus.outerHTML);


        parent.insertAdjacentHTML('beforeend', div1.outerHTML);
    }
}
$('.heart_btn').click(function () {
    var id = document.getElementById('id_product').value;
    $.ajax({
        type: "GET",
        dataType: "json",
        url: '/User/AddListWishes/',
        data: {
            id: id
        },
        success: function (data) {
            if (data === "error") {
                alert("Товар уже добавлен в список желаний!");
            }
            else {
                alert('ok');
            }
        },
        error: function (data) {
            alert('Error');
        }
    });
});
//<div class="">
//    //<div class="">
//    //    <label class="">
//    //        12.12.2018
//    //                                    </label>
//    //</div>
//    //<div class="">
//    //    <label class="">
//    //        @comment.text
//    //                                    </label>
//    //</div>
//    //<div class="">
//    //    <i class=""></i>
//    //    <label class="">
//    //        @comment.plus
//    //                                    </label>
//    //</div>
//    <div class="col-12 col-cm-12 col-md-12 col-lg-12 col-xl-12 m-0 p-0">
//        <i class="fas fa-minus minus"></i>
//        <label class="about-prod-comment-text2">
//            @comment.minus
//                                        </label>
//    </div>
//</div>



//@for(var i=0;i<ViewBag.basket_count; i++)
                    //{
                    //<div1 class="col-12">
                    //    <div2 class="row col-12">
                    //        //<div_img class="col-3">
                    //        //            <img src="@Url.Content(ViewBag.basket_photo[i])" class="w-100">
                    //        //</div>
                    //        //<div_label class="col-8">
                    //        //    <label class="modal-class">@ViewBag.basket_info[i].name</label>

                    //        //</div>
                    //        //<div_trash class="col-1">
                                //input hidden value=id
                    //        //    <i class="fas fa-trash-alt" style="font-size: 1.5rem"></i>
                    //        //</div>
                    //    </div>
                        //<div3 class="row col-12">
                        //    <div4 class="col-12">
                        //        <div5 class=""div_with_i style="float: right;">
                        //            <i_minus class="fas fa-minus" style="font-size: 1.5rem"></i>
                        //            <label_count style="font-size:1.5rem">@ViewBag.count[i]</label>
                        //            @*<input type="text" disabled="" min="1" name="" value="1" style="width: 5rem; font-size: 1.5rem;  text-align: center; background-color: #fff; border: none">*@
                        //            <i_plus class="fas fa-plus" style="font-size: 1.5rem"></i>
                        //        </div>
                        //    </div>
                        //</div>
                        //<hr>
                    //</div>
                    //}





//$('.open_basket').click(function () {
//    var id = document.getElementById('id_product').value;
//    $.ajax({
//        type: "POST",
//        dataType: "json",
//        url: '/Products/AddBacket/',
//        data: {
//            id: id
//        },
//        success: function (data) {
//            if (data === "error") {
//                alert("Данный товар уже добавлен в корзину!");
//            }
//            else {
//                alert(data);
//                var basket_count = document.getElementsByClassName('badge-light');
//                for (var i = 0; i < basket_count.length; i++) {
//                    basket_count[i].textContent = data;
//                }
//            }
//        },
//        error: function (data) {
//            alert('Error');
//        }
//    });
//});

//$('.updateProdBtn').click(function () {
//    //var name = $(this).prev().val();
//    var id = $(this).prev().val();
//    //var elem = $(this).prev().prev().prev().val();
//    $.ajax({
//        type: "GET",
//        dataType: "json",
//        url: '/Admin/SelectProduct/',
//        data: {
//            id: id
//        },
//        success: function (data) {
//            alert('ok');
//            //document.getElementById('name').value = '';
//            //outputCharacteristics(data);
//            //window.location.href = '/Admin/Headphones';
//            $('.plus-btn').click();
//            document.getElementById('id').value = id;
//            document.getElementById('name').value = data[0][0];
//            document.getElementById('price').value = data[0][1];
//            document.getElementById('count').value = data[0][2];
//            document.getElementById('description').value = data[0][3];
//            for (var i = 0; i < data[1].length; i = i + 2) {
//                document.getElementById(data[1][i]).value = data[1][i + 1];
//                //document.getElementsByName(data[1][i]).value = data[1][i + 1];
//            }
//            document.getElementById('photo_file').value = data[2];
//        },
//        error: function (data) {
//            alert('Error');
//        }
//    });
    
//});