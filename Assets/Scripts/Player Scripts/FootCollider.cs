using UnityEngine;
using UnityEngine.SceneManagement;

public class FootCollider : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public bool bounce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Floor"))
        {
            player.GetComponent<PlayerMovement>().isGrounded = true;
        }
        if (coll.gameObject.CompareTag("Trap")) Die();
        if (coll.gameObject.CompareTag("Enemy")) Kill(coll.gameObject);
        if (coll.gameObject.CompareTag("Bullet")) Kill(coll.gameObject);
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Floor"))
        {
            player.GetComponent<PlayerMovement>().isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Floor"))
        {
            player.GetComponent<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Floor"))
        {
            player.GetComponent<PlayerMovement>().isGrounded = false;
        }
    }

    private void Kill(GameObject enemy)
    {
        bounce = true;
        player.GetComponent<PlayerMovement>().Bounce();
        Destroy(enemy);
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
