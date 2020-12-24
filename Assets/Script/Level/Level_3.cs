using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_3 : MonoBehaviour
{
    public Rigidbody2D Robot;
    public Run runButton;
    public GameObject Flag;
    private Camera uiCamera;
    private Camera gameCamera;
    private bool running = false;
    public string[] allBlocks;
    private bool stop = false;

    public void Start()
    {
        uiCamera = runButton.uiCamera;
        gameCamera = runButton.gameCamera;
    }
    public void LateUpdate()
    {
        if (allBlocks[2]=="STOP") {
        if (running & !stop)
            {
                Robot.AddForce(Vector2.left * 18);
            }
        } else {
            if (running) {
                Robot.AddForce(Vector2.left * 18);
            }
        }
        }
    public void Jump()
    {
        Robot.AddForce(Vector2.left * 30);
    }
    public void Finish()
    {
        if (running)
        {
            SceneManager.LoadScene("Level_end", LoadSceneMode.Additive);
            running = false;
        }
    }
    public void Run(string[] myBlocks)
    {
        Restart();
        allBlocks = myBlocks;
        // if (myBlocks[0] == "FLIP" & myBlocks[1] != "null" & myBlocks[2] == "WALK")
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
        var position = new Vector3(5.8f, -4.45f, 4.742f);
        Robot.transform.position = position - mistake;
    }
}
