using UnityEngine;
using NaughtyAttributes;

namespace Mobile_Core
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Music Settings")]
        [HorizontalLine(color: EColor.Orange)]
        [SerializeField, Range(0.1f, 1.0f)] float backgroundMusicVol;
        [SerializeField, Range(0.1f, 1.0f)] float soundVol;

        [Space(20)]
        [Header("Template")]
        [HorizontalLine(color: EColor.Yellow)]
        [SerializeField, Required, Expandable] AudioTemplate audioSo;

        GameObject _backgroundObject, _soundObject;
        AudioSource _bgAudio, _soundAudio;

        SaveData _data = new SaveData();


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

                if (_data != null)
                {
                    //_bgAudio.mute = !_data.playMusic;
                }
                else
                {
                    _bgAudio.volume = backgroundMusicVol;

                }
            }

            if (_soundObject != null)
            {
                _soundAudio = _soundObject.AddComponent<AudioSource>();
                _soundAudio.loop = false;
                _soundAudio.playOnAwake = false;

                if (_data != null)
                {
                    //_soundAudio.mute = !_data.playSound;
                }
                else
                {

                    _soundAudio.volume = soundVol;
                }
            }

        }


        private void Start()
        {
            _bgAudio.clip = audioSo.PlayRandomMusic();
            _bgAudio.Play();

        }

        private void OnEnable()
        {
            SettingsManager.changeMusicSettings += MusicSetting;
            SettingsManager.changeSoundSettings += SoundSettings;
        }

        private void OnDestroy()
        {
            SettingsManager.changeMusicSettings -= MusicSetting;
            SettingsManager.changeSoundSettings -= SoundSettings;
        }


        public void MusicSetting(bool isMute)
        {
            _bgAudio.mute = !isMute;
        }

        public void SoundSettings(bool isMute)
        {
            _soundAudio.mute = !isMute;
        }



        public void PlayTickSound() => _soundAudio.PlayOneShot(audioSo.clickSound);

        public void PlayButtonSound() => _soundAudio.PlayOneShot(audioSo.buttonSound);

        public void PlayCloseUISound() => _soundAudio.PlayOneShot(audioSo.closeSound);
    }

}