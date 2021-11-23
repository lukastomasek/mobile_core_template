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

        public EREWARD_TYPE type;

        [ShowIf("type", EREWARD_TYPE.COINS)]
        public int coins;

        [ShowIf("type", EREWARD_TYPE.CHEST)]
        public List<Chest> chest = new List<Chest>();




    }

}