using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_5 : MonoBehaviour
{
    public Rigidbody2D Robot;
    private bool running;
    public Run runButton;
    public GameObject Flag;
    private Camera uiCamera;
    private Camera gameCamera;
    private string[] things;

    public void Start()
    {
        uiCamera = runButton.uiCamera;
        gameCamera = runButton.gameCamera;
    }
    // Update is called once per frame
    void Update()
    {
        if (running) {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (things[2]=="WALK_RIGHT") {
                    Robot.AddForce(Vector2.right * 18);
                } else {
                    Robot.AddForce(Vector2.left * 18);
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (things[4] == "WALK_LEFT")
                {
                    Robot.AddForce(Vector2.left * 18);
                } else {
                    Robot.AddForce(Vector2.right * 18);
                }
            }
        }
    }
    void Run(string[] MyThings) {
        things = MyThings;
        Restart();
        running = true;
    }
    void Restart() {
        var mistake = new Vector3(29.20646f, -4.221726f, 5.300913f);
        var position = new Vector3(0.1f, -4.45f, 4.742f);
        Robot.transform.position = position - mistake;
    }
    void Stop() {
        uiCamera.enabled = true;
        gameCamera.enabled = false;
        running = false;
    }
    public void Finish()
    {
        SceneManager.LoadScene("Level_end", LoadSceneMode.Additive);
        running = false;
    }
}
