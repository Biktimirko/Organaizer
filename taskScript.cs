using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class taskScript : MonoBehaviour{
	
	public GameObject deadlines;
    public GameObject timer;
	public GameObject done;
	public GameObject taskText;
	private int number;
	
	
	
	// Start is called before the first frame update
    
	
	public void create(string task){
		

		
		
		string[] parts = task.Split("|");
		
		number=int.Parse(parts[0]);
		
		timer.GetComponent<TMP_Text>().text=parts[1];
		taskText.GetComponent<TMP_Text>().text="  "+parts[3];
		
		/*
			if (parts[4]=="вып"){
				done.GetComponent<Toggle>().color = Color.green;
			}else{
				done.GetComponent<Toggle>().color = Color.gray;
			}
			
			if (parts[5]=="проц"){
				deadlines.GetComponent<Toggle>().color = Color.gray;
			}else{
				deadlines.GetComponent<Toggle>().color = Color.red;
			}
		*/
		
	}
	
	
	
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
