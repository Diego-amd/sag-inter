/* Função de Funções Administrativas */

function funAdmLayout() {
    document.getElementById("fun-adm-layout").classList.toggle("mostrar");
  }
  
  window.onclick = function(fechar) {
    if (!fechar.target.matches('.botao-fun-adm')) {
      var descer = document.getElementsByClassName("fun-adm-content");
      var i;
      for (i = 0; i < descer.length; i++) {
        var abrirDescer = descer[i];
        if (abrirDescer.classList.contains('mostrar')) {
            abrirDescer.classList.remove('mostrar');
        }
      }
    }
  }