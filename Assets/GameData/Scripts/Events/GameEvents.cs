using System;
using UnityEngine;

namespace JumpEgg.Events
{
    public class GameEvents
    {
        public static event Action<Transform> EggSettled;

        public static void OnEggSettled(Transform targetTransform)
        {
            if(EggSettled != null)
            {
                EggSettled.Invoke(targetTransform);
            }
        }
    }
}