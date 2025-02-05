$(document).ready(function () {
  //ocultar a div-console.error
  $("#div-erro").hide();
  async function carregarDados() {
    try {
      const response = await fetch(
        "https://www.mercadobitcoin.net/api/BTC/trades/"
      );
      const dados = await response.json();
      prepararMapas(dados);
    } catch {
      e;
    }
    {
      $("#div.erro").show();
      $("#div.erro").html("<b>Erro ao acessar API.<br>");
    }
  }

  function prepararMapas(dados){
    google.charts.load('current', {'packages':['corechart']});
    google.charts.setOnLoadCallback(drawChart);
  //criar um array para os dados de cada linha
    dados_linha = [['Índice', 'Preco']];
    $.each(dados, function(i, item) {
        dados_linha.push([new Date(item.date * 1000), item.price])
    });

  function drawChart() {
    var data = google.visualization.arrayToDataTable(dados_linha);

    var options = {
      title: 'Company Performance',
      curveType: 'function',
      legend: { position: 'bottom' }
    };

    var chart = new google.visualization.LineChart(document.getElementById('grafico-precos'));

    chart.draw(data, options);
  }
}


  //tornar o metodo visivel para os eventos
  window.carregarDados = carregarDados;
});
