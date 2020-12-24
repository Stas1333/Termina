using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderListener: MonoBehaviour
{
    public GameObject GameController;
    public string eventName;

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameController.SendMessage(eventName);
    }
}
