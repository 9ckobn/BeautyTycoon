using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TodayStatistic : MonoBehaviour
{
    [SerializeField] private Text moneyEarned;
    [SerializeField] private Text repEarned;
    [SerializeField] private Text TotalGuests;

    public int TotalMoney;
    public int MiddleReputation;
    public int GuestCount;

    private void OnEnable()
    {
        moneyEarned.text = "Money earned: " + TotalMoney + @"$";
        repEarned.text = "Your middle Reputation = " + MiddleReputation / GuestCount;
        TotalGuests.text = "Total guest count: " + GuestCount;
    }

    public void GetNewDay()
    {
        SceneManager.LoadScene(0);
    }
}
