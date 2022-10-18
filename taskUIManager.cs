using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class taskUIManager : MonoBehaviour{
	
	//public ScrollRect scroll;
	public GameObject taskUnit;
	public int offset = 10;
	
	private Vector2 delta;
	private Vector2 e_Pos;
	
	private List<GameObject> taskList;
	private int size;
	private float curY, vPos;
	
	private taskScript actionTarget;
	private string personalSaveData;
	
	// Start is called before the first frame update
    void Start(){
    taskList = new List<GameObject>();
    }


	public void AddToList(string task, bool record){
	
	GameObject clone = Instantiate(taskUnit) as GameObject;
	clone.GetComponent<RectTransform>().SetParent(this.GetComponent<RectTransform>());
	
	clone.GetComponent<RectTransform>().offsetMin = new Vector2 	(0		,0);
	clone.GetComponent<RectTransform>().offsetMax = new Vector2 	(0		,0);
	taskList.Add(clone);
		this.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,1-((taskList.Count)*0.2f));
			
			for (int a = 0; a < taskList.Count; a++){
				
				taskList[a].GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,(a*(1/((float)(taskList.Count))))					);
				taskList[a].GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,((a+1)*(1/((float)(taskList.Count))))				);
				Debug.Log("------");
			}
			
	actionTarget =clone.GetComponent<taskScript>();
	actionTarget.create(task);
	
		if(record){
			if (PlayerPrefs.HasKey("SavedString")){
				personalSaveData = PlayerPrefs.GetString("SavedString");
				PlayerPrefs.SetString("SavedString", personalSaveData+System.Environment.NewLine+task);
			}else{
				PlayerPrefs.SetString("SavedString", task);
			}
		}
	
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}