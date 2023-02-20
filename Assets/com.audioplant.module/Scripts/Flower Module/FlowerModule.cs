using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FlowerModule : MonoBehaviour
{
    private static float dS;
    private static float target;
    private static float speed;
    private static int count;

    private static AudioSource AudioSource { get; set; }
    private static Image HollowImage { get; set; }

    private static float Progress
    {
        get => HollowImage.fillAmount;
        set => HollowImage.fillAmount = value;
    }

    public static Action<float> OnSoundPlaying { get; set; }

    private void Awake()
    {
        HollowImage = transform.GetChild(1).GetComponent<Image>();
    }

    private void Update()
    {
        int _count = 256;
        float[] spectrum = new float[_count];
        AudioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        OnSoundPlaying?.Invoke(spectrum.Sum() / _count);

        if (!AudioSource.isPlaying)
        {
            return;
        }

        Progress = Mathf.MoveTowards(Progress, target, speed * Time.deltaTime);
    }

    public static void Init(FlowerModulePayload flowerModulePayload)
    {
        count = flowerModulePayload.Count;
        AudioSource = flowerModulePayload.AudioSource;

        dS = 1.0f / count;
    }

    public static void PlayOneShot(int index, float duration)
    {
        target = dS * (index + 1);
        speed = dS / duration;
        Progress = dS * index;
    }
}
