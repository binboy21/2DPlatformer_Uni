using UnityEngine;

public class TrapFollow : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) Destroy(this.gameObject);
        else transform.position = enemy.transform.position;
    }
}
