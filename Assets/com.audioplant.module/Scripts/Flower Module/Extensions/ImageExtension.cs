using UnityEngine;
using UnityEngine.UI;

public static class ImageExtension
{
    public static void SetImageColor(this Image image, float alphaValue)
    {
        Color c = image.color;
        c.a = alphaValue;
        image.color = c;
    }
}
