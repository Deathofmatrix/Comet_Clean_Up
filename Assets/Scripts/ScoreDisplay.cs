using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CometCleanUP
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_TextMeshProUGUI;

        private void Start()
        {
            m_TextMeshProUGUI.text = "-SCORE-\n" + ScoreManager.totalScore * 10;
        }
    }
}
