using UnityEngine;

public class Bird : MonoBehaviour
{
    public Animator animator;
    public string currentSkinId;
    public float force;
    public Rigidbody2D _birdRigid;
    public GameObject restartButton;
    public GameManager gameManager;

    void Start()
    {
        currentSkinId = SaveManager.Instance.GetData().skin;
        animator.SetBool(currentSkinId, true);
        _birdRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameManager.IsGameStarted)
        {
            _birdRigid.simulated = true;
            if (Input.GetMouseButtonDown(0))
                _birdRigid.velocity = Vector2.up * force;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            gameManager.isLose = true;
            SaveManager.Instance.SetScore(GetComponent<Score>().score);
            gameManager.SetGameState();
            gameObject.SetActive(false);
        }
    }

}
