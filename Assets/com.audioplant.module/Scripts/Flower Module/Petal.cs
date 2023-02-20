using UnityEngine;
using UnityEngine.UI;

public class Petal : MonoBehaviour
{
    private float TargetAlpha { get; set; }
    private float CurrentAlpha { get; set; }
    private Image ImageComponent { get; set; }

    private const float speed = 0.3f;

    private void Awake()
    {
        ImageComponent = GetComponent<Image>();
        FlowerModule.OnSoundPlaying += (value) =>
        {
            TargetAlpha = Mathf.Clamp(value, 0, 255) * Random.Range(50, 80);
        };
    }

    private void Update()
    {
        CurrentAlpha = Mathf.MoveTowards(CurrentAlpha, TargetAlpha, speed * Time.deltaTime);
        ImageComponent.SetImageColor(CurrentAlpha);
    }
}
