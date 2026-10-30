using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    [SerializeField] private string nextLevel;

    private bool colliding;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract()
    {
        if (colliding) SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
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
