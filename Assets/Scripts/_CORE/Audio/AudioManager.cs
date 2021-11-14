using UnityEngine;

namespace Mobile_Core
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 1.0f)] float backgroundMusicVol;
        [SerializeField, Range(0.1f, 1.0f)] float soundVol;


        GameObject _backgroundObject, _soundObject;
        AudioSource _bgAudio, _soundAudio;

        private void Awake()
        {
            _backgroundObject = new GameObject("Background Audio");
            _soundObject = new GameObject("Sound Audio");

            _backgroundObject.transform.SetParent(transform);
            _soundObject.transform.SetParent(transform);

            if(_backgroundObject != null)
            {
                _bgAudio = _backgroundObject.AddComponent<AudioSource>();
                _bgAudio.loop = true;
                _bgAudio.playOnAwake = true;
                _bgAudio.volume = backgroundMusicVol;
            }

            if(_soundObject != null)
            {
                _soundAudio = _soundObject.AddComponent<AudioSource>();
                _soundAudio.loop = false;
                _soundAudio.playOnAwake = false;
                _soundAudio.volume = soundVol;
            }
            
        }
    }

}