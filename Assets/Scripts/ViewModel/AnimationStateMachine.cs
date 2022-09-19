using UnityEngine;

    public class AnimationStateMachine
    {
        public Animator _animator;
        
        private State _currentState = State.Idle;

        public State CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                OnStateChnged(_currentState);
            }
        }
        
        void OnStateChnged(State state)
        {
            switch (state)
            {
                case  State.Idle:
                    _currentState = State.Idle;
                    _animator.SetBool("walk", false);
                    break;
                
                case State.Walk:
                    _currentState = State.Walk;
                    _animator.SetBool("Sit", false);
                    _animator.SetBool("walk", true);
                    break;
                
                case State.Thinking:
                    _currentState = State.Thinking;
                    _animator.SetTrigger("Thinking");
                    break;
                
                case State.Busy:
                    _currentState = State.Busy;
                    _animator.SetBool("Sit", true);
                    break;
                
            }
        }
    }
    

    public enum State
    {
        Walk,
        Idle,
        Thinking,
        Busy
    }