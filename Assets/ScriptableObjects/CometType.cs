using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CometCleanUP
{
    [CreateAssetMenu(fileName = "New Comet", menuName = "Comet")]
    public class CometType : ScriptableObject
    {
        public Color color;

        public int speed;
        public int value;
    }
}