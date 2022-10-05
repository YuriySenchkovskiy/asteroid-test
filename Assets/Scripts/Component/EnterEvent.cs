using System;
using UnityEngine;
using UnityEngine.Events;

namespace Component
{
    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {
    }
}