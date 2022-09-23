using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DateCreator : MonoBehaviour{
	
	public GameObject ContentHour;
	public GameObject ScrollHour;
	
	
	public GameObject ContentMinute;
	public GameObject ContentMonth;
	public GameObject ContentDate;
	public GameObject TaskTime;
	
	public GameObject ButPref;
	
	
	private List<GameObject> HourList;
	private List<GameObject> MinuteList;
	private ButSkript actionTarget;
	
	// Start is called before the first frame update
	void Start(){
	Debug.Log("проехали");
	
	//Hour set
	//
	//Здесь начинается кусок скроллера как у эпл
	//
	//
	
	float 		SizeH =24f; 		//количество объектов в списке
	float 		inSizeH=5f;			//количество одновременно показываемых объектов
	bool		freeSpace=true;		//евли истина, то сверху и снизу будут пыстые места
	float 		SpaceInt=0;
	
		if (freeSpace){
			SpaceInt = inSizeH-1;
			SizeH = SizeH + SpaceInt;
		}
	
	HourList = new List<GameObject>();
	ContentHour.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		, -(SizeH/inSizeH)+1);
	ScrollHour.GetComponent<Scrollbar>().numberOfSteps=(int)SizeH;
		for (int a = 0; a < (int)(SizeH-SpaceInt); a++){
			GameObject clone = Instantiate(ButPref) as GameObject;
			clone.GetComponent<RectTransform>().SetParent(ContentHour.GetComponent<RectTransform>());
			clone.GetComponent<RectTransform>().offsetMin = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().offsetMax = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,((SpaceInt/2)+a)*(1f/SizeH));
			clone.GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,((SpaceInt/2)+a)*(1f/SizeH)+(1f/SizeH));
			actionTarget =clone.GetComponent<ButSkript>();
			actionTarget.setInfo((23-a)+"");
			clone.GetComponentInChildren<TMP_Text>().text=(23-a)+"";
			clone.GetComponent<Button>().onClick.AddListener(() => ClickHour(clone));
		}
		
	//
	//
	//Здесь заканчивается кусок скроллера как у эпл
	//
	//
		
	//Minute set
	MinuteList = new List<GameObject>();
	ContentMinute.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,-11);
		for (int a = 0; a < 60; a++){
			GameObject clone = Instantiate(ButPref) as GameObject;
			clone.GetComponent<RectTransform>().SetParent(ContentMinute.GetComponent<RectTransform>());
			clone.GetComponent<RectTransform>().offsetMin = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().offsetMax = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,a*(1f/60f));
			clone.GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,a*(1f/60f)+(1f/60f));
			actionTarget =clone.GetComponent<ButSkript>();
			actionTarget.setInfo((59-a)+"");
			clone.GetComponentInChildren<TMP_Text>().text=(59-a)+"";
			clone.GetComponent<Button>().onClick.AddListener(() => ClickMinute(clone));
		}
	}


	private void ClickMinute(GameObject obj){
		actionTarget =obj.GetComponent<ButSkript>();
		
		int Minute = int.Parse(actionTarget.getInfo());
		if (Minute<10){ 
			TaskTime.GetComponent<TMP_Text>().text="00:0"+Minute;
		}else{
			TaskTime.GetComponent<TMP_Text>().text="00:"+Minute;
		}
    }
	
	private void ClickHour(GameObject obj){
		actionTarget =obj.GetComponent<ButSkript>();
		
		int hour = int.Parse(actionTarget.getInfo());
		if (hour<10){ 
			TaskTime.GetComponent<TMP_Text>().text="0"+hour+":00";
		}else{
			TaskTime.GetComponent<TMP_Text>().text=hour+":00";
		}
	}
	// Update is called once per frame
	void Update(){
		
	}
}
