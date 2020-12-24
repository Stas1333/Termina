using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_7 : MonoBehaviour
{
    void Run(string[] MyThings) {
        SceneManager.LoadScene("End", LoadSceneMode.Single);
    }
}
