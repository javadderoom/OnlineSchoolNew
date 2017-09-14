//var img = new Image();
//img.src = 'http://localhost:4911/Dashboard/Images/lionLogo.jpg';
//img.width = "50";
//img.height = "50";
//img.onload = function () {
//    $('.pull-right').append(img);
//};
function printGrid(printdiv, gvID, gvCellToDelete) {

    var headstr = "<html><head><title></title></head><body>";
    var footstr = "</body>";
    var logostr = '<div style="width: 100%; margin: 10px;padding:10px; text-align: center; height: 60px;"><div class="pull-right"> : شماره ثبت<br /> : تاریخ</div><div>به نام خدا<br />مدرسه هوشمند</div><div class="pull-left" style="text-align:center;padding-bottom:50px;">موارد مورد نیاز دیگر</div></div>';

    var newstr = document.all.item(printdiv).innerHTML;
    var oldstr = document.body.innerHTML;
    document.body.innerHTML = headstr + logostr + newstr + footstr;

    var rows = document.getElementById(gvID).rows;
    for (var i = 0; i < rows.length; i++) {
        if (gvCellToDelete != n)
        { rows[i].deleteCell(gvCellToDelete); }

    }

    window.print();
    document.body.innerHTML = oldstr;

    $('#modalShowDetails').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
    $('.fade').remove();

    return true;
}
function printGrid(printdiv, gvID) {

    var headstr = "<html><head><title></title></head><body>";
    var footstr = "</body>";
    var logostr = '<div style="width: 100%; margin: 10px;padding:10px; text-align: center; height: 60px;"><div class="pull-right"> : شماره ثبت<br /> : تاریخ</div><div>به نام خدا<br />مدرسه هوشمند</div><div class="pull-left" style="text-align:center;padding-bottom:50px;">موارد مورد نیاز دیگر</div></div>';

    var newstr = document.all.item(printdiv).innerHTML;
    var oldstr = document.body.innerHTML;
    document.body.innerHTML = headstr + logostr + newstr + footstr;

    window.print();
    document.body.innerHTML = oldstr;

    $('#modalShowDetails').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
    $('.fade').remove();

    return true;
}
function printModal(printdiv) {

    var headstr = "<html><head><title></title></head><body>";
    var footstr = "</body>";
    var logostr = '<div style="width: 100%; margin: 10px;padding:10px; text-align: center; height: 60px;"><div class="pull-right"> : شماره ثبت<br /> : تاریخ</div><div>به نام خدا<br />مدرسه هوشمند</div><div class="pull-left" style="text-align:center;padding-bottom:50px;">موارد مورد نیاز دیگر</div></div>';

    var newstr = document.all.item(printdiv).innerHTML;
    var oldstr = document.body.innerHTML;
    document.body.innerHTML = headstr + logostr + newstr + footstr;


    window.print();
    document.body.innerHTML = oldstr;

    $('#modalShowDetails').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
    $('.fade').remove();

    return true;
}