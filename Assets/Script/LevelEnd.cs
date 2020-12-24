using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public InputField mainInputField;
    private string myCommands;
    public string myLevels;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            myCommands = mainInputField.text;
            if (myCommands == "Y" || myCommands == "y")
            {
                var currentLevel = SceneManager.GetActiveScene().name;
                var level = int.Parse(currentLevel.Substring(6))+1;
                if (level<=7) {
                    SceneManager.LoadScene("Level_" + level, LoadSceneMode.Single);
                }

            }
            else if (myCommands == "N" || myCommands == "n")
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single); 
            }
            else if (myCommands == "E" || myCommands == "e")
            {
                Application.Quit();
            }
            else
            {
                Debug.Log(myCommands + " is an Invalid Command!");
            }
            // Debug.Log(mainInputField.text);
            mainInputField.text = null;
        }
    }
}
