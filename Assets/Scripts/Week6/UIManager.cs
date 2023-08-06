using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace GunduzDev
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField] private TMP_InputField _name;
        [SerializeField] private TMP_InputField _surname;
        [SerializeField] private Slider _age;
        [SerializeField] private TextMeshProUGUI _ageText;
        [SerializeField] private TMP_Dropdown _gender;
        [SerializeField] private TMP_Dropdown _favoriteGenre;
        [SerializeField] private Toggle _concern;
        [SerializeField] private Button _playButton;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            //Debug.Log(SaveLoadManager.Instance.LoadData<string>(SaveDataValues.Name));
            //Debug.Log(SaveLoadManager.Instance.LoadData<string>(SaveDataValues.Surname));
            //Debug.Log(SaveLoadManager.Instance.LoadData<int>(SaveDataValues.Age));
            //Debug.Log(SaveLoadManager.Instance.LoadData<string>(SaveDataValues.Gender));
            //Debug.Log(SaveLoadManager.Instance.LoadData<string>(SaveDataValues.FavoriteGenre));
            //Debug.Log(SaveLoadManager.Instance.LoadData<bool>(SaveDataValues.Concern));

            Debug.Log(PlayerPrefs.GetString(SaveDataValues.Name));
            Debug.Log(PlayerPrefs.GetString(SaveDataValues.Surname));
            Debug.Log(PlayerPrefs.GetInt(SaveDataValues.Age));
            Debug.Log(PlayerPrefs.GetString(SaveDataValues.Gender));
            Debug.Log(PlayerPrefs.GetString(SaveDataValues.FavoriteGenre));
        }

        public void SaveName()
        {
            //SaveLoadManager.Instance.SaveData<string>(SaveDataValues.Name, _name.text);
            PlayerPrefs.SetString(SaveDataValues.Name, _name.text);
        }

        public void SaveSurname()
        {
            //SaveLoadManager.Instance.SaveData<string>(SaveDataValues.Surname, _surname.text);
            PlayerPrefs.SetString(SaveDataValues.Surname, _surname.text);
        }

        public void SaveAge()
        {
            //SaveLoadManager.Instance.SaveData<int>(SaveDataValues.Age, (int)_age.value);
            PlayerPrefs.SetInt(SaveDataValues.Age, (int)_age.value);
            _ageText.text = _age.value.ToString();
        }

        public void SaveGender()
        {
            //SaveLoadManager.Instance.SaveData<string>(SaveDataValues.Gender, _gender.captionText.text);
            int selectedIndex = _gender.value;
            string selectedValue = _gender.options[selectedIndex].text;
            PlayerPrefs.SetString(SaveDataValues.Gender, selectedValue);
        }

        public void SaveFavoriteGame()
        {
            //SaveLoadManager.Instance.SaveData<string>(SaveDataValues.FavoriteGenre, _favoriteGenre.captionText.text);
            int selectedIndex = _favoriteGenre.value;
            string selectedValue = _favoriteGenre.options[selectedIndex].text;
            PlayerPrefs.SetString(SaveDataValues.FavoriteGenre, selectedValue);
        }

        public void SaveConcern()
        {
            //SaveLoadManager.Instance.SaveData<bool>(SaveDataValues.Concern, _concern.isOn);
            ChangeButton(_concern.isOn);
        }

        private void ChangeButton(bool value)
        {
            _playButton.interactable = value;
        }

        public void PlayGame()
        {
            SceneManager.LoadSceneAsync("Week6_1");
        }
    }
}
