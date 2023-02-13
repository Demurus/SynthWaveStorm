﻿namespace LogTextColorExtension
{
    public static class LogTextColorExtension
    {
        public static string Colored(this string message, ColorType color)
        {
            return $"<color={color.ToString().ToLower()}>{message}</color>";
        }
    }
}