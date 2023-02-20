using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] GameObject PlayBtn;
    [SerializeField] GameObject PauseBtn;

    [Space(10)]
    [SerializeField] GameObject next;
    [SerializeField] GameObject prev;

    private void Start()
    {
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
