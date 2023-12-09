using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public int questValue;
    public TextMeshProUGUI[] questTexts;
    public Quest[] quests;
    public Toggle[] m_toggle;
    public GameObject qPanel;
    
    private void Awake()
    {
        // Bir �rnek varsa ve ben de�ilse, yoket.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        LoadQuest();
    }

    public void LoadQuest()
    {
        for (int i = 0; i < questTexts.Length; i++)
        {
            questTexts[i].color = Color.white;
            if (i == 1)
            {
                questTexts[i].text = quests[questValue].questStrings[i] + " ( " + quests[questValue].questCurrentProgress.ToString() + "/" + quests[questValue].questAim.ToString() + ")";
            }
            else
            {
                questTexts[i].text = quests[questValue].questStrings[i];
            }
        }

        StartCoroutine(NewQuest());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Deneme1();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Deneme2();
        }
    }

    public void Deneme1()
    {
        quests[questValue].isQuestOk1 = true;
        CheckQuest();
    }

    public void Deneme2()
    {
        quests[questValue].isQuestOk2 = true;
        CheckQuest();

    }
    public void CheckQuest()
    {
        //quests[questValue].CheckAim();
        if (quests[questValue].isQuestOk1)
        {
            m_toggle[0].transform.Find("Checkmark").gameObject.active = true;
            questTexts[1].color = Color.gray;
            m_toggle[1].gameObject.active = true;

            if (quests[questValue].isQuestOk2)
            {
                m_toggle[1].gameObject.active = false;
                questValue += 1;
                m_toggle[0].transform.Find("Checkmark").gameObject.active = false ;
                LoadQuest();
            }
        }



    }
    public IEnumerator NewQuest()
    {
        qPanel.active = false;
        questTexts[3].gameObject.active = true;
        yield return new WaitForSeconds(10f);
        Debug.Log("as");
        qPanel.active = true;
        questTexts[3].gameObject.active = false;


    }

}


[System.Serializable]
public class Quest
{
    public string[] questStrings;

    public bool isQuestOk1;
    public bool isQuestOk2;
    public int questCurrentProgress;
    public int questAim;

    public void CheckAim()
    {
        isQuestOk1 = questCurrentProgress >= questAim;
    }

}
