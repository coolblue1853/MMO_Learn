using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class UI_EventHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerClickHandler
{
    // �̺�Ʈ �ý����� �޾ �ݹ����� ������
    public Action<PointerEventData> onBeginHandler = null;
    public Action<PointerEventData> onDragHandler = null;
    public Action<PointerEventData> onClickHandler = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (onBeginHandler != null)
            onBeginHandler.Invoke(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (onDragHandler != null)
            onDragHandler.Invoke(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (onClickHandler != null)
            onClickHandler.Invoke(eventData);
    }
}
