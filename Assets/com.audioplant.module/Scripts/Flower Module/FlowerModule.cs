using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FlowerModule : MonoBehaviour
{
    private static int Index { get; set; }
    private static AudioSource AudioSource { get; set; }
    private static Image HollowImage { get; set; }
    private static AudioClip[] AudioClips { get; set; }
    public static Action<float> OnSoundPlaying { get; set; }

    private void Awake()
    {
        HollowImage = transform.GetChild(1).GetComponent<Image>();
    }

    public static void Init(FlowerModulePayload flowerModulePayload)
    {
        Index = 0;

        AudioSource = flowerModulePayload.AudioSource;
        AudioClips = flowerModulePayload.AudioClips;
    }

    public static void Play()
    {
        HollowImage.fillAmount = 1.0f / AudioClips.Length * Index;
        AudioSource.clip = AudioClips[Index];
        AudioSource.Play();
    }

    public static void Pause()
    {
        AudioSource.Pause();
    }

    public static void Next()
    {
        Index++;
        if(Index > AudioClips.Length - 1)
        {
            Index = 0;
        }

        Play();
    }

    public static void Prev()
    {
        Index--;
        if (Index < 0)
        {
            Index = AudioClips.Length - 1;
        }

        Play();
    }

    private void Update()
    {
        if(!AudioSource.isPlaying)
        {
            return;
        }

        float[] spectrum = new float[256];
        AudioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        OnSoundPlaying?.Invoke(spectrum.Sum());

        float target = 1.0f / AudioClips.Length * (Index + 1);
        float speed = 1.0f / AudioClips.Length / AudioClips[Index].length;
        HollowImage.fillAmount = Mathf.MoveTowards(HollowImage.fillAmount, target, speed * Time.deltaTime);
    }
}
