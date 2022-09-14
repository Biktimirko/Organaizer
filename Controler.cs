using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour{
    // Start is called before the first frame update
	private float timeElapsed;
	private float interval;
	
	private int widthUI;
	private int heightUI;
	
	private int widthCL;
	private int heightCL;
	
	private bool teeck;
	private bool deviceOrientationLandscape;
		
	private GameObject clockObject;
	private Cloks scriptTarget;
	
	private GameObject canvasClock;
	private GameObject canvasInfo;
	
	private string rectUI;
	
	
	private string personalSaveData;
	public GameObject Content;
	private taskUIManager taskTarget;
	
    void Start(){
		
		//делаем привязки к объектам
		clockObject = GameObject.Find("Clock");
		canvasClock = GameObject.Find("CanvasClock");
		canvasInfo = GameObject.Find("CanvasInfo");
		teeck = true;
		
			if (Screen.orientation==ScreenOrientation.LandscapeLeft|Screen.orientation==ScreenOrientation.LandscapeRight){
				deviceOrientationLandscape = true;
				changeSizeFull();
			}else{
				deviceOrientationLandscape = false;
				changeToPortrait();
			}
			
		scriptTarget = clockObject.GetComponent<Cloks>();
		updateClock(System.DateTime.Now.ToString("HH:mm"));
		timeElapsed=0;
		interval=1;
		
		
		taskTarget=Content.GetComponent<taskUIManager>();
		
		if (PlayerPrefs.HasKey("SavedString")){
			
		personalSaveData = PlayerPrefs.GetString("SavedString");
		taskTarget.AddToList(personalSaveData);
		
		}else{
			
		taskTarget.AddToList("1|10:25|2012-05-28|у вас нет ни одного задания|вып|прос");
		PlayerPrefs.SetString("SavedString", "1|10:25|2012-05-28|тестовое задание|вып|прос");
		
		}
		
    }

    // Update is called once per frame
    void Update(){
		
		
		timeElapsed += Time.deltaTime;
	
		while (timeElapsed >= interval){
		timeElapsed = 0;
		
			if (teeck){		
			updateClock(System.DateTime.Now.ToString("HH:mm"));
			teeck = false;
			
			}else{
				teeck = true;
				updateClock(System.DateTime.Now.ToString("HH") + " " + System.DateTime.Now.ToString("mm"));
			}
			
		}
		
		
		if (deviceOrientationLandscape){
			if(Screen.orientation==ScreenOrientation.Portrait|Screen.orientation==ScreenOrientation.PortraitUpsideDown){
				deviceOrientationLandscape  = false;
				changeToPortrait();
			}
		}else{
			if (Screen.orientation==ScreenOrientation.LandscapeLeft|Screen.orientation==ScreenOrientation.LandscapeRight){
				deviceOrientationLandscape  = true;
				changeSizeFull();
			}
		}
		
		
    }
	
	private void updateClock(string date){
	
	scriptTarget.setTime(date);
	
	
	}
	
	public void changeSizeHalf(){
		
		canvasClock.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,0);
		canvasClock.GetComponent<RectTransform>().anchorMax = new Vector2 	(0.5f	,1);
		canvasInfo.GetComponent<RectTransform>().anchorMin = new Vector2 	(0.5f	,0);
		canvasInfo.GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,1);
		
	}
	
	public void changeSizeFull(){
		
		canvasClock.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,0);
		canvasClock.GetComponent<RectTransform>().anchorMax = new Vector2 	(0.9f	,1);
		canvasInfo.GetComponent<RectTransform>().anchorMin = new Vector2 	(0.9f	,0);
		canvasInfo.GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,1);
		
	}
	
	private void changeToPortrait(){
		
		canvasClock.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,0.5f);
		canvasClock.GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,1);
		canvasInfo.GetComponent<RectTransform>().anchorMin = new Vector2 	(0		,0);
		canvasInfo.GetComponent<RectTransform>().anchorMax = new Vector2 	(1		,0.5f);
		
	}
}
