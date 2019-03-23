using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FloatingNumbers : MonoBehaviour
{

    public float riseSpeed;
    public int damageNumber;
    public Text displayNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayNumber.text = "" + damageNumber;
        transform.position = new Vector3(transform.position.x, transform.position.y + (riseSpeed * Time.deltaTime), transform.position.z);
         
        
    }
}
