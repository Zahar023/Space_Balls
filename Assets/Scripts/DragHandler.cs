using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class DragHandler : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("DRAG");
        Vector3 posX = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(posX.x,transform.position.y,transform.position.z);
    }
}