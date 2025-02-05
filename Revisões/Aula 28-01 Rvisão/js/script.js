$(document).ready(function () {
  // alert('hellou word');
  var $lampada = $("#lampada");

  function ligarVerde() {
    $lampada.css("background-color", "green");
  }
  function ligarvermelho() {
    $lampada.css("background-color", "red");
  }
  function ligarazul() {
    $lampada.css("background-color", "blue");
  }
  function ligaramarelo() {
    $lampada.css("background-color", "yellow");
  }
  function desligar() {
    $lampada.css("background-color", "white");
  }

  function trocarfrase() {
    //Array de frases
    var frases = [
      "Falta muito para sexta-feira",
      "A vida é bela",
      "Estou com fome",
      "Prova surpresa",
    ];
    var $conteudo = $("#conteudo");
    var indice = Math.floor(Math.random() * frases.length);
    //var indice = Math.floor(Math.random() * 4);//
    $conteudo.html(frases[indice]);
  }

  /********************************************************* */
  function validar() {
    var nome = $("#txtnome").val();
    var idade = $("#txtidade").val();

    if (nome == "") {
      alert("O campo nome não pode ser vazio");
      $("#txtnome").focus();
      return false;
    }

    if (idade == "") {
      alert("O campo idade não pode ser vazio!");
      $("#txtidade").focus();
      return false;
    }
  }

  window.validar = validar;
  window.trocarfrase = trocarfrase;
  window.ligarVerde = ligarVerde;
  window.ligarvermelho = ligarvermelho;
  window.ligarazul = ligarazul;
  window.ligaramarelo = ligaramarelo;
  window.desligar = desligar;
});
