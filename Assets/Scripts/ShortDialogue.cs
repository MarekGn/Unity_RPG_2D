﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortDialogue : MonoBehaviour
{
    public string dialogue;
	private DialogueManager dMAn;
	
	
	
	
	// Start is called before the first frame update
    void Start()
    {
        dMAn = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
	}
void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{			
			if(Input.GetKeyUp(KeyCode.Space))
			{
				dMAn.ShowBox(dialogue);
			}
		}	
    }
}
