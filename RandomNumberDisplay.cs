using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class RandomNumberDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText; // Ссылка на текстовый элемент
    [SerializeField] private ContainerSpawner containerSpawner; // Ссылка на спавнер контейнеров

    private void Awake()
    {
        displayText = GetComponentInChildren<TextMeshProUGUI>(); // Находим текст в дочерних объектах
    }

    private void Start()
    {
        StartCoroutine(UpdateDisplayWithDelay(0.5f)); // Запускаем корутину с задержкой 0.5 секунды
    }

    private IEnumerator UpdateDisplayWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Ждем указанное время

        UpdateDisplay(); // Обновляем отображение
    }

    public void UpdateDisplay()
    {
        List<int> generatedNumbers = containerSpawner.GetGeneratedNumbers(); // Получаем сгенерированные числа

        if (generatedNumbers.Count > 0)
        {
            int randomIndex = Random.Range(0, generatedNumbers.Count); // Генерируем случайный индекс
            int randomNumber = generatedNumbers[randomIndex]; // Получаем число по индексу
            displayText.text = "Выбери: " + randomNumber.ToString(); // Обновляем текст
        }
        else
        {
            displayText.text = "Нет доступных чисел"; // Если нет сгенерированных чисел
        }
    }
    public int GetCurrentNumber()
{
    List<int> generatedNumbers = containerSpawner.GetGeneratedNumbers();
    if (generatedNumbers.Count > 0)
    {
        int randomIndex = Random.Range(0, generatedNumbers.Count);
        return generatedNumbers[randomIndex]; // Возвращаем текущее число
    }
    return -1; // Если нет доступных чисел
}
}