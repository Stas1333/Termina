using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    public GameObject[] myInsert;
    private Insert myObject;
    public string[] myBlocks;
    public InputField[] myInputs;
    public string[] myValues;
    public string[] myThings;
    public GameObject myGameController;
    public Camera uiCamera;
    public Camera gameCamera;
    private Button myRunButton;
    private bool incomplete = true;

    public void Start()
    {
        myRunButton = GetComponent<Button>();
        myRunButton.onClick.AddListener(myRun);
    }

    public void Update() {
        for (var i = 0; i < myInputs.Length; i++) {
            myValues[i] = myInputs[i].text;
        }
        for (var i = 0; i < myInsert.Length; i++)
        {
            myObject = myInsert[i].GetComponent<Insert>();
            if (myObject.hasBlock) {
                myBlocks[i] = myObject.block.name;
            } else {
                myBlocks[i] = null;
            }
        }

        incomplete = false;
        for(var i = 0; i < myBlocks.Length; i++) {
            if (myBlocks[i] == null)
            {
                incomplete = true;
                break;
            }
        }

        if (incomplete) {
            myRunButton.interactable = false;
        } else {
            myRunButton.interactable = true;
        }
    }

    public void myRun()
    {
        uiCamera.enabled = false;
        gameCamera.enabled = true;
        for (var i=0; i < myThings.Length; i++) {
            if (i < myBlocks.Length) {
                myThings[i] = myBlocks[i];
            }
            else {
                myThings[i] = myValues[-(myBlocks.Length-i)];
            }
            Debug.Log("Array is: " + myThings[i]);
        }
        myGameController.SendMessage("Run", myThings);
    }
}