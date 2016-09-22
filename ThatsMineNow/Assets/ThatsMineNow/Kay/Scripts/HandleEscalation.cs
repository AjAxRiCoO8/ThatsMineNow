using UnityEngine;
using UnityEngine.UI;

public class HandleEscalation : MonoBehaviour
{
    [Header("Escalation Bar")]
    [Tooltip("The image of the escalation bar")]
    [SerializeField] private Image escalationBar;
    [Tooltip("The text for the escalation level")]
    [SerializeField] private Text escalationLevel;

    [Header("Escalation Values")]
    [Tooltip("The maximum value of escalation")]
    [SerializeField] private float maxEscalation = 100.0f;
    [Tooltip("The multiplier of the maximum escalation when the escalation level goes up")]
    [SerializeField] private float maxEscalationMultiplier = 2.0f;
    [Tooltip("The current value of escalation")]
    [SerializeField] private float currentEscalation = 0.0f;

    [Header("Escalation Level")]
    [Tooltip("The maximum level of escalation")]
    [SerializeField] private int maxEscalationLevel = 10;
    [Tooltip("The current level of escalation")]
    [SerializeField] private int currentEscalationLevel = 1;

    [Header("Segments")]
    [Tooltip("The values of all the segments, which decide when the bar is in the segment")]
    [SerializeField] private float[] segments = { 0, 0, 0, 0 };
    [Tooltip("The current segment which the bar is in")]
    [SerializeField] private int currentSegment = 1;

    [Header("Reduction")]
    [Tooltip("If the player attacks, reset the time till reduction to the reduction time")]
    [SerializeField] private float reductionTime = 3.0f;
    [Tooltip("The time till it start reducing the escalation")]
    [SerializeField] private float timeTillReduction = 0.0f;
    [Tooltip("The higher the reduction scale, the faster the reduction of the escalation bar")]
    [SerializeField] private float reductionScale = 0.5f;

	
    void Start()
    {
        currentEscalation = 0;

        segments[0] = 0;
        segments[1] = (maxEscalation / 4) * 1;
        segments[2] = (maxEscalation / 4) * 2;
        segments[3] = (maxEscalation / 4) * 3;

        timeTillReduction = reductionTime;
    }

	void Update()
    {
        UpdateEscalationLevel();
        UpdateEscalationBar();
        UpdateReductionTimers();

        //Player attacks ( DEBUGGING)
        if (Input.GetKeyDown(KeyCode.X))
        {
            currentEscalation += 5;
            timeTillReduction = reductionTime;
        }
    }

    /*****************************/
    /*                           */
    /*   Update Escalation Bar   */
    /*                           */
    /*****************************/
    void UpdateEscalationBar()
    {
        escalationBar.fillAmount = currentEscalation / maxEscalation;

        if (currentEscalation > segments[3]) { currentSegment = 4; }
        else if (currentEscalation > segments[2] && currentSegment < 4) { currentSegment = 3; }
        else if (currentEscalation > segments[1] && currentSegment < 3) { currentSegment = 2; }
        else if (currentEscalation >= segments[0] && currentSegment < 2) { currentSegment = 1; }
    }

    /*******************************/
    /*                             */
    /*   Update Escalation Level   */
    /*                             */
    /*******************************/
    void UpdateEscalationLevel()
    {
        if (currentEscalationLevel < maxEscalation)
        {
            if (currentEscalation > maxEscalation)
            {
                currentEscalation = 0;
                currentEscalationLevel++;
                currentSegment = 1;

                escalationLevel.text = currentEscalationLevel.ToString();

                maxEscalation *= maxEscalationMultiplier;
                UpdateSegments();
            }
        }
    }

    /***********************/
    /*                     */
    /*   Update Segments   */
    /*                     */
    /***********************/
    void UpdateSegments()
    {
        segments[0] = 0;
        segments[1] = (maxEscalation / 4) * 1;
        segments[2] = (maxEscalation / 4) * 2;
        segments[3] = (maxEscalation / 4) * 3;
    }

    /*******************************/
    /*                             */
    /*   Update Reduction Timers   */
    /*                             */
    /*******************************/
    void UpdateReductionTimers()
    {
        timeTillReduction -= Time.deltaTime;

        if (timeTillReduction < 0)
        {
            if (currentEscalation > segments[currentSegment - 1])
            {
                currentEscalation -= Time.deltaTime * reductionScale;
            }
        }
    }

    /***************************/
    /*                         */
    /*   Getters and Setters   */
    /*                         */
    /***************************/
    /***          UI         ***/
    public Image EscalationBar
    {
        get { return escalationBar; }
    }

    public Text EscalationText
    {
        get { return escalationLevel; }
    }

    /***      Max Values      ***/
    public int MaxEscalationLevel
    {
        get { return maxEscalationLevel; }
    }

    public float MaxEscalation
    {
        get { return maxEscalation; }
    }

    public float MaxEscalationMultiplier
    {
        get { return maxEscalationMultiplier; }
    }

    public float[] Segments
    {
        get { return segments; }
    }

    /***    Current Values    ***/
    public float CurrentEscalation
    {
        get { return currentEscalation; }
        set { currentEscalation = value; }
    }

    public int CurrentEscalationLevel
    {
        get { return currentEscalationLevel; }
        set { currentEscalationLevel = value; }
    }

    public int CurrentSegment
    {
        get { return currentSegment; }
        set { currentSegment = value; }
    }

    /***       Reduction       ***/
    public float ReductionTime
    {
        get { return reductionTime; }
        set { reductionTime = value; }
    }

    public float TimeTillReduction
    {
        get { return timeTillReduction; }
    }

    public float ReductionScale
    {
        get { return reductionScale; }
        set { reductionScale = value; }
    }
}
