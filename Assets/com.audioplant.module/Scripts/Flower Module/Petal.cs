using UnityEngine;
using UnityEngine.UI;

public class Petal : MonoBehaviour
{
    private Image ImageComponent { get; set; }

    private void Awake()
    {
        ImageComponent = GetComponent<Image>();
        FlowerModule.OnSoundPlaying += (value) =>
        {
            Color _color = ImageComponent.color;
            _color.a = value;

            ImageComponent.color = _color;
        };
    }
}
