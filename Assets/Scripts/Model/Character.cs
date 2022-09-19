using UnityEngine;
using UnityEngine.AI;

public class Character
    {
        public CharacterInput Input;
        public float CharacterSpeed;
        public Animator CharacterAnimator;
        public CharacterProperties CharacterProperties;
        public NavMeshAgent NavMeshAgent;
        public CharacterState CurrentState;
    }

public enum CharacterState
{
    Free,
    ByResep
}
