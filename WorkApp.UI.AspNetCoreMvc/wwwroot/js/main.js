$(document).ready(function() {
  $("#projeEkle").hide();
  $("#iptalButton").hide();
});
$(document).ready(function() {

});
function projeOlustur() {
  $("#projeEkle").show();
  $("#iptalButton").show();

  $("#addButton").hide();
  $("#listeleBoard").hide();
}

function projeListele() {
  $("#projeEkle").hide();
  $("#iptalButton").hide();

  $("#addButton").show();
  $("#listeleBoard").show();
}
