using UnityEngine;

public class ClickableNumber : MonoBehaviour
{
    private int number; // Хранит число, связанное с этим префабом
    private RandomNumberDisplay randomNumberDisplay; // Ссылка на RandomNumberDisplay

    // Метод для инициализации числа и ссылки на RandomNumberDisplay
    public void Initialize(int number, RandomNumberDisplay display)
    {
        this.number = number; // Устанавливаем число
        this.randomNumberDisplay = display; // Сохраняем ссылку на RandomNumberDisplay
    }

    private void OnMouseDown()
    {
        // Логируем, на какое число кликнули
        Debug.Log("Кликнули на число: " + number);

        // Проверяем, совпадает ли число с выбранным
        if (number == randomNumberDisplay.GetCurrentNumber())
        {
            Debug.Log("Правильный выбор! Удаляем все префабы.");
            DestroyAllPrefabs(); // Удаляем все префабы
        }
        else
        {
            Debug.Log("Неправильный выбор. Выбрано число: " + number);
        }
    }

    private void DestroyAllPrefabs()
    {
        // Получаем все префабы в сцене и удаляем их
        ClickableNumber[] allNumbers = FindObjectsOfType<ClickableNumber>();
        foreach (var clickable in allNumbers)
        {
            Destroy(clickable.gameObject);
        }
    }
}