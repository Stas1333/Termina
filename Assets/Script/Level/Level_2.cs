using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_2 : MonoBehaviour
{
    public Rigidbody2D Robot;
    public Run runButton;
    public GameObject Flag;
    private Camera uiCamera;
    private Camera gameCamera;
    private bool running = false;
    private string RobotDiraction;

    public void Start()
    {
        uiCamera = runButton.uiCamera;
        gameCamera = runButton.gameCamera;
    }
    public void LateUpdate()
    {
        if (running) {
            if (RobotDiraction == "left") {
                Robot.AddForce(Vector2.left * 18);
            } else if (RobotDiraction == "right") {
                Robot.AddForce(Vector2.right * 18);
            }
        }
    }
    public void Wall() {
        RobotDiraction = "left";
    }
    public void Finish()
    {
        if (running) {
            SceneManager.LoadScene("Level_end", LoadSceneMode.Additive);
            running = false;
        }
    }
    public void Run(string[] myBlocks)
    {
        Restart();
        if (myBlocks[0] == "WALK" & myBlocks[1] != "null" & myBlocks[2] == "FLIP") {
            Debug.Log("Right");
            Robot.AddForce(Vector2.right * 18);
        }
        if (myBlocks[0] == "FLIP" & myBlocks[1] != "null" & myBlocks[2] == "WALK")
        {
            // while (running) {
            //     RobotDiraction = "left";
            //     RobotDiraction = "right";
            // }
        }

        running = true;
    }
    public void Stop()
    {
        uiCamera.enabled = true;
        gameCamera.enabled = false;
        running = false;
    }
    public void Restart()
    {
        var mistake = new Vector3(29.20646f, -4.221726f, 5.300913f);
        var position = new Vector3(0.1f, -4.45f, 4.742f);
        Robot.transform.position = position-mistake;
        RobotDiraction = "right";
    }
}
