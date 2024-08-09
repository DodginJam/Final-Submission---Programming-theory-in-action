using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static Recruit;

public class Spell : Card
{
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
    [Serializable] protected class StartingStatsSpell : StartingStats
    {

    }
    // Serialized member of StartingClass allows stats to be inputted in UnityEditor.
    [field: SerializeField] protected StartingStatsSpell StartingStatsCard
    { get; private set; }
    protected override void InitialiseStartingStats()
    {
        if (StartingStatsCard != null)
        {
            Name = StartingStatsCard.Name;
            PointCost = StartingStatsCard.PointCost;
            Description = StartingStatsCard.Description;
        }

        base.InitialiseStartingStats();
    }


    // UI related variables and methods. -------------------------------------------------------------------------------------------------------
    protected override void SetUIReferences()
    {
        base.SetUIReferences();
    }
}
