using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Recruit;

public class Spell : Card
{
    [Serializable]
    protected class StartingStatsSpell : StartingStats
    {

    }

    [field: SerializeField] protected StartingStatsSpell StartingStatsCard
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
