using UnityEngine;
using NaughtyAttributes;

namespace Mobile_Core
{
    [System.Serializable]
    public class Chest
    {
        public string name;

        [ShowAssetPreview(50, 50)] public GameObject prefab;

        [ResizableTextArea]
        public string description;
    }

}