using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Recruit : Card
{
    private int attack;
    public int Attack
    {
        get { return attack; }
        set
        {
            attack = PreventLessThenZero(value);
        }
    }

    private int health;
    public int Health
    {
        get { return health; }
        set
        {
            health = PreventLessThenZero(value);
        }
    }


    [Serializable]
    protected class StartingStatsRecruit : StartingStats
    {
        [field: SerializeField] public int Attack
        { get; set; }
        [field: SerializeField] public int Health
        { get; set; }
    }

    [field: SerializeField] protected StartingStatsRecruit StartingStatsCard
    { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // To be re-factored - just was a test to see displaying UI elements of starting stats.
        // Try and use Polymorphism for Card method that can take in UI variables and then assigns the text with the Starting stat?

        Health = StartingStatsCard.Health;
        Attack = StartingStatsCard.Attack;
        PointCost = StartingStatsCard.PointCost;

        Canvas.transform.Find("PointCostText").GetComponent<TextMeshProUGUI>().text = $"{StartingStatsCard.PointCost}";
        Canvas.transform.Find("AttackText").GetComponent<TextMeshProUGUI>().text = $"{StartingStatsCard.Attack}";
        Canvas.transform.Find("HealthText").GetComponent<TextMeshProUGUI>().text = $"{StartingStatsCard.Health}";

        // To be re-factored - end of section.
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnPlay()
    {
        throw new System.NotImplementedException();
    }
}
