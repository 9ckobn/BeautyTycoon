
    public static  class Stats
    {
        public static int Reputation;
        public static int Money;
        public static int GuestCount = 0;

        public static int SetGuestCount()
        {
            return GuestCount++;
        }
        
        public static int SetReputation(int Attempts, bool Winner)
        {
            if (Winner)
                return Reputation += 10 - Attempts;
            else
                return  Reputation -= Attempts;
        }

        public static int SetMoney(bool Winner, int Attempts)
        {
            if (Winner)
                return Money += 25 + (Reputation / 10) - Attempts;
            else
                return Money -= (Reputation / 10);
        }
    }
