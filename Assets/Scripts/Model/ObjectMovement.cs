using UnityEngine;
using UnityEngine.AI;

    public static class ObjectMovement
    {
        public static Vector3 SetDestinationPoint(Vector3 DesctinationPoint, Animator animator,
            NavMeshAgent navMeshAgent)
        {
            navMeshAgent.SetDestination(DesctinationPoint);
            return navMeshAgent.pathEndPosition;
        }
    }
