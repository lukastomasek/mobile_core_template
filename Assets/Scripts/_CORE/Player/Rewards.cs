using UnityEngine;

namespace Mobile_Core
{
    [CreateAssetMenu(fileName = "Reward", menuName ="Scriptables/Reward", order = 0)]
    public class Rewards : ScriptableObject
    {
        [Header("DIFFERENT REWARD TYPES")]
        public int basicReward;
        public int doubleReward;
    }

}