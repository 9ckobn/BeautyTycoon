using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

public class CharacterBehaviour: MonoBehaviour
    {
        public LayerMask LayerMask;
        public float CharacterSpeed;
        public Animator Animator;
        public Character _character;
        private AnimationStateMachine _animationStateMachine;

        private int tapCounter;

        [SerializeField] private Transform SitPosition;
        private void Start()
        {
            _character = new Character()
            {
                Input = gameObject.AddComponent<CharacterInput>(),
                CharacterSpeed = CharacterSpeed,
                CharacterAnimator = Animator,
                CharacterProperties = new CharacterProperties(),
                NavMeshAgent = GetComponent<NavMeshAgent>()
            };

            _animationStateMachine = new AnimationStateMachine()
            {
                _animator = _character.CharacterAnimator,
            };

            _character.Input.Mask = LayerMask;
            _character.NavMeshAgent.speed = _character.CharacterSpeed;
            _character.CharacterProperties.NavMeshAgent = _character.NavMeshAgent;
            _character.CharacterProperties.Animator = _character.CharacterAnimator;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                tapCounter++;
                StartCoroutine(ResetTaps());
            }

            if (tapCounter == 2 && _character != null)
            {
                _character.CurrentState = CharacterState.Free;
                
                Vector3 destinationPoint;
                _character.CharacterProperties.DestinationPoint = _character.Input.GetDestinationPoint();

                destinationPoint = _character.CharacterProperties.SetDestinationPoint;

                _animationStateMachine.CurrentState = State.Walk;

                StartCoroutine(AgentStop());
            }
        }

        private IEnumerator ResetTaps()
        {
            yield return new WaitForSeconds(0.5f);
            tapCounter = 0;
        }

        private IEnumerator AgentStop()
        { 
            yield return new WaitForSeconds(.1f);
            
            while (_character.NavMeshAgent.velocity.magnitude > 0)
            {
                yield return new WaitForSeconds(.05f);
            }

            _animationStateMachine.CurrentState = State.Idle;
            _character.CurrentState = CharacterState.ByResep;
        }

        private void OnTriggerEnter(Collider other)
        {
            _animationStateMachine.CurrentState = State.Busy;

            transform.localEulerAngles = new Vector3(0, -180, 0);
        }

        private void OnTriggerExit(Collider other)
        {
            _animationStateMachine.CurrentState = State.Idle;
            _character.CurrentState = CharacterState.Free;
        }
    }
