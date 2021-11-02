using UnityEngine;


namespace Mobile_Utilities
{
    public static class Helper
    {
        public static int RandomDamage(int min, int max)
        {
            return Random.Range(min, max);
        }

        public static AudioClip RandomSound(AudioClip [] sounds) 
        {
            return sounds[Random.Range(0, sounds.Length)];
        }
    }
}
