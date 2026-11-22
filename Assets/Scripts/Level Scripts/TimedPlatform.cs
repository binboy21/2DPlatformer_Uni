using UnityEngine;

public class TimedPlatform : MonoBehaviour
{
    private float maxTime = 2f;
    private float timer;

    [SerializeField] private bool par;
    void Start()
    {
        if (par) timer = 1f;
        else timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= maxTime)
        {
            timer = 0f;
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
        }
        else timer += Time.deltaTime;
    }
}
