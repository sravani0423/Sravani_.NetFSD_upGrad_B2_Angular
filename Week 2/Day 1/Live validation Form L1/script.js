function validateName() {
    let name = document.getElementById("name").value;
    let msg = document.getElementById("nameMsg");

    if (name === "") {
        msg.innerText = "Name cannot be empty";
        return false;
    } else {
        msg.innerText = "";
        return true;
    }
}

function validateEmail() {
    let email = document.getElementById("email").value;
    let msg = document.getElementById("emailMsg");

    if (!email.includes("@")) {
        msg.innerText = "Email must contain @";
        return false;
    } else {
        msg.innerText = "";
        return true;
    }
}

function validateAge() {
    let age = document.getElementById("age").value;
    let msg = document.getElementById("ageMsg");

    if (age <= 18) {
        msg.innerText = "Age must be greater than 18";
        return false;
    } else {
        msg.innerText = "";
        return true;
    }
}

function submitForm() {
    let isNameValid = validateName();
    let isEmailValid = validateEmail();
    let isAgeValid = validateAge();

    if (isNameValid && isEmailValid && isAgeValid) {
        sessionStorage.setItem("name", document.getElementById("name").value);
        sessionStorage.setItem("email", document.getElementById("email").value);
        sessionStorage.setItem("age", document.getElementById("age").value);

        document.getElementById("finalMsg").innerText = "Data saved in Session Storage!";
        document.getElementById("finalMsg").className = "success";
    } else {
        document.getElementById("finalMsg").innerText = "Please fix validation errors!";
        document.getElementById("finalMsg").className = "error";
    }
}