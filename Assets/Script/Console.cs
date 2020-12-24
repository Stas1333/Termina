using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Console : MonoBehaviour
{
    public InputField mainInputField;
    public Text myLog;
    private string myCommands;
    private string level; 

    private void Start() {
        mainInputField.Select();
        mainInputField.ActivateInputField();
        myLog.text = "NA-DOS 1973\nALL RIGHTS RESERVED\nWARNING: TIRMINO = 0!!\n\nTYPE HELP AND PRESS ENTER FOR THE LIST OF COMMANDS\n";
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            myCommands = mainInputField.text;
            if (myCommands == "HELP" || myCommands == "help") {
                Debug.Log("HELP ME. PLEASE!!");
                myLog.text = "\n" + "ALL COMMANDS:\n\tHELP - this menu\n\tRUN Level_1 - start the programm\n\tABOUT - important information about the programm\n\tEXIT - exit programm";
            } else if (myCommands.Contains("run ") || myCommands.Contains("RUN ")) {
                level = myCommands.Substring(4);
                Debug.Log("Running " + level + "...");
                if (level == "Level_1" || level == "Level_2" || level == "Level_3" || level == "Level_4" || level == "Level_5" || level == "Level_6") {
                    SceneManager.LoadScene(level, LoadSceneMode.Single);
                } else {
                    myLog.text = "\nERROR: PROGRAMM " + level + " NOT FOUND!!!" + "\nVALID PROGRAMMS TO RUN\n\tLevel_1\n\tLevel_2\n\tLevel_3\n\tLevel_4\n\tLevel_5\n\tLevel_6";
                }
            } 
            // else if (myCommands == "SETTINGS" || myCommands == "settings") {
            //     Debug.Log("Dem is setting up your PC...");
            // } 
            else if (myCommands == "about" || myCommands == "ABOUT") {
                Debug.Log("Boring about info, something about story, and credits...");
                myLog.text = "\n" + "ABOUT:\n\tThank you for being intrested in this project!\n\tThis is the submittion to GitHub GameOff 2020\n\tIf you liked this game rate it on itch.io please...\n\tYou are a game developer at the limbo becouse of your unfinished projects. You need to finish all of them to set your soul free...";
            } else if (myCommands == "EXIT" || myCommands == "exit") {
                Application.Quit();
            }
            else {
                Debug.Log(myCommands + " Invalid Command!");
                myLog.text = "\nCOMMAND "+ myCommands + " IS INVALID!!!";
            }
            mainInputField.text = null;
        }
    }
}
