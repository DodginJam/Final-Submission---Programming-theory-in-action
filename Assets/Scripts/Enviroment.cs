using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Recruit;

public class Enviroment : Card
{
    private int resources;
    public int Resource
    {
        get { return resources; }
        set
        {
            resources = PreventLessThenZero(value);
        } 
    }
    
    private int cooldown;
    public int Cooldown
    { 
        get { return cooldown; } 
        set { cooldown = PreventLessThenZero(value); } 
    }

    [Serializable]
    protected class StartingStatsEnviroment : StartingStats
    {
        [field: SerializeField] public int Resource
        { get; set; }
        [field: SerializeField] public int Cooldown
        { get; set; }
    }

    [field: SerializeField] protected StartingStatsEnviroment StartingStatsCard
    { get; private set; }

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
}
