using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputUI : MonoBehaviour{
	
	private Vector2 touchBegan;
	private Vector2 touchEnded;
	private Vector2 sumVector;
	
	private GameObject UIObject;
	private Controler UIscript;
	
    // Start is called before the first frame update
    void Start(){
        
		UIscript = this.GetComponent<Controler>();
		
    }

    // Update is called once per frame
    void Update(){
        if (Screen.orientation==ScreenOrientation.LandscapeLeft|Screen.orientation==ScreenOrientation.LandscapeRight){
			foreach(Touch touch in Input.touches){
			
			
				//смотрим изменение в движении пальца, в зависимости от этого показываем или скрываем боковую панель
				if (touch.phase == TouchPhase.Moved){
					if (touch.deltaPosition.x<0){
					
						UIscript.changeSizeHalf();
					}
					if (touch.deltaPosition.x>0){
					
						UIscript.changeSizeFull();
					}
				}
			
			}
		}
    }
}