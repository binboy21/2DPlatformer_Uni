using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public Transform spawnPoint;

    [SerializeField] private GameObject player1, player2;

    private Transform player1pos, player2pos;
    public GameObject player1Object, player2Object;

    public bool p2;

    [SerializeField] public GameObject camera;

    public InputAction join;

    [SerializeField] private OrbBounce orbBounceMiniGame;

    // Player Score

    [SerializeField] private TMP_Text player1Score, player2Score;

    //Player Checkpoints and Death

    public Transform lastCheckpoint;

    private bool p1Dead, p2Dead;

    void Start()
    {
        if (GameObject.Find("Player Manager (1)") != null) Destroy(this.gameObject);

        join = GetComponent<PlayerInput>().actions["Join"];

        p2 = false;
        var player = PlayerInput.Instantiate(player1, controlScheme: "PlayerInput", pairWithDevice: Keyboard.current);
        player.transform.position = spawnPoint.position;
        player.GetComponent<PlayerMovement>().playerManager = this;
        player1Object = player.gameObject;
        if (orbBounceMiniGame != null) player.GetComponent<PlayerMovement>().orbBounceMiniGame = orbBounceMiniGame;

        if (p2) Player2();
        else player2Object = null;

        DontDestroyOnLoad(this.gameObject);

        lastCheckpoint = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player1Object.GetComponent<SpriteRenderer>().enabled) p1Dead = true;
        if (p2) if (!player2Object.GetComponent<SpriteRenderer>().enabled) p2Dead = true;

        player1pos = player1Object.transform;
        if (player2Object != null) player2pos = player2Object.transform;
        else p2Dead = true;

        if (join.triggered && !p2) Player2();

        if (camera != null)
        {
            if (!p1Dead) camera.transform.position = new Vector3(player1pos.position.x, player1pos.position.y + 3, -10);
            else if (!p2Dead) camera.transform.position = new Vector3(player2pos.position.x, player2pos.position.y + 3, -10);
            else ToCheckpoint();
        }

            player1Score.text = player1Object.GetComponent<PlayerScore>().score.ToString();

        if (p2) player2Score.text = player2Object.GetComponent<PlayerScore>().score.ToString();
        else player2Score.text = "";

        if (p1Dead && p2Dead) ToCheckpoint();
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
            player2Object = player.gameObject;
            if (orbBounceMiniGame != null) player.GetComponent<PlayerMovement>().orbBounceMiniGame = orbBounceMiniGame;

        }
    }

    public void NewScene()
    {
        lastCheckpoint = null;
        Debug.Log("new scene");
        var player = PlayerInput.Instantiate(player1, controlScheme: "PlayerInput", pairWithDevice: Keyboard.current);
        player.transform.position = spawnPoint.position;
        player.GetComponent<PlayerMovement>().playerManager = this;
        player1Object = player.gameObject;
        if (orbBounceMiniGame != null) player.GetComponent<PlayerMovement>().orbBounceMiniGame = orbBounceMiniGame;
        player1Object.GetComponent<PlayerScore>().score = 0;

        if (p2)
        {
            Player2();
            player2Object.GetComponent<PlayerScore>().score = 0;
        }
    }

    private void ToCheckpoint()
    {
        if (lastCheckpoint != null) player1Object.transform.position = lastCheckpoint.position;
        else player1Object.transform.position = spawnPoint.position;
        player1pos = player1Object.transform;

        player1Object.GetComponent<SpriteRenderer>().enabled = true;
        player1Object.GetComponent<BoxCollider2D>().enabled = true;

        p1Dead = false;

        if (p2)
        {
            player2Object.transform.position = new Vector2(player1pos.position.x - 1, player1pos.position.y - 1);
            player2Object.GetComponent<SpriteRenderer>().enabled = true;
            player2Object.GetComponent<BoxCollider2D>().enabled = true;
            p2Dead = false;
        }
    }

    public void Respawn(Transform checkpoint)
    {
        if (p1Dead)
        {
            player1Object.transform.position = checkpoint.position;
            player1pos = player1Object.transform;

            player1Object.GetComponent<SpriteRenderer>().enabled = true;
            player1Object.GetComponent<BoxCollider2D>().enabled = true;

            p1Dead = false;
        }
        else if (p2Dead && p2)
        {
            player2Object.transform.position = checkpoint.position;
            player2Object.GetComponent<SpriteRenderer>().enabled = true;
            player2Object.GetComponent<BoxCollider2D>().enabled = true;
            p2Dead = false;
        }
    }

    public void NewCheckpoint(GameObject newCheckpoint)
    {
        Debug.Log("seee");
        if (lastCheckpoint != null) lastCheckpoint.gameObject.GetComponent<Checkpoint>().DeActivate();
        lastCheckpoint = newCheckpoint.transform;
    }

}
