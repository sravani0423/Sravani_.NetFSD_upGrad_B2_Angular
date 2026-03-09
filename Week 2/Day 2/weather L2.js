const API_KEY = "fadb6aa560b1027fefb3d1ddb40ea149";
const CITY = "Hyderabad";

// URL generator (arrow function)
const getWeatherURL = (city) =>
  `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${API_KEY}&units=metric`;


//using Promises

export const fetchWeatherWithPromises = (city) => {
  return fetch(getWeatherURL(city))
    .then(response => {
      if (!response.ok) {
        throw new Error("Failed to fetch weather data");
      }
      return response.json();
    })
    .then(data => formatWeather(data))
    .catch(error => {
      console.error(`Error: ${error.message}`);
    });
};


// using async/await

export const fetchWeatherAsync = async (city) => {
  try {
    const response = await fetch(getWeatherURL(city));

    if (!response.ok) {
      throw new Error("Failed to fetch weather data");
    }

    const data = await response.json();

    console.log(formatWeather(data));

  } catch (error) {
    console.error(`Error: ${error.message}`);
  }
};


// weather data formatter

const formatWeather = (data) => {
  return `
WEATHER REPORT 
City: ${data.name}
Temperature: ${data.main.temp}°C
Feels Like: ${data.main.feels_like}°C
Humidity: ${data.main.humidity}%
Condition: ${data.weather[0].description}
Wind Speed: ${data.wind.speed} m/s

`;
};


//Example

// Promise Version
fetchWeatherWithPromises(CITY).then(report => {
  if (report) console.log(report);
});

// Async/Await Version
fetchWeatherAsync(CITY);