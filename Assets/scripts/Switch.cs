using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] SoundSO soundSO;   
    [SerializeField]
    private Transform On;
    [SerializeField]
    private Transform Off;
    private bool isOn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnMusicOn()
    {
        SoundManagement.Instance.PlaySound(soundSO.hit);
        isOn = true;
        On.gameObject.SetActive(isOn);
        Off.gameObject.SetActive(!isOn);
        SoundManagement.volumnMusic = 20f;
        SoundManagement.Instance.SettingMusic();
    }
    public void TurnMusicOff()
    {
        SoundManagement.Instance.PlaySound(soundSO.hit);
        isOn = false;   
        On.gameObject.SetActive(isOn);
        Off.gameObject.SetActive(!isOn);
        SoundManagement.volumnMusic = 0f;
        SoundManagement.Instance.SettingMusic();
    }
    public void TurnSoundOn()
    {
        isOn = true;
        SoundManagement.Instance.PlaySound(soundSO.hit);
        SoundManagement.volumnSound = 20f;
        On.gameObject.SetActive(isOn);
        Off.gameObject.SetActive(!isOn);
    }
    public void TurnSoundOff()
    {
        SoundManagement.Instance.PlaySound(soundSO.hit);
        SoundManagement.volumnSound = 0f;
        isOn = false;
        On.gameObject.SetActive(isOn);
        Off.gameObject.SetActive(!isOn);
    }
}
