using System;
using UnityEngine;

public class FlowerModule : MonoBehaviour
{
    private static AudioSource AudioSource { get; set; }
    private static AudioClip[] AudioClips { get; set; }
    public static Action<float> OnSoundPlaying { get; set; }

    public static void Init(FlowerModulePayload flowerModulePayload)
    {
        AudioSource = flowerModulePayload.AudioSource;
        AudioClips = flowerModulePayload.AudioClips;
    }

    public static void Play(int clipId)
    {
        if(AudioSource.isPlaying)
        {
            AudioSource.Stop();
        }

        AudioSource.PlayOneShot(AudioClips[clipId]);
    }
}
