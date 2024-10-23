using UnityEngine;

public static class Constant
{
    public static float ScreenHeight => Camera.main.orthographicSize * 2;
    public static float ScreenWidth => ScreenHeight * Camera.main.aspect;
    public static int InvalidIndex = -1;
    public static int NumberColumn = 4;
}
