window.onload = function () {
  loadHistory();
};

function getLocation() {
  if (!navigator.geolocation) {
    document.getElementById("msg").innerText = "Geolocation is not supported by this browser.";
    return;
  }

  navigator.geolocation.getCurrentPosition(successCallback, errorCallback, {
    timeout: 10000
  });
}

function successCallback(position) {
  let latitude = position.coords.latitude;
  let longitude = position.coords.longitude;

  document.getElementById("lat").innerText = latitude;
  document.getElementById("lon").innerText = longitude;
  document.getElementById("msg").innerText = "";

  let entry = {
    lat: latitude,
    lon: longitude,
    time: new Date().toLocaleString()
  };

  let history = JSON.parse(localStorage.getItem("locations")) || [];
  history.unshift(entry);

  if (history.length > 5) {
    history = history.slice(0, 5);
  }

  localStorage.setItem("locations", JSON.stringify(history));
  displayHistory(history);
}

function errorCallback(error) {
  let message = "";

  if (error.code === 1) {
    message = "Permission denied by user.";
  } else if (error.code === 2) {
    message = "Location unavailable.";
  } else if (error.code === 3) {
    message = "Location request timed out.";
  } else {
    message = "Unknown error occurred.";
  }

  document.getElementById("msg").innerText = message;
}

function loadHistory() {
  let history = JSON.parse(localStorage.getItem("locations")) || [];
  displayHistory(history);
}

function displayHistory(history) {
  let list = document.getElementById("history");
  list.innerHTML = "";

  history.forEach(function (item, index) {
    let li = document.createElement("li");
    li.innerText = `${index + 1}. Lat: ${item.lat}, Lon: ${item.lon} (${item.time})`;
    list.appendChild(li);
  });
}