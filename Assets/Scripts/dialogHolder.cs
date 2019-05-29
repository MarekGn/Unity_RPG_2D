using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    public string[] dialogue;
	private DialogueManager dMan;
	
	// Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {

	}

    void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
            if (!dMan.dialogActive)
            {
                if (Input.GetKeyUp(KeyCode.T))
                {
                    dMan.dialogLines = dialogue;
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
