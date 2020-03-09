using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip soundClip;
    [Range(0.0f, 1.0f)]
    public float volume;
    [Range(0.5f, 1.5f)]
    public float pitch;
    [Range(0.0f, 0.5f)]
    public float randomVolume;
    [Range(0.0f, 0.5f)]
    public float randomPitch;

    public bool loop;


    private AudioSource soundSource;

    public void SetSource(AudioSource source)
    {
        soundSource = source;
        soundSource.clip = soundClip;
        soundSource.loop = loop;
    }

    public void PlaySound()
    {
        soundSource.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        soundSource.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        soundSource.Play();
    }

    public void StopSound()
    {
        if (soundSource != null)
            soundSource.Stop();
    }

}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private Sounds[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject go = new GameObject(string.Format("Sound_{0}_{1}", i, sounds[i].name));
            go.transform.SetParent(this.transform);
            sounds[i].SetSource(go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string soundName)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name.ToLower() == soundName.ToLower())
            {
                sounds[i].PlaySound();
                return;
            }
        }

        Debug.LogWarning("No sound by name of " + soundName + "found!");
    }

    public void StopSound(string soundName)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name.ToLower() == soundName.ToLower())
            {
                sounds[i].StopSound();
                return;
            }
        }

        Debug.LogWarning("No sound by name of " + soundName + "found!");
    }

}
