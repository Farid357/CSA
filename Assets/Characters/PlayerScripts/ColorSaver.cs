using UnityEngine;

namespace GameSaveTools
{
    public static class ColorSaver 
    {
        private static string ColorKey;

        public static void Save(Color color, string key)
        {
            PlayerPrefs.SetFloat(key + "R", color.r);
            PlayerPrefs.SetFloat(key + "G", color.g);
            PlayerPrefs.SetFloat(key + "B", color.b);
            PlayerPrefs.SetFloat(key + "A", color.a);
            PlayerPrefs.SetString(key + "C", ColorKey);
        }
    }
    public struct ColorData
    {

        public string ColorKey;

        private float ColorR;
        private float ColorG;
        private float ColorB;
        private float ColorA;

        public bool HaveKey(string key)
        {
            if (PlayerPrefs.HasKey(key + "C"))
            {
                ColorKey = PlayerPrefs.GetString(key + "C");
                return true;
            }
            return false;
        }
        public Color LoadColor(string key)
        {
            ColorR = PlayerPrefs.GetFloat(key + "R");
            ColorG = PlayerPrefs.GetFloat(key + "G");
            ColorB = PlayerPrefs.GetFloat(key + "B");
            ColorA = PlayerPrefs.GetFloat(key + "A");
            Color color = new Color(ColorR, ColorG, ColorB, ColorA);
            return color;
        }

    }

}
