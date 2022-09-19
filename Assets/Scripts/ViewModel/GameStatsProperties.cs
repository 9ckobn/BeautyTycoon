
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;

    public class GameStatsProperties: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private int _Attempts;

        public int Attempts
        {
            get => _Attempts;
            set
            {
                _Attempts = value;
                OnPropertyChanged("Attempts");
            }
        }

        private bool _winner;

        public bool Winner
        {
            get => _winner;
            set
            {
                _winner = value;
                OnPropertyChanged("Winner");
            }
        }

        private int _money = 0;

        public int Money
        {
            get => _money;
            set
            {
                _money = value;
                OnPropertyChanged("Money");
            }
        }
        
        private int _reputation = 0;

        public int Reputation
        {
            get => _reputation;
            set
            {
                _reputation = value;
                OnPropertyChanged("Reputation");
            }
        }

        public int GuestCount => Stats.SetGuestCount();
        
        public int SetMoney => Stats.SetMoney(Winner, Attempts);

        public int SetReputation => Stats.SetReputation(Attempts, Winner);
        
        
    }
