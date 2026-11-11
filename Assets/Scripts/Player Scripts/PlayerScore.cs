using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Collectable"))
        {
            score += coll.gameObject.GetComponent<Collectable>().points;
            Destroy(coll.gameObject);
            Debug.Log(score);
        }
    }
}
