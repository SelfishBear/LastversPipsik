using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    //��� ���� ������ �����
    public GameObject pipePrefab;
    //��� ���������� ����, ������� ����� � �����
    public int poolSize = 4;
    //�������� � ������� ����� ��������� �����
    public float spawnInterval = 2f;
    //����������� ������ �� ������� ����� ��������� �����
    public float minY = -2f;
    //������������ ������ �� ������� ����� ��������� �����
    public float maxY = 4f;

    //��� ����� ������ ����� ����
    private List<GameObject> pipePool = new List<GameObject>();
    //��� ���������� ����� ��� ���� ��� �� �������� ������ ��������� ����� �� ������
    private int currentPipeIndex = 0;

    void Start()
    {
        // � ���� ����� �� �������� ��� �����, ��������� �� � ���������� � ����
        for (int i = 0; i < poolSize; i++)
        {
            GameObject pipe = Instantiate(pipePrefab, Vector3.zero, Quaternion.identity);
            pipe.SetActive(false);
            pipePool.Add(pipe);
        }

        
        
    }

    public void StartSpawner()
    {
        // ��������� �������
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // �������� ��������� ������ �� ����
            GameObject newPipe = pipePool[currentPipeIndex];
            currentPipeIndex = (currentPipeIndex + 1) % poolSize;

            // ���������� ��������� ������ ��� �������
            float randY = Random.Range(minY, maxY);

            // ���������� � ���������� ������
            newPipe.SetActive(true);
            newPipe.transform.position = new Vector3(2, randY, 0);

            // ��������� ������ ����� ���������� �������
            StartCoroutine(DeactivatePipe(newPipe));
        }
    }

    IEnumerator DeactivatePipe(GameObject pipe)
    {
        yield return new WaitForSeconds(7); // �����, ����� ������� ������ ����� �������������
        pipe.SetActive(false);
    }
}
