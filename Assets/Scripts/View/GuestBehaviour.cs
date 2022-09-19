
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.AI;
    using UnityEngine.UI;

    public class GuestBehaviour : MonoBehaviour
    {
        private Guest _guest;
        private AnimationStateMachine _animationStateMachine;

        [SerializeField] private GameObject PopUp;

        [SerializeField] private Text HUDMoney;
        [SerializeField] private Text HUDReputation;

        private void OnEnable()
        {
            PopUp.SetActive(false);
        }

        private void Awake()
        {
            _guest = new Guest()
            {
                GuestAnimator = GetComponent<Animator>(),
                NavMeshAgent = GetComponent<NavMeshAgent>(),
                CharacterProperties = new CharacterProperties(),
                GameStatsProperties = new GameStatsProperties()
            };

            _animationStateMachine = new AnimationStateMachine()
            {
                _animator = _guest.GuestAnimator,
            };
            
            _guest.CharacterProperties.Animator = _guest.GuestAnimator;
            _guest.CharacterProperties.NavMeshAgent = _guest.NavMeshAgent;
        }

        public void GetService(Vector3 DestinationPoint)
        {
            _guest.CharacterProperties.DestinationPoint = DestinationPoint;

            var destinationPoint = _guest.CharacterProperties.SetDestinationPoint;
            
            _animationStateMachine.CurrentState = State.Walk;

            StartCoroutine(AgentStop(false));
        }
        
        private IEnumerator AgentStop(bool needDisable)
        { 
            yield return new WaitForSeconds(.1f);
            
            while (_guest.NavMeshAgent.velocity.magnitude > 0)
            {
                yield return new WaitForSeconds(.05f);
            }
            
            if (needDisable)
            {
                gameObject.SetActive(false);
            }
            
            PopUp.SetActive(true);

            _animationStateMachine.CurrentState = State.Idle;
            _animationStateMachine.CurrentState = State.Thinking;

            yield return new WaitForSeconds(2);
        }

        public void GetResultOfService(int Attempts, bool isWinner)
        {
            _guest.GameStatsProperties.Attempts = Attempts;
            _guest.GameStatsProperties.Winner = isWinner;

            HUDMoney.text = _guest.GameStatsProperties.SetMoney.ToString() + @"$";
            HUDReputation.text = _guest.GameStatsProperties.SetReputation.ToString();

            PopUp.GetComponent<ServiceTask>().Reaction(isWinner);

            _animationStateMachine.CurrentState = State.Walk;

            _guest.CharacterProperties.DestinationPoint = new Vector3(1.343f, 0.133f, -0.481f);

            var destinationPoint = _guest.CharacterProperties.SetDestinationPoint;

            StartCoroutine(AgentStop(true));
        }
        
        
    }
