using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DateCreator : MonoBehaviour{
	
	public GameObject ContentHour;
	public GameObject ScrollHour;
	
	
	public GameObject ContentMinute;
	public GameObject ScrollMinute;
	
	public GameObject ContentMonth;
	public GameObject ScrollMonth;
	
	public GameObject ContentDate;
	public GameObject ScrollDate;
	
	public GameObject TaskTime;
	
	public GameObject ButPref;
	
	
	private List<GameObject> HourList;
	private List<GameObject> MinuteList;
	private ButSkript actionTarget;
	
	private System.DateTime MonthDate;
	
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
	bool		freeSpaceH=true;		//евли истина, то сверху и снизу будут пыстые места
	float 		SpaceInt=0;
	
		if (freeSpaceH){
			SpaceInt = inSizeH-1;
			SizeH = SizeH + SpaceInt;
		}
		
	ContentHour.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		, -(SizeH/inSizeH)+1);
	ScrollHour.GetComponent<Scrollbar>().numberOfSteps=24;
		for (int a = 0; a < (int)(SizeH-SpaceInt); a++){
			GameObject clone = Instantiate(ButPref) as GameObject;
			clone.GetComponent<RectTransform>().SetParent(ContentHour.GetComponent<RectTransform>());
			clone.GetComponent<RectTransform>().offsetMin = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().offsetMax = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,((SpaceInt/2)+a)*(1f/SizeH));
			clone.GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,((SpaceInt/2)+a)*(1f/SizeH)+(1f/SizeH));
			actionTarget =clone.GetComponent<ButSkript>();
			actionTarget.setInfo(((int)SizeH-SpaceInt-1-a)+"");
			clone.GetComponentInChildren<TMP_Text>().text=((int)SizeH-SpaceInt-1-a)+"";
			clone.GetComponent<Button>().onClick.AddListener(() => ClickHour(clone));
		}
		
	//
	//
	//Здесь заканчивается кусок скроллера как у эпл
	//
	//
		
	//Minute set
	
	float 		SizeM =60f; 		//количество объектов в списке
	float 		inSizeM=5f;			//количество одновременно показываемых объектов
	bool		freeSpaceM=true;		//евли истина, то сверху и снизу будут пыстые места
	float 		SpaceIntM=0;
	
		if (freeSpaceM){
			SpaceIntM = inSizeM-1;
			SizeM = SizeM + SpaceIntM;
		}
		
	ContentMinute.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		, -(SizeM/inSizeM)+1);
	ScrollMinute.GetComponent<Scrollbar>().numberOfSteps=60;
		for (int a = 0; a < (int)(SizeM-SpaceIntM); a++){
			GameObject clone = Instantiate(ButPref) as GameObject;
			clone.GetComponent<RectTransform>().SetParent(ContentMinute.GetComponent<RectTransform>());
			clone.GetComponent<RectTransform>().offsetMin = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().offsetMax = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,((SpaceIntM/2)+a)*(1f/SizeM));
			clone.GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,((SpaceIntM/2)+a)*(1f/SizeM)+(1f/SizeM));
			actionTarget =clone.GetComponent<ButSkript>();
			actionTarget.setInfo(((int)SizeM-SpaceIntM-1-a)+"");
			clone.GetComponentInChildren<TMP_Text>().text=((int)SizeM-SpaceIntM-1-a)+"";
			clone.GetComponent<Button>().onClick.AddListener(() => ClickHour(clone));
		}
	
	
	//Month set
	
	float 		SizeMonth =24f; 		//количество объектов в списке
	float 		inSizeMonth=5f;			//количество одновременно показываемых объектов
	bool		freeSpaceMonth=true;		//евли истина, то сверху и снизу будут пыстые места
	float 		SpaceIntMonth=0;
	 
		if (freeSpaceMonth){
			SpaceIntMonth = inSizeMonth-1;
			SizeMonth = SizeMonth + SpaceIntMonth;
		}
	
	MonthDate = System.DateTime.Now;
	ContentMonth.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		, -(SizeMonth/inSizeMonth)+1);
	ScrollMonth.GetComponent<Scrollbar>().numberOfSteps=24;
	MonthDate = MonthDate.AddMonths(24);
		for (int a = 0; a < (int)(SizeMonth-SpaceIntMonth); a++){
			GameObject clone = Instantiate(ButPref) as GameObject;
			
			clone.GetComponent<RectTransform>().SetParent(ContentMonth.GetComponent<RectTransform>());
			clone.GetComponent<RectTransform>().offsetMin = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().offsetMax = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,((SpaceIntMonth/2)+a)*(1f/SizeMonth));
			clone.GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,((SpaceIntMonth/2)+a)*(1f/SizeMonth)+(1f/SizeMonth));
			actionTarget =clone.GetComponent<ButSkript>();
			actionTarget.setInfo("");
			
			MonthDate = MonthDate.AddMonths(-1);
			clone.GetComponentInChildren<TMP_Text>().text=(MonthDate.ToString("yyyy-MM"));
			clone.GetComponent<Button>().onClick.AddListener(() => ClickHour(clone));
		}
	
	CreateDate();
	
	
	}


	public void CreateDate(){
	
	Debug.Log(ScrollMonth.GetComponent<Scrollbar>().value+"");
	
	float 		SizeDate =24f; 		//количество объектов в списке
	float 		inSizeDate=5f;			//количество одновременно показываемых объектов
	bool		freeSpaceDate=true;		//евли истина, то сверху и снизу будут пыстые места
	float 		SpaceIntDate=0;
		
		if (freeSpaceDate){
			SpaceIntDate = inSizeDate-1;
			SizeDate = SizeDate + SpaceIntDate;
		}
	
	ContentDate.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		, -(SizeDate/inSizeDate)+1);
	ScrollDate.GetComponent<Scrollbar>().numberOfSteps=24;
	
		for (int a = 0; a < (int)(SizeDate-SpaceIntDate); a++){
			GameObject clone = Instantiate(ButPref) as GameObject;
			
			clone.GetComponent<RectTransform>().SetParent(ContentDate.GetComponent<RectTransform>());
			clone.GetComponent<RectTransform>().offsetMin = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().offsetMax = new Vector2 	(0		,0);
			clone.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,((SpaceIntDate/2)+a)*(1f/SizeDate));
			clone.GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,((SpaceIntDate/2)+a)*(1f/SizeDate)+(1f/SizeDate));
			actionTarget =clone.GetComponent<ButSkript>();
			actionTarget.setInfo("");
			
			clone.GetComponent<Button>().onClick.AddListener(() => ClickHour(clone));
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
