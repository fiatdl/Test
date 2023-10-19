using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
    [SerializeField] public SoundSO soundSO;
    public static SoundManagement Instance { get; private set; }
    public static float volumnMusic = 20f;
    public static float volumnSound = 20f;
    private AudioSource audioSource;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position, volumnSound * 5f);
    }
    public void SettingMusic()
    {
        audioSource.volume= volumnMusic;
    }
}
