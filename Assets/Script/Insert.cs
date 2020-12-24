using UnityEngine;
using UnityEngine.UI;

public class Insert : MonoBehaviour
{
    private Outline outline;
    public Vector2 position;
    public bool hasBlock;
    public GameObject block;
    public string blockType;

    public void Start()
    {
        outline = GetComponent<Outline>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == blockType & !hasBlock) {
            block = collision.gameObject;
            block.SendMessage("Snap", position); 
            hasBlock = true;
            outline.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (hasBlock) {
            hasBlock = false;
            block.SendMessage("Unsnap");
            block = null;
            outline.enabled = true;
        }
    }
}
