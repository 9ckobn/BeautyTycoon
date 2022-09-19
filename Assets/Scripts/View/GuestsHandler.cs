
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnityEngine;

    public class GuestsHandler: MonoBehaviour
    {
        [SerializeField] private Transform SpawnPoint;
        [SerializeField] private Transform DestinationPoint;

        [SerializeField] private GameObject Guest;

        [SerializeField] private int GuestCount;

        [SerializeField] private DaytimeSystem _daytimeSystem;
        
        [SerializeField] private GameObject TodayStatistic;

        private Guest _guest;
        
        void Start()
        {   
            if (_daytimeSystem.totalSeconds > 480 && _daytimeSystem.totalSeconds < 1200)
            {
                StartCoroutine(GuestSpawner());
            }
        }
        
        private IEnumerator GuestSpawner() //here can be implemented objectpool for later
        {                                  //List<GuestBeahviour>.... while (ActiveGuestCount != GuestCount) setactive(true)
            while (_daytimeSystem.totalSeconds < 1200)
            {
                yield return new WaitForSeconds(5);
                if (!Guest.activeInHierarchy)
                    InitializeGuest();
            }
            
            //TodayStatistic.SetActive(true);
            var stats = TodayStatistic.GetComponent<TodayStatistic>();
            stats.GuestCount = GuestCount;
            stats.MiddleReputation = Stats.Reputation;
            stats.TotalMoney = Stats.Money;
            TodayStatistic.SetActive(true);
            Time.timeScale = 0;
        }
        
        private void InitializeGuest()
        {
            GuestCount++;
            Guest.gameObject.SetActive(true);
            Guest.transform.position = SpawnPoint.position;
            Guest.GetComponent<GuestBehaviour>().GetService(DestinationPoint.position);
        }
        
    }
