let db;

window.onload = function () {
  let request = indexedDB.open("ExpenseDB", 1);

  request.onupgradeneeded = function (e) {
    db = e.target.result;
    let store = db.createObjectStore("expenses", { keyPath: "id", autoIncrement: true });
    store.createIndex("title", "title", { unique: false });
  };

  request.onsuccess = function (e) {
    db = e.target.result;
    viewExpenses();
  };

  request.onerror = function () {
    document.getElementById("msg").innerText = "Database error!";
  };
};

function addExpense() {
  let title = document.getElementById("title").value;
  let amount = document.getElementById("amount").value;
  let date = document.getElementById("date").value;

  let tx = db.transaction(["expenses"], "readwrite");
  let store = tx.objectStore("expenses");

  let expense = { title, amount, date };
  let request = store.add(expense);

  request.onsuccess = function () {
    viewExpenses();
  };

  request.onerror = function () {
    document.getElementById("msg").innerText = "Insert failed!";
  };
}

function viewExpenses() {
  let tx = db.transaction(["expenses"], "readonly");
  let store = tx.objectStore("expenses");
  let request = store.getAll();

  request.onsuccess = function (e) {
    let list = document.getElementById("expenseList");
    list.innerHTML = "";

    e.target.result.forEach(item => {
      let row = `
        <tr>
          <td>${item.title}</td>
          <td>${item.amount}</td>
          <td>${item.date}</td>
          <td><button onclick="deleteExpense(${item.id})">Delete</button></td>
        </tr>`;
      list.innerHTML += row;
    });
  };

  request.onerror = function () {
    document.getElementById("msg").innerText = "Select failed!";
  };
}

function deleteExpense(id) {
  let tx = db.transaction(["expenses"], "readwrite");
  let store = tx.objectStore("expenses");

  let request = store.delete(id);

  request.onsuccess = function () {
    viewExpenses();
  };

  request.onerror = function () {
    document.getElementById("msg").innerText = "Delete failed!";
  };
}