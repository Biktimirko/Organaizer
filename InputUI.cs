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
        
        foreach(Touch touch in Input.touches){
			
            if (touch.phase == TouchPhase.Began){
				touchBegan = touch.position;
            }
			if (touch.phase == TouchPhase.Ended){
				touchEnded = touch.position;
				
				sumVector = touchBegan + touchEnded;
				if (sumVector.x>0){
					
				UIscript.changeSizeHalf();
				}
				if (sumVector.x<0){
					
				UIscript.changeSizeFull();
				}
				
				touchEnded = Vector2.zero;
				touchBegan = Vector2.zero;
            }
			
			if (touch.phase == TouchPhase.Canceled){
				touchEnded = Vector2.zero;
				touchBegan = Vector2.zero;
            }
        }
    }
}