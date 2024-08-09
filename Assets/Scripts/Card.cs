using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public string Name
    { get; protected set; }

    private int pointCost;
    /// <summary>
    /// Point cost of the card. Any attempt to set a value below 0 returns 0.
    /// </summary>
    public int PointCost
    { 
        get { return pointCost; }
        protected set
        {
            pointCost = PreventLessThenZero(value);
        }
    }

    private string description;
    public string Description
    {
        get { return description; }
        protected set
        {
            description = value.Trim();
        }
    }

    [field: SerializeField]
    public Vector3 CardDimensions
    { get; private set; }

    public GameObject CardBack
    { get; private set; }

    public GameObject Canvas
    { get; private set; }

    protected virtual void Awake()
    {
        CardBack = transform.Find("Cardback").gameObject;
        CardDimensions = CardBack.transform.localScale;
        Canvas = transform.Find("Cardback/Canvas").gameObject;

        SetUIReferences();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        InitialiseStartingStats();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Ensures that the Cardback game object scale, and it's canvas UI child's scale, remain at the given desired CardDimensions.
        if (CardDimensions != CardBack.transform.localScale)
        { 
            CardBack.transform.localScale = CardDimensions;
        }
    }

    protected int PreventLessThenZero(int number)
    {
        return (number < 0) ? 0 : number;
    }

    protected abstract void OnPlay();

    // Variables, methods and sub-class related to initial Card stats and initialising the values to the class variables. ---------------------
    /// <summary>
    /// Abstract class representing the Starting Stats of each card. To be inherited and implemented in each other child card class to reflect the stats needed for that particular card type.
    /// </summary>
    public abstract class StartingStats
    {
        [field: SerializeField] public string Name
        { get; protected set; }
        [field: SerializeField] public int PointCost
        { get; protected set; }
        [field: SerializeField] public string Description
        { get; protected set; }
    }

    /// <summary>
    /// Method needs to be overriden by child class as it needs to take the StartingStats child of the class objects cardtype.
    /// </summary>
    protected virtual void InitialiseStartingStats()
    {
        // Inherited class should have a reference an instance of their own StartingStats child here to fill in all their own variables.

        NameText.text = $"{Name}";
        PointCostText.text = $"{PointCost}";
        DescriptionText.text = $"{Description}";
    }


    // UI related variables and methods. -------------------------------------------------------------------------------------------------------
    public TextMeshProUGUI PointCostText
    { get; protected set; }
    public TextMeshProUGUI NameText
    { get; protected set; }
    public TextMeshProUGUI DescriptionText
    { get; protected set; }
    /// <summary>
    /// Set UI references of the TextMeshProUGUI variables to the components in the relevent card object.
    /// </summary>
    protected virtual void SetUIReferences()
    {
        PointCostText = transform.Find("Cardback/Canvas/PointCostText").GetComponent<TextMeshProUGUI>();
        NameText = transform.Find("Cardback/Canvas/NameText").GetComponent<TextMeshProUGUI>();
        DescriptionText = transform.Find("Cardback/Canvas/DescriptionText").GetComponent<TextMeshProUGUI>();
    }
}
