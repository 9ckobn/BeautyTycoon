
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CanvasSwipeGame: MonoBehaviour
    {
        public int NumberToSolve;
    
        public GameObject CardToSwipe;

        public bool win = false;

        public int AttemptsCount;

        [SerializeField] private GuestBehaviour Guest;
        
        private void OnEnable()
        {
            AttemptsCount = 0;
            StartCoroutine(CardSpawner());
        }

        private IEnumerator CardSpawner()
        {
            while (true)
            {
                yield return new WaitForSeconds(.25f);
                if (transform.childCount < 2)
                {
                    var Card = Instantiate(CardToSwipe, transform, false);
                    Card.transform.SetAsFirstSibling();
                }
            }
        }

        public void CalculateWin(int numbertosolve)
        {
            win = NumberToSolve == numbertosolve ? true : false;
            Guest.GetResultOfService(AttemptsCount, win);
            gameObject.SetActive(false);
        }

        public void AddAttempt() => AttemptsCount++;
    }