using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPickup : MonoBehaviour
{
	public int value;
	private PlayerHealthManager thePHM;
	
	
    // Start is called before the first frame update
    void Start()
    {
      thePHM = FindObjectOfType<PlayerHealthManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			thePHM.AddplayerCurrentHealth(value);
			Destroy(gameObject);
		}
		
	}
	
}
