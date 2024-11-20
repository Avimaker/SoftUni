function calc() {
    const num1Element = document.getElementById('num1');
    const num2Element = document.getElementById('num2');
    const sumElement = document.getElementById('sum');

    const firstNum = Number(num1Element.value);
    const secondNum = Number(num2Element.value);

    sumElement.value = firstNum + secondNum;
}
