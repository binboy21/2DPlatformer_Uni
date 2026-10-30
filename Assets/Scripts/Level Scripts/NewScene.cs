using UnityEngine;

public class NewScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerManager = GameObject.Find("Player Manager");

        playerManager.GetComponent<PlayerManager>().NewScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
