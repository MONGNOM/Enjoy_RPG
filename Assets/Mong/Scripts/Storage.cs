using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Storage : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public void StorageOpen()
    { 
        gameObject.SetActive(true);
    }

    public void StorageClose()
    {
        gameObject.SetActive(false);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
