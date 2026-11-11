using UnityEngine;
using UnityEngine.InputSystem;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject playerManager;
    [SerializeField] private GameObject light;

    private bool colliding;

    void Start()
    {
        light.GetComponent<SpriteRenderer>().enabled = false;
        playerManager = GameObject.Find("Player Manager");
        colliding = false;
    }

    public void OnInteract()
    {
        if (!colliding) return;
        Debug.Log("yes");

        light.GetComponent<SpriteRenderer>().enabled = true;
        playerManager.GetComponent<PlayerManager>().NewCheckpoint(this.gameObject);
        playerManager.GetComponent<PlayerManager>().Respawn(this.gameObject.transform);
    }

    public void DeActivate()
    {
        light.GetComponent<SpriteRenderer>().enabled = false;
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
