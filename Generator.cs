using System.Collections.Generic;
using UnityEngine;

public class Generator
{
    private HashSet<int> generatedNumbers = new HashSet<int>(); // Хранит уникальные числа
    private int minValue = 1; // Минимальное значение
    private int maxValue = 10; // Максимальное значение

    public int GenerateRandomNumber()
    {
        int randomNumber;

        // Генерируем уникальное число
        do
        {
            randomNumber = Random.Range(minValue, maxValue + 1); // Генерация случайного числа
        } while (generatedNumbers.Contains(randomNumber)); // Проверка на уникальность

        generatedNumbers.Add(randomNumber); // Добавляем число в коллекцию

        return randomNumber; // Возвращаем уникальное число
    }

    public List<int> GetGeneratedNumbers()
    {
        return new List<int>(generatedNumbers); // Возвращаем список сгенерированных чисел
    }
}