using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject player1, player2;

    private Transform player1pos;
    public GameObject player1Object;

    private bool p2;

    [SerializeField] private GameObject camera;

    public InputAction join;

    [SerializeField] private OrbBounce orbBounceMiniGame;

    void Start()
    {
        join = GetComponent<PlayerInput>().actions["Join"];

        p2 = false;
        var player = PlayerInput.Instantiate(player1, controlScheme: "PlayerInput", pairWithDevice: Keyboard.current);
        player.transform.position = spawnPoint.position;
        player.GetComponent<PlayerMovement>().playerManager = this;
        player1Object = player.gameObject;
        if (orbBounceMiniGame != null) player.GetComponent<PlayerMovement>().orbBounceMiniGame = orbBounceMiniGame;

        if (p2)
        {
            player = PlayerInput.Instantiate(player2, controlScheme: "Player2Input", pairWithDevice: Gamepad.current);
            player.transform.position = new Vector2(player1pos.position.x - 1, player1pos.position.y - 1);
            player.GetComponent<PlayerMovement>().playerManager = this;
            if (orbBounceMiniGame != null) player.GetComponent<PlayerMovement>().orbBounceMiniGame = orbBounceMiniGame;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        player1pos = player1Object.transform;

        if (join.triggered && !p2) Player2();

        if (camera != null) camera.transform.position = new Vector3(player1pos.position.x, camera.transform.position.y, -10);
    }

    public void Player2()
    {


        if (!p2)
        {
            p2 =  true;
            Debug.Log("yes");
            var player = PlayerInput.Instantiate(player2, controlScheme: "Player2Input", pairWithDevice: Gamepad.current);
            player.transform.position = new Vector2(player1pos.position.x - 1, player1pos.position.y + 1);
            player.GetComponent<PlayerMovement>().playerManager = this;
            if (orbBounceMiniGame != null) player.GetComponent<PlayerMovement>().orbBounceMiniGame = orbBounceMiniGame;

        }
    }

    public void NewScene()
    {
        Debug.Log("new scene");
        var player = PlayerInput.Instantiate(player1, controlScheme: "PlayerInput", pairWithDevice: Keyboard.current);
        player.transform.position = spawnPoint.position;
        player.GetComponent<PlayerMovement>().playerManager = this;
        player1Object = player.gameObject;
        if (orbBounceMiniGame != null) player.GetComponent<PlayerMovement>().orbBounceMiniGame = orbBounceMiniGame;

        if (p2)
        {
            player = PlayerInput.Instantiate(player2, controlScheme: "Player2Input", pairWithDevice: Gamepad.current);
            player.transform.position = new Vector2(player1pos.position.x - 1, player1pos.position.y - 1);
            player.GetComponent<PlayerMovement>().playerManager = this;
            if (orbBounceMiniGame != null) player.GetComponent<PlayerMovement>().orbBounceMiniGame = orbBounceMiniGame;
        }
    }

}
