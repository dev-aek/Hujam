using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public int questValue;
    public TextMeshProUGUI questDesc;
    public TextMeshProUGUI questInfo;
    public Quest[] quests;
    public GameObject qPanel;
    private RadialMenu radialMenu;
    public GameObject[] xToggles;
    public GameObject[] xInteractivePanels;

    private void Awake()
    {
        // Bir �rnek varsa ve ben de�ilse, yoket.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        // DontDestroyOnLoad(this.gameObject);
        radialMenu = GetComponent<RadialMenu>();
    }
    private void Start()
    {
        StartCoroutine(LoadQuest());
    }

    private void Update()
    {

    }

    public void CheckQuest()
    {
        int a=0;
        for (int i = 0; i < quests.Length; i++)
        {
            quests[i].CheckAim();
            if (quests[i].isQuestOk1)
            {
                a++;
            }
            if (!quests[i].isInfo && quests[i].questCurrentProgress == 1 && i <3)
            {
                xToggles[i].SetActive(false);
                quests[i].toggle.gameObject.SetActive(true);
                quests[i].isInfo = true;
                radialMenu.isItemActive[i] = true;
                StartCoroutine(LoadInfo());
            }
        }
        if (a >= 3)
        {
            quests[3].toggle.gameObject.SetActive(true);
            if (!quests[3].isInfo)
            {
                StartCoroutine(LoadInfo());
                radialMenu.isItemActive[3] = true;
                quests[3].isInfo = true;
            }
        }
        if (a >= 4) quests[4].toggle.gameObject.SetActive(true);
        
    }
    public IEnumerator LoadQuest()
    {
        qPanel.SetActive(false);
        for (int i = 0; i < quests.Length; i++)
        {
            quests[i].SetQuest();
        }
        questDesc.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        Debug.Log("as");
        qPanel.SetActive(true);
        questDesc.gameObject.SetActive(false);
    }

    public IEnumerator LoadInfo()
    {
        
        questInfo.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        questInfo.gameObject.SetActive(false);
    }

}


[System.Serializable]
public class Quest
{
    public TextMeshProUGUI questText;
    public Toggle toggle;

    public string questStrings;
    public bool isQuestOk1;
    public int questCurrentProgress;
    public int questAim;
    public bool isInfo;


    public void CheckAim()
    {
        questText.text = questStrings + " ( " + questCurrentProgress.ToString() + "/" + questAim.ToString() + " )";

        if (questCurrentProgress >= questAim)
        {
            toggle.transform.Find("Checkmark").gameObject.active = true;
            questText.color = Color.gray;
            isQuestOk1 = true;

        }

    }

    public void SetQuest()
    {
        questText.text = questStrings + " ( " + questCurrentProgress.ToString() + "/" + questAim.ToString() + " )";

    }


}
