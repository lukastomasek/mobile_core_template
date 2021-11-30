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

        public static Color RandomColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax, float aMin,float aMax)
        {
            return Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax, aMin, aMax);
        }

        public static Color RandomColor(float alpha)
        {
            return new Color(Random.value, Random.value, Random.value, alpha);
        }


   
    }
}
