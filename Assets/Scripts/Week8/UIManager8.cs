using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GunduzDev
{
    public class UIManager8 : MonoBehaviour
    {
        public static UIManager8 Instance;

        private const string SCORE_PART = " Score: ";
        private const string KILL_PART = " Kill: ";

        [SerializeField] private TextMeshProUGUI scoreText, killText;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            OnScoreChanged();
            OnKillChanged();
        }

        public void OnScoreChanged()
        {
            scoreText.text = SCORE_PART + PlayerPrefs.GetInt("Score");
        }

        public void OnKillChanged()
        {
            killText.text = KILL_PART + PlayerPrefs.GetInt("Kill");
        }
    }
}
