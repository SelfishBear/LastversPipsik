using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    //Это твой префаб трубы
    public GameObject pipePrefab;
    //Это количество труб, которые будут в пулле
    public int poolSize = 4;
    //Интервал с которым будут спаниться трубы
    public float spawnInterval = 2f;
    //Минимальная высота на которой будет спаниться труба
    public float minY = -2f;
    //Максимальная высота на которой будет спаниться труба
    public float maxY = 4f;

    //Тут лежит список твоих труб
    private List<GameObject> pipePool = new List<GameObject>();
    //Эта переменная нужна для того что бы получить именно следующую трубу из списка
    private int currentPipeIndex = 0;

    void Start()
    {
        // В этом цикле ты создаешь все трубы, скрываешь их и добавляешь в лист
        for (int i = 0; i < poolSize; i++)
        {
            GameObject pipe = Instantiate(pipePrefab, Vector3.zero, Quaternion.identity);
            pipe.SetActive(false);
            pipePool.Add(pipe);
        }

        
        
    }

    public void StartSpawner()
    {
        // Запускаем спавнер
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Получаем следующий объект из пула
            GameObject newPipe = pipePool[currentPipeIndex];
            currentPipeIndex = (currentPipeIndex + 1) % poolSize;

            // Генерируем случайную высоту для объекта
            float randY = Random.Range(minY, maxY);

            // Перемещаем и активируем объект
            newPipe.SetActive(true);
            newPipe.transform.position = new Vector3(2, randY, 0);

            // Отключаем объект после некоторого времени
            StartCoroutine(DeactivatePipe(newPipe));
        }
    }

    IEnumerator DeactivatePipe(GameObject pipe)
    {
        yield return new WaitForSeconds(7); // Время, через которое объект будет деактивирован
        pipe.SetActive(false);
    }
}
