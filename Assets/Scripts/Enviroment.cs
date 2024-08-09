using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Recruit;

public class Environment : Card
{
    private int resources;
    public int Resource
    {
        get { return resources; }
        protected set
        {
            resources = PreventLessThenZero(value);
        } 
    }
    
    private int cooldown;
    public int Cooldown
    { 
        get { return cooldown; } 
        protected set { cooldown = PreventLessThenZero(value); } 
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
    [Serializable] protected class StartingStatsEnviroment : StartingStats
    {
        [field: SerializeField]
        public int Resource
        { get; set; }
        [field: SerializeField]
        public int Cooldown
        { get; set; }
    }
    // Serialized member of StartingClass allows stats to be inputted in UnityEditor.
    [field: SerializeField] protected StartingStatsEnviroment StartingStatsCard
    { get; private set; }
    protected override void InitialiseStartingStats()
    {
        if (StartingStatsCard != null)
        {
            Name = StartingStatsCard.Name;
            PointCost = StartingStatsCard.PointCost;
            Description = StartingStatsCard.Description;
            Resource = StartingStatsCard.Resource;
            Cooldown = StartingStatsCard.Cooldown;
        }

        base.InitialiseStartingStats();
        ResourceText.text = $"{Resource}";
        CooldownText.text = $"{Cooldown}";
    }


    // UI related variables and methods. -------------------------------------------------------------------------------------------------------
    public TextMeshProUGUI ResourceText
    { get; protected set; }
    public TextMeshProUGUI CooldownText
    { get; protected set; }
    protected override void SetUIReferences()
    {
        base.SetUIReferences();
        ResourceText = transform.Find("Cardback/Canvas/ResourceText").GetComponent<TextMeshProUGUI>();
        CooldownText = transform.Find("Cardback/Canvas/CooldownText").GetComponent<TextMeshProUGUI>();
    }
}
