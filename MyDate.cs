using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyDate : MonoBehaviour{
    // Start is called before the first frame update
	
    void Start(){
		
		
		this.GetComponent<TMP_Text>().text=System.DateTime.UtcNow.ToString("dd.MM.yy")+" "+System.DateTime.UtcNow.DayOfWeek.ToString().Remove(3);
	
    }

    // Update is called once per frame
    void Update(){
    }
}
