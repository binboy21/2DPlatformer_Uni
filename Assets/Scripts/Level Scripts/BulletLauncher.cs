using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private bool reversed, random;

    [SerializeField] private float maxTime = 3f;
    private float time;
    void Start()
    {
        if (random) time = Random.Range(7, 12);
        else time = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            GameObject current = Instantiate(bullet, transform.position, transform.rotation);
            current.GetComponent<Bullet>().reversed = reversed;

            if (random) maxTime = Random.Range(7, 12);

            time = maxTime;
        }
        else time -= Time.deltaTime;
    }
}
