using UnityEngine;
using System.Collections.Generic;

public class ContainerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject containerPrefab; // Префаб контейнера
    [SerializeField] private float spacing = 2.0f; // Расстояние между контейнерами
    private Generator generator; // Экземпляр генератора
    private List<ContainerNumberDisplay> containerDisplays = new List<ContainerNumberDisplay>(); // Список контейнеров

    private void Awake()
    {
        generator = new Generator(); // Создаем новый экземпляр Generator
    }

    public void SpawnContainers(int count)
    {
        // Проверка на null для префаба
        if (containerPrefab == null)
        {
            Debug.LogError("Container Prefab is not assigned in the inspector!");
            return;
        }

        // Определяем центральную позицию по Y
        float centerY = 0f; // Задай нужное значение по Y

        for (int i = 0; i < count; i++)
        {
            int randomNumber = generator.GenerateRandomNumber(); // Генерируем случайное число

            // Вычисляем позицию по X без центрирования
            float posX = i * spacing; // Расстояние между контейнерами по оси X

            // Создаем контейнер в заданной позиции
            Vector3 spawnPosition = new Vector3(posX, centerY, 0f); // Позиция спавна
            GameObject container = Instantiate(containerPrefab, spawnPosition, Quaternion.identity);

            // Получаем компонент ContainerNumberDisplay и устанавливаем число
            ContainerNumberDisplay display = container.GetComponent<ContainerNumberDisplay>();
            if (display != null)
            {
                display.SetNumber(randomNumber); // Устанавливаем число в контейнер
                containerDisplays.Add(display); // Сохраняем ссылку на контейнер
            }
            else
            {
                Debug.LogError("ContainerNumberDisplay component is missing on the container prefab!");
            }
        }
    }

public List<int> GetGeneratedNumbers()
{
    List<int> numbers = new List<int>();
    foreach (var display in containerDisplays)
    {
        numbers.Add(display.GetNumber()); // Получаем число из каждого контейнера
    }
    Debug.Log("Сгенерированные числа: " + string.Join(", ", numbers)); // Отладочное сообщение
    return numbers;
}
}