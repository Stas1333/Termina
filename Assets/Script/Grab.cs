using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Grab : EventTrigger {
    private bool dragging;
    private Camera cam;
    private Shadow myShadow;
    public float groundY;
    private bool gravity = true;
    public bool snapped;

    void Start()
    {
        myShadow = GetComponent<Shadow>();
        cam = Camera.main;
    }
    void OnGUI() {
        Event currentEvent = Event.current;
        if (dragging) {
            var my_mouse_y = cam.pixelHeight - currentEvent.mousePosition.y;
            var world_point = cam.ScreenToWorldPoint(new Vector3(currentEvent.mousePosition.x, my_mouse_y, cam.nearClipPlane+9.5f));
            transform.position = world_point;
        } else {
            if (transform.position.y >= groundY & gravity) {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            }
        }
    }

    public void Snap(Vector2 position)
    {
        transform.localPosition = position;
        dragging = false;
        gravity = false;
        snapped = true;
    }

    public void Unsnap()
    {
        gravity = true;
        snapped = false;
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;
        var grabShadow = new Vector2(-4, -4);
        myShadow.effectDistance = grabShadow;
        gravity = false;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        dragging = false;
        var noShadow = new Vector2(-2, -2);
        myShadow.effectDistance = noShadow;
        if (!snapped) {
            gravity = true;
        }
    }
}
