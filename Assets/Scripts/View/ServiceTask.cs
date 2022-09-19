using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ServiceTask: MonoBehaviour
{
    [SerializeField] private Text popupText;
        
        [Range(1, 3)] public int NumberToSolve;

        public GameObject CanvasGame;

        public CharacterBehaviour _Character;

        [SerializeField] private GameObject positiveReaction;
        [SerializeField] private GameObject negativeReaction;

        private void OnEnable()
        {
            _Character = FindObjectOfType<CharacterBehaviour>();
            StartCoroutine(TakeService());
        }

        IEnumerator TakeService()
        {
            for (int i = 0; i < 50; i++)
            {
                yield return new WaitForSeconds(.05f);
                NumberToSolve = Random.Range(1, 4);
                popupText.text = NumberToSolve.ToString();
            }

            while (_Character._character.CurrentState != CharacterState.ByResep)
            {
                Debug.Log(_Character._character.CurrentState.ToString());
                yield return new WaitForSeconds(.25f);
            }

            yield return new WaitForSeconds(2);
            
            CanvasGame.SetActive(true);
            CanvasGame.GetComponent<CanvasSwipeGame>().NumberToSolve = NumberToSolve;
        }

        IEnumerator GetReaction(bool positive)
        {
            if(positive)
                positiveReaction.SetActive(true);
            else
                negativeReaction.SetActive(true);

            yield return new WaitForSeconds(2.5f);
            
            positiveReaction.SetActive(false);
            negativeReaction.SetActive(false);
            gameObject.SetActive(false);
        }

        public void Reaction(bool positive)
        {
            StartCoroutine(GetReaction(positive));
        }
    }
