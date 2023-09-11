using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StorageItem : MonoBehaviour , IBeginDragHandler , IEndDragHandler , IDragHandler, IPointerClickHandler
{
    [SerializeField]
    private Image itemPrefabs;

    [HideInInspector]
    public Item item;

    [HideInInspector]
    public Vector2 defaultPos;

    [HideInInspector]
    public Transform parentAfterDrag;

    //�����ۿ� ���� ������ ������ ��
    public void addItem(Item item)
    {
        itemPrefabs.sprite = item.image;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = this.gameObject.transform.position;
        parentAfterDrag = this.gameObject.transform.parent;
        itemPrefabs.raycastTarget = false;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemPrefabs.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        gameObject.transform.position = parentAfterDrag.position;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        StorageSlot slot = transform.GetComponentInParent<StorageSlot>();
        // ���� �����ǿ� ��ġ�� ������ retrun
        if (!slot)
        {
            Debug.Log("�����ȉ�");
            return;
        }
        else
        {
            StorageManager.Instance.RemoveItem(this);
            Destroy(gameObject);
        }
    }

}
