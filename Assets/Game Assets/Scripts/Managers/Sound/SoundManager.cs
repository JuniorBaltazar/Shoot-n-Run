using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [Space(5)]
    [Header("AUDIO SOURCERS")]
    [SerializeField] private AudioSource music = null;
    public AudioSource sfx = null;

    [Space(5)]
    [Header ("LIST SOUNDS")]
    [SerializeField] private List<AudioClip> listMusic = new List<AudioClip>();
    [Space(5)]
    [SerializeField] private List<AudioClip> listSfx = new List<AudioClip> ();

    #region Play Music
    public void PlayMusic (int indexMusic) {
        this.music.clip = this.listMusic[indexMusic];
        this.music.Play();
    }
    #endregion

    #region Play Sfx
    public void PlaySfx (int indexSfx) {
        this.sfx.clip = this.listSfx[indexSfx];
        this.sfx.Play();
    }
    #endregion

    #region Audio Clip Music
    public void AudioClipMusic(AudioClip audioMusic) {
        this.music.clip = audioMusic;
        this.music.Play();
    }
    #endregion

    #region Audio Clip Sfx
    public void AudioClipSfx(AudioClip audioSfx) {
        this.sfx.clip = audioSfx;
        this.sfx.Play();
    }
    #endregion
}