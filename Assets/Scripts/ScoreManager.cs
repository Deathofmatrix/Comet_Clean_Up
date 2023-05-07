using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CometCleanUP
{
    public class ScoreManager : MonoBehaviour
    {
        public int totalScore;

        private void OnEnable()
        {
            CometMovement.cometDeathEvent += AddScore;
        }
        private void OnDisable()
        {
            CometMovement.cometDeathEvent -= AddScore;
        }
        public void AddScore(int score)
        {
            totalScore += score;
        }
    }
}