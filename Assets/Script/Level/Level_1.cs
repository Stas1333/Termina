using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_1 : MonoBehaviour
{
    public Rigidbody2D Robot;
    public Run runButton;
    public GameObject Flag;
    private Camera uiCamera;
    private Camera gameCamera;
    private bool running;

    public void Finish()
    {
        if (running) {
            SceneManager.LoadScene("Level_end", LoadSceneMode.Additive);
            running = false;
        }
    }
    public void Start()
    {
        uiCamera = runButton.uiCamera;
        gameCamera = runButton.gameCamera;
    }
    void Restart()
    {
        var mistake = new Vector3(29.20646f, -4.221726f, 5.300913f);
        var position = new Vector3(0.1f, -4.45f, 4.742f);
        Robot.transform.position = position - mistake;
    }
    void Run() {
        running = true;
        Restart();
        Finish();
    }
    void Stop()
    {
        uiCamera.enabled = true;
        gameCamera.enabled = false;
        running = false;
    }
}
