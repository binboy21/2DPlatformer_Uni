using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool reversed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reversed) transform.position = new Vector2(transform.position.x - 2 * Time.deltaTime, transform.position.y);
        else transform.position = new Vector2(transform.position.x + 2 * Time.deltaTime, transform.position.y);
    }
}
