using UnityEngine;
using NaughtyAttributes;
using Mobile_Utilities;

namespace Mobile_Core
{
    [CreateAssetMenu(fileName ="Audio Template", menuName ="Scriptables/Audio", order =1)]
    public class AudioTemplate : ScriptableObject
    {
        [Header("Audio Settings")]
        [Range(0.1f, 1f)] public float musicVolume = 0.5f;
        [Range(0.1f, 1f)] public float soundVolume = 0.5f;


        [Header("UI Sounds")]
        [HorizontalLine(color: EColor.Blue)]
        public AudioClip clickSound;
        public AudioClip closeSound;
        public AudioClip buttonSound;

        [Space(50)]
        [Header("Music")]
        [HorizontalLine(color: EColor.Red)]
        public AudioClip[] backgroundMusic;


        public AudioClip PlayRandomMusic()
        {
            return Helper.RandomSound(backgroundMusic);
        }
    }

}