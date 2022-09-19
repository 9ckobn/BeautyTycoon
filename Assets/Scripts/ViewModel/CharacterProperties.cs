using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;
    using UnityEngine;
using UnityEngine.AI;

public sealed class CharacterProperties: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Vector3 _destinationPoint;
        
        public Vector3 DestinationPoint
        {
            get => _destinationPoint;
            set
            {
                _destinationPoint = value;
                OnPropertyChanged("DestinationPoint");
            }
        }

        private NavMeshAgent _NavMeshAgent;

        public NavMeshAgent NavMeshAgent
        {
            get => _NavMeshAgent;
            set
            {
                _NavMeshAgent = value;
                OnPropertyChanged("NavmeshAgent");
            }
        }
        
        private Animator _animator;
        public Animator Animator
        {
            get => _animator;
            set
            {
                _animator = value;
                OnPropertyChanged("Animator");
            }
        }
        
        public Vector3 SetDestinationPoint =>
            ObjectMovement.SetDestinationPoint(DestinationPoint, Animator, NavMeshAgent);
    }