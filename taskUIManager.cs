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
	
	// Start is called before the first frame update
    void Start(){
    taskList = new List<GameObject>();
	
	AddToList("1|10:25|2012-05-28|хочу по жопке|вып|прос");
	/*
	AddToList("1|10:25|2012-05-28|хочу по жопке|вып|прос");
	AddToList("1|10:25|2012-05-28|хочу по жопке|вып|прос");
	AddToList("1|10:25|2012-05-28|хочу по жопке|вып|прос");
	AddToList("1|10:25|2012-05-28|хочу по жопке|вып|прос");
	AddToList("1|10:25|2012-05-28|хочу по жопке|вып|прос");
	AddToList("1|10:25|2012-05-28|хочу по жопке|вып|прос");
	AddToList("1|10:25|2012-05-28|хочу по жопке|вып|прос");
	AddToList("1|10:25|2012-05-28|хочу по жопке|вып|прос");
	*/
    }


	public void AddToList(string task){
	
	GameObject clone = Instantiate(taskUnit) as GameObject;
	clone.GetComponent<RectTransform>().SetParent(this.GetComponent<RectTransform>());
	
	clone.GetComponent<RectTransform>().offsetMin = new Vector2 	(0		,0);
	clone.GetComponent<RectTransform>().offsetMax = new Vector2 	(0		,0);
	taskList.Add(clone);
		this.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,1-((taskList.Count)*0.2f));
			
			for (int a = 0; a < taskList.Count; a++){
				
				Debug.Log(a);
				Debug.Log(a*(1/((float)(taskList.Count))));
				Debug.Log((a+1)*(1/((float)(taskList.Count))));
				
				taskList[a].GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,(a*(1/((float)(taskList.Count))))					);
				taskList[a].GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,((a+1)*(1/((float)(taskList.Count))))				);
				Debug.Log("------");
			}
		Debug.Log("проехали");
	actionTarget =clone.GetComponent<taskScript>();
	actionTarget.create(task);
	
	
	
	}

/*
	void RectContent(){ // определение размера окна с элементами
	
		float height = delta.y * size;
		scroll.content.sizeDelta = new Vector2(scroll.content.sizeDelta.x, height);
		scroll.content.anchoredPosition = Vector2.zero;
	}
	*/
    // Update is called once per frame
    void Update()
    {
        
    }
}