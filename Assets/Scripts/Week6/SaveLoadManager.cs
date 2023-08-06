using System;
using UnityEngine;

namespace GunduzDev
{
    public static class SaveDataValues
    {
        public static string Name => "Name";
        public static string Surname => "Surname";
        public static string Age => "Age";
        public static string Gender => "Gender";
        public static string FavoriteGenre => "FavoriteGenre";
        public static string Concern => "Concern";
    }

    public class SaveLoadManager : MonoBehaviour
    {
        public static SaveLoadManager Instance;
        private void Awake()
        {
            Instance = this;
        }

        public void SaveData<T>(string dataName, T value)
        {
            PlayerPrefs.SetString(dataName, JsonUtility.ToJson(value));
        }

        public T LoadData<T>(string dataName)
        {
            if (PlayerPrefs.HasKey(dataName))
            {
                string jsonString = PlayerPrefs.GetString(dataName);
                return JsonUtility.FromJson<T>(jsonString);
            }
            else
            {
                T defaultValue = default;
                SaveData(dataName, defaultValue);
                return defaultValue;
            }
        }
    }
}
