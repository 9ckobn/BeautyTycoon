using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DaytimeSystem: MonoBehaviour
    {
        [SerializeField] private Text timeText;
        [SerializeField] private GameObject PopUp;

        [SerializeField] private Text HUDMoney;
        [SerializeField] private Text HUDReputation;
        
        public float totalSeconds = 480;

        private void Awake()
        {
            Time.timeScale = 1;
            
            HUDMoney.text = Stats.Money.ToString() + @"$";
            HUDReputation.text = Stats.Reputation.ToString();
        }

        private void Start()
        {
            DisplayTime(totalSeconds);
            StartCoroutine(DayTimer());
        }

        IEnumerator DayTimer()
        {
            while (totalSeconds < 1200)
            {
                totalSeconds += 2.4f;
                yield return new WaitForSeconds(1);
                DisplayTime(totalSeconds);
            }

            //Time.timeScale = 0;
            //PopUp.SetActive(true);
        }

        void DisplayTime(float timeToDisplay)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
