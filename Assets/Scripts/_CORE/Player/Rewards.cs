using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;

namespace Mobile_Core
{
   


    [CreateAssetMenu(fileName = "Reward", menuName = "Scriptables/Reward", order = 0)]
    public class Rewards : ScriptableObject
    {
        // CHEST REWARD (RANDOM) : SKIN COLOUR, WEAPON, TATTOO
        // DEFAULT : COINS
        // DOUBLE

        public RewardState type;

        [ShowIf("type", RewardState.STANDARD)]
        public int coins;

        [ShowIf("type", RewardState.GIFT)]
        public List<Chest> chest = new List<Chest>();




    }

}