var counter = 0;

function updateDisplay() {
    document.getElementById("counterValue").innerHTML = counter;
}
function incrementCounter(step) {
    counter = counter + step;
    updateDisplay();
}
function resetCounter() {
    counter = 0;
    updateDisplay();
}
document.getElementById("incrementBtn").addEventListener("click", function () {
    incrementCounter(1);
});
document.getElementById("resetBtn").addEventListener("click", function () {
    resetCounter();
});