﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceScript : MonoBehaviour
{
	private static bool objectExists;
	
    // Start is called before the first frame update
    void Start () {
        if (!objectExists)
        {
            objectExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
