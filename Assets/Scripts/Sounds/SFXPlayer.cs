using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;

namespace SoundSystem
{

    public class SFXPlayer : MonoBehaviour
    {

        public static SFXPlayer instance;

        [SerializeField] private int sfxPlayersPoolSize;
        [SerializeField] private AudioSource referenceAudioPlayer;
        [SerializeField] private Transform sfxPlayersParent;
        private List<AudioSource> _sfxPlayersInstances;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _sfxPlayersInstances = new List<AudioSource>();
            GameObject tmp;
            for (int i = 0; i < sfxPlayersPoolSize; i++)
            {
                tmp = Instantiate(referenceAudioPlayer.gameObject, sfxPlayersParent);
                tmp.SetActive(false);
                _sfxPlayersInstances.Add(tmp.GetComponent<AudioSource>());
            }
        }

        public AudioSource GetPooledObject()
        {
            for (int i = 0; i < sfxPlayersPoolSize; i++)
            {
                if (!_sfxPlayersInstances[i].gameObject.activeInHierarchy)
                {
                    return _sfxPlayersInstances[i];
                }
            }
            return null;
        }

        public void PlaySFX([NotNull] AudioClip _audioClip, AudioMixerGroup _mixer)
        {
            AudioSource currentSource = GetPooledObject();
            currentSource.clip = _audioClip;
            currentSource.outputAudioMixerGroup = _mixer;
            currentSource.gameObject.SetActive(true);
            currentSource.Play();
            StartCoroutine(returnPooledObject(currentSource.gameObject, _audioClip.length));
        }

        private IEnumerator returnPooledObject(GameObject _audioSource, float _SFXDuration)
        {
            yield return new WaitForSeconds(_SFXDuration);
            _audioSource.SetActive(false);
        }

    }

}