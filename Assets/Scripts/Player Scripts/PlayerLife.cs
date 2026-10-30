using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] private GameObject footColl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        
        if (coll.gameObject.CompareTag("Enemy"))
        {
            if (GetComponent<PlayerMovement>().dashing) Kill(coll.gameObject);
            else if (footColl.GetComponent<FootCollider>().bounce) footColl.GetComponent<FootCollider>().bounce = false;
            else Die();
        }
        if(coll.gameObject.CompareTag("Bullet"))
        {
            if (footColl.GetComponent<FootCollider>().bounce) footColl.GetComponent<FootCollider>().bounce = false;
            else Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    private void Kill(GameObject enemy)
    {
        Destroy(enemy);
    }

}
