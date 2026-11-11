using UnityEngine;

public class NewScene : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerManager = GameObject.Find("Player Manager");

        playerManager.GetComponent<PlayerManager>().spawnPoint = this.spawnPoint;
        playerManager.GetComponent<PlayerManager>().camera = this.camera;
        playerManager.GetComponent<PlayerManager>().NewScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
