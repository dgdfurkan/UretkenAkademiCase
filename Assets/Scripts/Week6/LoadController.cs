using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace GunduzDev
{
    public class LoadController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        private void Start()
        {
            string _name = PlayerPrefs.GetString(SaveDataValues.Name);
            string _surname = PlayerPrefs.GetString(SaveDataValues.Surname);
            int _age = PlayerPrefs.GetInt(SaveDataValues.Age);
            string _gender = PlayerPrefs.GetString(SaveDataValues.Gender);
            string _favoriteGenre = PlayerPrefs.GetString(SaveDataValues.FavoriteGenre);

            text.text = "Name: " + _name + "\n" + "Surname: " + _surname + "\n" + "Age: " + _age + "\n" + "Gender: " + _gender + "\n" + "FavoriteGenre: " + _favoriteGenre;
        }

        public void PreviousScene()
        {
            SceneManager.LoadSceneAsync("Week6");
        }
    }
}
