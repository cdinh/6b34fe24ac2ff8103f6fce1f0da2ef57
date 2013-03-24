using UnityEngine;
using System.Collections;

public static class GuiUtility
{
    // Given percentages as input, produces
    // Rect with adjusted values
    public static Rect PercRect(float x, float y, float width, float height)
    {
        Rect rect = new Rect(Screen.width * x, Screen.height * y, Screen.width * width, Screen.height * height);
        return rect;
    }
}
