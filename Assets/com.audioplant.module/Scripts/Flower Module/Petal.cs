using UnityEngine;
using UnityEngine.UI;

public class Petal : MonoBehaviour
{
    private float Target { get; set; }
    private float Alpha { get; set; }
    private Image ImageComponent { get; set; }

    private const float speed = 0.5f;

    private void Awake()
    {
        ImageComponent = GetComponent<Image>();
        FlowerModule.OnSoundPlaying += (value) =>
        {
            Target = Mathf.Clamp(value, 0, 255) * Random.Range(0.1f, 0.6f);
        };
    }

    private void Update()
    {
        Alpha = Mathf.MoveTowards(Alpha, Target, speed * Time.deltaTime);

        Color c = ImageComponent.color;
        c.a = Alpha;
        ImageComponent.color = c;
    }
}
