$(document).ready(() => {
    $('#searchButton').click(() => {
      const city = $('#cityInput').val();
      if (city) {
        fetchWeatherData(city);
      }
    });
  
    function fetchWeatherData(city) {
      const apiKey = '7de3c642976aaedb54bb454f6d396c3f';
      const apiUrl = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}`;
  
      $.ajax({
        url: apiUrl,
        method: 'GET',
        dataType: 'json',
        success: handleResponse,
        error: handleError
      });
    }
  
    function handleResponse(response) {
      const cityName = response.name;
      const temperature = response.main.temp;
      const description = response.weather[0].description;
  
      const weatherData = `
        <div class="city-name">${cityName}</div>
        <div class="weather-info">
          <div class="item">Temperature: ${temperature}°C</div>
          <div class="item">Description: ${description}</div>
        </div>
      `;
  
      $('#weatherData').html(weatherData);
    }
  
    function handleError(error) {
      console.error('Error:', error);
      $('#weatherData').html('Failed to fetch weather data.');
    }
  });
  