using UnityEngine;
using UnityEngine.UI;

public class Petal : MonoBehaviour
{
    private float TargetAlpha { get; set; }
    private float CurrentAlpha { get; set; }
    private float TargetSize { get; set; }
    private Image ImageComponent { get; set; }

    private const float speed = 0.3f;

    private void Awake()
    {
        ImageComponent = GetComponent<Image>();
        FlowerModule.OnSoundPlaying += (value) =>
        {
            TargetAlpha = Mathf.Clamp(value, 0, 255) * Random.Range(50, 80);
            TargetSize = Mathf.Clamp(value, 0, 1) * Random.Range(30.0f, 50.0f);
        };
    }

    private void Update()
    {
        transform.localScale = Vector2.MoveTowards(Vector3.one, new Vector3(0.7f, 0.7f, 1) + Vector3.one * TargetSize, 60 * Time.deltaTime);
        CurrentAlpha = Mathf.MoveTowards(CurrentAlpha, TargetAlpha, speed * Time.deltaTime);

        Color c = ImageComponent.color;
        c.a = CurrentAlpha;
        ImageComponent.color = c;
    }
}
