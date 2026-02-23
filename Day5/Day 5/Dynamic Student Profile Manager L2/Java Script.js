var student = {
    name: "Megha",
    rollNo: 466,
    marks: 86
};

function updateStudentProfile(studentObj) {
    var profileDiv = document.getElementById("profileCard");

    profileDiv.innerHTML =
        "<h3>Student Profile</h3>" +
        "<p>Name: " + studentObj.name + "</p>" +
        "<p>Roll No: " + studentObj.rollNo + "</p>" +
        "<p>Marks: " + studentObj.marks + "</p>";
}

function updateMarks(newMarks) {
    student.marks = newMarks;   
    updateStudentProfile(student);  
}

updateStudentProfile(student);

document.getElementById("updateBtn").addEventListener("click", function () {
    var newMarksValue = document.getElementById("marksInput").value;
    updateMarks(newMarksValue);
});