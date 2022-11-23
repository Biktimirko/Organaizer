using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Notifications.Android; 

public class taskScript : MonoBehaviour{
	
	public GameObject deadlines;
    public GameObject timer;
	public GameObject done;
	public GameObject taskText;
	
	public GameObject UI;
	public Controler Controler;
	
	public int number;
	
	private string personalSaveData;
	
	
	
	// Start is called before the first frame update
    
	
	public void create(string task){
		
		UI = GameObject.Find("UI");
		Controler = UI.GetComponent<Controler>();
		
		string[] parts = task.Split("|");
		
		number=int.Parse(parts[0]);
		
		timer.GetComponent<TMP_Text>().text=parts[1];
		taskText.GetComponent<TMP_Text>().text="  "+parts[3];
		
		
		//1|00:00|10-2024-22|задача|вып|прос
		
		
		Controler.addNotification("Есть просроченная задача:", parts[3], new System.DateTime(int.Parse(parts[2].Substring(3,4)), int.Parse(parts[2].Substring(0,2)), int.Parse(parts[2].Substring(8,2)), int.Parse(parts[1].Substring(0,2)), int.Parse(parts[1].Substring(3,2)), 0));
		
		
		
		
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
	
	public void deleteTask(){
        
		if (PlayerPrefs.HasKey("SavedString")){		
			personalSaveData = PlayerPrefs.GetString("SavedString");
			string[] parts = personalSaveData.Split(System.Environment.NewLine);
			PlayerPrefs.DeleteAll();
			
			for (int a = number; a < parts.Length - 1; a++)    {
				parts[a] = parts[a + 1];
			}
			
			System.Array.Resize(ref parts, parts.Length - 1);
			
			
			foreach (string item in parts){
				if (PlayerPrefs.HasKey("SavedString")){
					personalSaveData = PlayerPrefs.GetString("SavedString");
					PlayerPrefs.SetString("SavedString", personalSaveData+System.Environment.NewLine+item);
				}else{
					PlayerPrefs.SetString("SavedString", item);
				}
			}
			
			
		}
		
		Controler.SetTaskList();
		
    }
	
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
