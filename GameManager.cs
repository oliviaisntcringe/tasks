using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ContainerSpawner containerSpawner; // Ссылка на спавнер контейнеров

    private void Start()
    {
        containerSpawner.SpawnContainers(3); // Спавним 3 контейнера
    }
}