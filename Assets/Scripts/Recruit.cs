using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Recruit : Card
{
    private int attack;
    public int Attack
    {
        get { return attack; }
        protected set
        {
            attack = PreventLessThenZero(value);
        }
    }

    private int health;
    public int Health
    {
        get { return health; }
        protected set
        {
            health = PreventLessThenZero(value);
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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


    // Variables, methods and sub-class related to initial Card stats and initialising the values to the class variables. ---------------------
    [Serializable] protected class StartingStatsRecruit : StartingStats
    {
        [field: SerializeField]
        public int Attack
        { get; set; }
        [field: SerializeField]
        public int Health
        { get; set; }
    }
    // Serialized member of StartingClass allows stats to be inputted in UnityEditor.
    [field: SerializeField] protected StartingStatsRecruit StartingStatsCard
    { get; private set; }
    protected override void InitialiseStartingStats()
    {
        if (StartingStatsCard != null)
        {
            Name = StartingStatsCard.Name;
            PointCost = StartingStatsCard.PointCost;
            Description = StartingStatsCard.Description;
            Attack = StartingStatsCard.Attack;
            Health = StartingStatsCard.Health;
        }

        base.InitialiseStartingStats(); 
        AttackText.text = $"{Attack}";
        HealthText.text = $"{Health}";
    }


    // UI related variables and methods. -------------------------------------------------------------------------------------------------------
    public TextMeshProUGUI AttackText
    { get; protected set; }
    public TextMeshProUGUI HealthText
    { get; protected set; }
    protected override void SetUIReferences()
    {
        // Set UI references.
        base.SetUIReferences();
        AttackText = transform.Find("Cardback/Canvas/AttackText").GetComponent<TextMeshProUGUI>();
        HealthText = transform.Find("Cardback/Canvas/HealthText").GetComponent<TextMeshProUGUI>();
    }
}
