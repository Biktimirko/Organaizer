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
		
	private GameObject clockObject;
	private Cloks scriptTarget;
	
	private GameObject canvasClock;
	
	private string rectUI;
	
	
    void Start(){
		clockObject = GameObject.Find("Clock");
		canvasClock = GameObject.Find("CanvasClock");
		scriptTarget = clockObject.GetComponent<Cloks>();
		updateClock(System.DateTime.Now.ToString("HH:mm"));
		timeElapsed=0;
		interval=5;
		
		//canvasClock.GetComponent<RectTransform>().rect.size() = new Vector2(0, 0.5f);
		//canvasClock.GetComponent<RectTransform>().localScale = new Vector2(0.5f,1f);
		
		
		
		//canvasClock.GetComponent<RectTransform>().offsetMin = new Vector2 (-(int)this.GetComponent<RectTransform>().rect.height/2,0);
		
		/*
		widthUI = (int)this.GetComponent<RectTransform>().rect.width;
		heightUI = (int)this.GetComponent<RectTransform>().rect.height;
		
		Debug.Log(widthUI+" "+heightUI);
		
		this.GetComponent<RectTransform>().rect().height = heightUI;
		*/
		
    }

    // Update is called once per frame
    void Update(){
		
		
		timeElapsed += Time.deltaTime;
	
		while (timeElapsed >= interval){
		timeElapsed -= interval;
		updateClock(System.DateTime.Now.ToString("HH:mm"));
			
			
		}
		
		
		
    }
	
	private void updateClock(string date){
	
	scriptTarget.setTime(date);
	
	}
	
	public void changeSizeHalf(){
	
	canvasClock.GetComponent<RectTransform>().offsetMax = new Vector2 (-(int)this.GetComponent<RectTransform>().rect.width/2,0);
	
	}
	
	public void changeSizeFull(){
	
	canvasClock.GetComponent<RectTransform>().offsetMax = new Vector2 (0,0);
	
	}
}
