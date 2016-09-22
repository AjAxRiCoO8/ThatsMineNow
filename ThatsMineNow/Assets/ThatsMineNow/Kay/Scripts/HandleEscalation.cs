using UnityEngine;
using UnityEngine.UI;

public class HandleEscalation : MonoBehaviour
{
    [Header("Escalation Bar")]
    [SerializeField] private Image escalationBar;
    [SerializeField] private Text escalationLevel;

    [Header("Escalation Values")]
    [SerializeField] private float maxEscalation = 100;
    [SerializeField] private float maxEscalationMultiplier = 2;
    [SerializeField] private float currentEscalation = 0;

    [Header("Escalation Level")]
    [SerializeField] private int maxEscalationLevel = 10;
    [SerializeField] private int currentEscalationLevel = 1;
	
    void Start()
    {
        currentEscalation = 0;
    }

	void Update()
    {
        UpdateEscalationLevel();
        UpdateEscalationBar();
    }

    /*****************************/
    /*                           */
    /*   Update Escalation Bar   */
    /*                           */
    /*****************************/
    void UpdateEscalationBar()
    {
        escalationBar.fillAmount = currentEscalation / maxEscalation;   
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

                escalationLevel.text = currentEscalationLevel.ToString();

                maxEscalation *= maxEscalationMultiplier;
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
}
