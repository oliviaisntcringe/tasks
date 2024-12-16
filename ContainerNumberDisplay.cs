using UnityEngine;
using TMPro;

public class ContainerNumberDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberText; // UI элемент для отображения числа

    private void Awake()
    {
        if (numberText == null)
        {
            numberText = GetComponentInChildren<TextMeshProUGUI>(); // Найти текст в дочерних объектах
        }
    }

    // Метод для установки числа
    public void SetNumber(int number)
    {
        if (numberText != null)
        {
            numberText.text = number.ToString(); // Устанавливаем текст в UI элемент
        }
        else
        {
            Debug.LogError("Number Text is not assigned!");
        }
    }

    // Метод для получения числа
    public int GetNumber()
    {
        return int.Parse(numberText.text); // Возвращаем текущее число
    }

    private void Start()
    {
        // Инициализация префаба
        ClickableNumber clickable = GetComponent<ClickableNumber>();
        if (clickable != null)
        {
            RandomNumberDisplay display = FindObjectOfType<RandomNumberDisplay>();
            clickable.Initialize(GetNumber(), display); // Передаем текущее число и ссылку на RandomNumberDisplay
        }
    }
}