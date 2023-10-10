using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PipeSpawner pipeSpawner;

    [field: SerializeField] public bool IsGameStarted { get; set; } = false;
    
    [field: SerializeField] public UIManager UIManager { get; set; }

    [field: SerializeField] public bool isLose { get; set; } = false;
    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (!IsGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsGameStarted = true;
                pipeSpawner.StartSpawner();
            }
        }
    }

    public void SetGameState()
    {
        //isLose = !isLose;
        if (isLose)
        {
            UIManager.menuPanel.SetActive(true);
            UIManager.SetScoreText();
            UIManager.gameScoreText.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            IsGameStarted = false;
            Time.timeScale = 1;
        }
    }
}