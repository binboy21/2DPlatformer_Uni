using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EndLevelDoor : MonoBehaviour
{
    [SerializeField] private GameObject bar1, bar2, bar3;
    private int first = 500;
    private int second = 800;

    private int third = 1200;

    [SerializeField] private GameObject playerManager;

    int total;

    [SerializeField] private Color darkBlue;

    private bool colliding;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerManager pm = playerManager.GetComponent<PlayerManager>();

        total = pm.player1Object.GetComponent<PlayerScore>().score;
        if (pm.p2) total += pm.player2Object.GetComponent<PlayerScore>().score;

        if (total >= first) bar1.GetComponent<SpriteRenderer>().color = darkBlue;
        if (total >= second) bar2.GetComponent<SpriteRenderer>().color = darkBlue;
        if (total >= third) bar3.GetComponent<SpriteRenderer>().color = darkBlue;
    }

    public void OnInteract()
    {
        if (!colliding) return;

        if (total >= first)
        {
            SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player")) colliding = true;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player")) colliding = false;
    }
}
