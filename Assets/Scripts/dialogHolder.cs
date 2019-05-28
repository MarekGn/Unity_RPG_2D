using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour
{
    private DialogueManager dMan;

    private QuestManager theQM;

    public int questNumber;

    public bool startQuest;
    public bool endQuest;

    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        theQM = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.T))
            {
                if (!dMan.dialogActive)
                {
                    if (!theQM.questCompleted[questNumber])
                    {
                        if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
                        {
                            theQM.quests[questNumber].gameObject.SetActive(true);
                            theQM.quests[questNumber].StartQuest();
                            dMan.dialogLines = theQM.quests[questNumber].startQuestMsg;
                        }
                        else if (!endQuest && theQM.quests[questNumber].gameObject.activeSelf)
                        {
                            dMan.dialogLines = theQM.quests[questNumber].inProgQuestMsg;
                        }
                        else if (endQuest && theQM.quests[questNumber].gameObject.activeSelf)
                        {
                            theQM.quests[questNumber].EndQuest();
                        }
                    }
                    else
                    {
                        dMan.dialogLines = theQM.quests[questNumber].endQuestMsg;
                    }

                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }

                if (transform.parent.GetComponent<VillagerMovement>() != null)
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false;
                }
            }
        }
    }
}
