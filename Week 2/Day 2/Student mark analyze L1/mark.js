const marks = [65, 66, 56, 90, 75];

const numericMarks = marks.map(mark => Number(mark));

const calculateTotal = (arr) =>
    arr.reduce((sum, mark) => sum + mark, 0);

const calculateAverage = (arr) =>
    calculateTotal(arr) / arr.length;

const total = calculateTotal(numericMarks);
const average = calculateAverage(numericMarks);

const result = average >= 40 ? "Pass " : "Fail ";

const output = `
    <p>Marks: ${numericMarks.join(", ")}</p>
    <p>Total Marks: ${total}</p>
    <p>Average Marks: ${average.toFixed(2)}</p>
    <p>Result: ${result}</p>
`;

document.getElementById("output").innerHTML = output;