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
	private bool deviceOrientationСhange;
	private bool deviceOrientationLandscape;
		
	private GameObject clockObject;
	private Cloks scriptTarget;
	
	private GameObject canvasClock;
	private GameObject canvasInfo;
	
	private string rectUI;
	
	
    void Start(){
		
		//делаем привязки к объектам
		clockObject = GameObject.Find("Clock");
		canvasClock = GameObject.Find("CanvasClock");
		canvasInfo = GameObject.Find("CanvasInfo");
		teeck = true;
		deviceOrientationСhange = true;
		
			if (Screen.orientation==ScreenOrientation.LandscapeLeft|Screen.orientation==ScreenOrientation.LandscapeRight){
				deviceOrientationLandscape = true;
			}else{
				deviceOrientationLandscape = false;
			}
			
		scriptTarget = clockObject.GetComponent<Cloks>();
		updateClock(System.DateTime.Now.ToString("HH:mm"));
		timeElapsed=0;
		interval=1;
		
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
		
		canvasClock.GetComponent<RectTransform>().offsetMax = new Vector2 (0,0);
		canvasClock.GetComponent<RectTransform>().offsetMin = new Vector2 (0,0);
		canvasInfo.GetComponent<RectTransform>().offsetMin = new Vector2 (0,0);
		canvasInfo.GetComponent<RectTransform>().offsetMax = new Vector2 (0,0);
		
		canvasClock.GetComponent<RectTransform>().offsetMax = new Vector2 (-(int)this.GetComponent<RectTransform>().rect.width/2,0);
		canvasInfo.GetComponent<RectTransform>().offsetMin = new Vector2 ((int)this.GetComponent<RectTransform>().rect.width/2,0);
		
	}
	
	public void changeSizeFull(){
		
		canvasClock.GetComponent<RectTransform>().offsetMax = new Vector2 (0,0);
		canvasClock.GetComponent<RectTransform>().offsetMin = new Vector2 (0,0);
		canvasInfo.GetComponent<RectTransform>().offsetMin = new Vector2 (0,0);
		canvasInfo.GetComponent<RectTransform>().offsetMax = new Vector2 (0,0);
		
		canvasClock.GetComponent<RectTransform>().offsetMax = new Vector2 (-(int)this.GetComponent<RectTransform>().rect.width/10,0);
		canvasInfo.GetComponent<RectTransform>().offsetMin = new Vector2 ((int)this.GetComponent<RectTransform>().rect.width-((int)this.GetComponent<RectTransform>().rect.width/10),0);
		
	}
	
	private void changeToPortrait(){
		
		canvasClock.GetComponent<RectTransform>().offsetMax = new Vector2 (0,0);
		canvasClock.GetComponent<RectTransform>().offsetMin = new Vector2 (0,0);
		canvasInfo.GetComponent<RectTransform>().offsetMin = new Vector2 (0,0);
		canvasInfo.GetComponent<RectTransform>().offsetMax = new Vector2 (0,0);
		
		
		canvasClock.GetComponent<RectTransform>().offsetMin = new Vector2 (0,(int)this.GetComponent<RectTransform>().rect.height/2);
		canvasInfo.GetComponent<RectTransform>().offsetMax = new Vector2 (0,-(int)this.GetComponent<RectTransform>().rect.height/2);
		
	}
}
