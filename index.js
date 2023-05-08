const dataContainer = document.getElementById('data-container');

fetch('https://localhost:7220/api/pokedex')
  .then(response => response.json())
  .then(data => {
    // Cria elementos HTML para exibir os dados da resposta
    const dataElement = document.createElement('p');
    dataElement.textContent = `Dados: ${JSON.stringify(data)}`;

    // Adiciona os elementos ao container no DOM
    dataContainer.appendChild(dataElement);
  })
  .catch(error => {
    console.error('Erro:', error);
  });
