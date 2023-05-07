using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CometCleanUP
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float timeValue = 60;
        [SerializeField] private TextMeshProUGUI timeText;

        private void Update()
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
            }

            DisplayTime(timeValue);
        }
        void DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }

            //float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            //float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            float milliseconds = timeToDisplay % 1 * 100;

            timeText.text = string.Format("{0:00}:{1:00}", timeToDisplay, milliseconds);
        }
    }
}
