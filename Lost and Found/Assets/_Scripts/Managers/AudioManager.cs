using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public enum SoundEffectType
    {
        Detection, Win, Die, NONE
    };

    [SerializeField] private List<GeneralSoundEffect> generalSoundEffects = new List<GeneralSoundEffect>();
    private Dictionary<SoundEffectType, AudioClip> generalSoundEffectsDict = new Dictionary<SoundEffectType, AudioClip>();

    [SerializeField] private AudioSource musicSource = null;
    [SerializeField] private AudioSource effectSource = null;
    [SerializeField] private AudioClip bgtheme = null;

    /// <summary>
    /// Initialises the SFX Manager and create any necessary links.
    /// </summary>
    public void Initialise()
    {
        foreach (GeneralSoundEffect audio in generalSoundEffects)
        {
            generalSoundEffectsDict.Add(audio.clipType, audio.clip);
        }
    }

    /// <summary>
    /// Plays an effect given effect type.
    /// </summary>
    /// <param name="effectType">The effect type from SoundEffectType enum</param>
    public void PlaySFX(SoundEffectType effectType)
    {
        effectSource.clip = generalSoundEffectsDict[effectType];
        effectSource.PlayOneShot(effectSource.clip);
    }

    /// <summary>
    /// Plays a given music clip
    /// </summary>
    /// <param name="musicClip">Clip to play</param>
    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.Stop();
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlayBackgroundTheme()
    {
        musicSource.Stop();
        musicSource.clip = bgtheme;
        musicSource.Play();
    }

    /// <summary>
    /// Structure to hold effect type to effect clip for editor use.
    /// </summary>
#pragma warning disable 0649
    [System.Serializable]
    struct GeneralSoundEffect
    {
        public SoundEffectType clipType;
        public AudioClip clip;
    }
#pragma warning restore 0649
}
