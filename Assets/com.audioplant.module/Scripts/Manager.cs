using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private int index;

    [SerializeField] GameObject splash;
    [SerializeField] GameObject game;

    [Space(10)]
    [SerializeField] GameObject PlayBtn;
    [SerializeField] GameObject PauseBtn;

    [Space(10)]
    [SerializeField] GameObject next;
    [SerializeField] GameObject prev;


    private AudioSource AudioSource { get; set; }
    private AudioClip[] AudioClips { get; set; }

    private IEnumerator Start()
    {
        AudioSource = GameObject.Find("Voice").GetComponent<AudioSource>();
        AudioClips = Resources.LoadAll<AudioClip>("phrases");

        FlowerModule.Init(new FlowerModulePayload()
        {
            Count = AudioClips.Length,
            AudioSource = AudioSource
        });

        splash.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        splash.SetActive(false);
        game.SetActive(true);
    }

    public void Play()
    {
        AudioSource.clip = AudioClips[index];
        AudioSource.Play();

        PlayBtn.SetActive(false);
        PauseBtn.SetActive(true);

        next.SetActive(true);
        prev.SetActive(true);

        FlowerModule.PlayOneShot(index, AudioSource.clip.length);
    }

    public void Pause()
    {
        AudioSource.Pause();

        PlayBtn.SetActive(true);
        PauseBtn.SetActive(false);

        next.SetActive(false);
        prev.SetActive(false);
    }

    public void Next()
    {
        index++;
        if (index > AudioClips.Length - 1)
        {
            index = 0;
        }

        Play();
    }

    public void Prev()
    {
        index--;
        if (index < 0)
        {
            index = AudioClips.Length - 1;
        }

        Play();
    }
}
