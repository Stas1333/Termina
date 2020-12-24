using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_6 : MonoBehaviour
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Robot.AddForce(Vector2.left * 120);
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
        var position = new Vector3(7.66f, -4.49f, 4.742f);
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
