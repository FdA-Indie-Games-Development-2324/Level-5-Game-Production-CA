using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    /// <summary>
    /// This goes directly on the fishers
    /// </summary>

    bool isDragging;

    public void OnMouseDown(){
        isDragging = true;
    }

    public void OnMouseUp(){
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDragging){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }
    }
}
