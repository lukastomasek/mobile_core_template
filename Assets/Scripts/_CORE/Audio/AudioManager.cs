using UnityEngine;
using NaughtyAttributes;

namespace Mobile_Core
{
    public class AudioManager : MonoBehaviour
    {

        [Space(20)]
        [Header("Template")]
        [HorizontalLine(color: EColor.Yellow)]
        [SerializeField, Required, Expandable] AudioTemplate audioSo;

        GameObject _backgroundObject, _soundObject;
        AudioSource _bgAudio, _soundAudio;


        private void Awake()
        {

            _backgroundObject = new GameObject("Background Audio");
            _soundObject = new GameObject("Sound Audio");

            _backgroundObject.transform.SetParent(transform);
            _soundObject.transform.SetParent(transform);

            if (_backgroundObject != null)
            {
                _bgAudio = _backgroundObject.AddComponent<AudioSource>();
                _bgAudio.loop = true;
                _bgAudio.playOnAwake = true;
                _bgAudio.volume = audioSo.musicVolume;
            }

            if (_soundObject != null)
            {
                _soundAudio = _soundObject.AddComponent<AudioSource>();
                _soundAudio.loop = false;
                _soundAudio.playOnAwake = false;

                _soundAudio.volume = audioSo.soundVolume;
            }

        }


        private void Start()
        {
            _bgAudio.clip = audioSo.PlayRandomMusic();
            _bgAudio.Play();

        }

        private void OnEnable()
        {
            SettingsManager.UpdateMusicState += MusicSetting;
            SettingsManager.UpdateSoundState += SoundSettings;

        }

        private void OnDisable()
        {
            SettingsManager.UpdateMusicState -= MusicSetting;
            SettingsManager.UpdateSoundState -= SoundSettings;
        }

        void MusicSetting(bool isMute)
        {
            if (_bgAudio != null)
                _bgAudio.mute = !isMute;
        }

        void SoundSettings(bool isMute)
        {
            if (_soundAudio != null)
                _soundAudio.mute = !isMute;
        }





        public void PlayTickSound() => _soundAudio.PlayOneShot(audioSo.clickSound);

        public void PlayButtonSound() => _soundAudio.PlayOneShot(audioSo.buttonSound);

        public void PlayCloseUISound() => _soundAudio.PlayOneShot(audioSo.closeSound);
    }

}