using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    // Name of the sound, used for identification
    public string Name;

    // Audio clip to be played
    public AudioClip clip;

    // Volume of the audio (0 to 1)
    [Range(0, 1f)]
    public float volume;

    // Pitch of the audio (0.1 to 3)
    [Range(0.1f, 3f)]
    public float pitch;

    // Whether the audio should loop
    public bool loop;

    // Reference to the AudioSource component (hidden in the inspector)
    [HideInInspector]
    public AudioSource source;
}
