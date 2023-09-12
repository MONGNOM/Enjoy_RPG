using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditorInternal.ReorderableList;

public class EquipMentWindow : MonoBehaviour, IBeginDragHandler, IEndDragHandler ,IDragHandler
{
    public static Vector2 defaultPos;


    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = this.transform.position;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        defaultPos = mousePos;
    }

}
