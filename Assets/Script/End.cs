using UnityEngine;

public class End : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKey) {
            Application.Quit();
        }
    }
}
