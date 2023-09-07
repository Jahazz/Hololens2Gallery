using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Codebase.Utils
{
    public static class Utils
    {
        public static Sprite Texture2DToSprite (Texture2D source)
        {
            return Sprite.Create(source, new Rect(0.0f, 0.0f, source.width, source.height), Vector2.one / 2, 100.0f);
        }

        public static void AddEventTriggerListener (EventTrigger eventTriggerInstance, EventTriggerType triggerType, Action<PointerEventData> callback)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = triggerType;
            entry.callback.AddListener((data) => { callback.Invoke((PointerEventData)data); });

            if (eventTriggerInstance.triggers == null)
            {
                eventTriggerInstance.triggers = new System.Collections.Generic.List<EventTrigger.Entry>();
            }

            eventTriggerInstance.triggers.Add(entry);
        }
    }
}

