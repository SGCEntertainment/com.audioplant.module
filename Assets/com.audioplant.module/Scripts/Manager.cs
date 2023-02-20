using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] GameObject splash;
    [SerializeField] GameObject game;

    [Space(10)]
    [SerializeField] GameObject PlayBtn;
    [SerializeField] GameObject PauseBtn;

    [Space(10)]
    [SerializeField] GameObject next;
    [SerializeField] GameObject prev;

    private IEnumerator Start()
    {
        splash.SetActive(true);
        yield return new WaitForSeconds(0);
        splash.SetActive(false);
        game.SetActive(true);

        FlowerModule.Init(new FlowerModulePayload() 
        { 
            AudioSource = GameObject.Find("Voice").GetComponent<AudioSource>(),
            AudioClips = Resources.LoadAll<AudioClip>("phrases")
        });
    }

    public void Play()
    {
        FlowerModule.Play();

        PlayBtn.SetActive(false);
        PauseBtn.SetActive(true);

        next.SetActive(true);
        prev.SetActive(true);
    }

    public void Pause()
    {
        FlowerModule.Pause();

        PlayBtn.SetActive(true);
        PauseBtn.SetActive(false);

        next.SetActive(false);
        prev.SetActive(false);
    }

    public void Next() => FlowerModule.Next();
    public void Prev() => FlowerModule.Prev();
}
