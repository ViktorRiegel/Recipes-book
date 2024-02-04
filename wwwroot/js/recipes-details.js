// �������� �� ���������� �� DOM
const stepsList = document.getElementById("steps-list");
const additionalCard = document.getElementById("additional-card");

// ���������� �� ������� �� �������� ����� ��������
stepsList.addEventListener("click", function (event) {
    // �������� ���� ���������� ������� � �������� �������
    if (event.target.tagName === "LI") {
        // ��������� �� ������ �� ��������� �������
        const stepText = event.target.textContent;

        // ��������� �� ��� ������� �� ��������� �� ��������
        const stepElement = document.createElement("p");
        stepElement.textContent = stepText;

        // ��������� �� �������� � �������������� �����
        additionalCard.innerHTML = "";
        additionalCard.appendChild(stepElement);

        // ��������� �� �������������� �����
        additionalCard.style.display = "block";
    }
});
