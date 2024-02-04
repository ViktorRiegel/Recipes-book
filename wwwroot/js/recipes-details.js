// Избиране на елементите от DOM
const stepsList = document.getElementById("steps-list");
const additionalCard = document.getElementById("additional-card");

// Прикрепяне на събитие на кликване върху стъпките
stepsList.addEventListener("click", function (event) {
    // Проверка дали кликнатият елемент е списъчен елемент
    if (event.target.tagName === "LI") {
        // Извличане на текста на кликнатия елемент
        const stepText = event.target.textContent;

        // Създаване на нов елемент за показване на стъпката
        const stepElement = document.createElement("p");
        stepElement.textContent = stepText;

        // Показване на стъпката в допълнителната карта
        additionalCard.innerHTML = "";
        additionalCard.appendChild(stepElement);

        // Показване на допълнителната карта
        additionalCard.style.display = "block";
    }
});
