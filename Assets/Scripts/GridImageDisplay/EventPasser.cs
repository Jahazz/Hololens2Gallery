using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventPasser : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler
{
    [field: SerializeField]
    private bool SendOnBeginDrag { get; set; }
    [field: SerializeField]
    private bool SendOnDrop { get; set; }
    [field: SerializeField]
    private bool SendOnDrag { get; set; }

    private GameObject TargetGameObject { get; set; }

    public void Initialzie (GameObject target)
    {
        TargetGameObject = target;
    }

    public virtual void OnBeginDrag (PointerEventData eventData)
    {
        if (SendOnBeginDrag == true)
        {
            TargetGameObject.SendMessage("OnBeginDrag", eventData);
        }
    }

    public virtual void OnDrop (PointerEventData eventData)
    {
        if (SendOnDrop == true)
        {
            TargetGameObject.SendMessage("OnDrop", eventData);
        }
    }

    public virtual void OnDrag (PointerEventData eventData)
    {
        if (SendOnDrag == true)
        {
            TargetGameObject.SendMessage("OnDrag", eventData);
        }
    }
}
