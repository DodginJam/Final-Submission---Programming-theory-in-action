using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    private int pointCost;
    /// <summary>
    /// Point cost of the card. Any attempt to set a value below 0 returns 0.
    /// </summary>
    public int PointCost
    { 
        get { return pointCost; }
        set
        {
            pointCost = PreventLessThenZero(value);
        }
    }

    [field: SerializeField]
    public Vector3 CardDimensions
    { get; private set; }

    public GameObject CardBack
    { get; private set; }

    public GameObject Canvas
    { get; private set; }

    public abstract class StartingStats
    {
        [field: SerializeField] public int PointCost
        { get; set; }
    }

    protected virtual void Awake()
    {
        CardBack = transform.Find("Cardback").gameObject;
        CardDimensions = CardBack.transform.localScale;
        Canvas = transform.Find("Cardback/Canvas").gameObject;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Ensures that the Cardback game object scale, and it's canvas UI child's scale, remain at the given desired CardDimensions.
        CardBack.transform.localScale = CardDimensions;
    }

    protected int PreventLessThenZero(int number)
    {
        return (number < 0) ? 0 : number;
    }

    protected abstract void OnPlay();
}
