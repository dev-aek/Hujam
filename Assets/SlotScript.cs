using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IDropHandler
{
    public int id;
    public MiniPuzzleControler mpCont;


    private void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
       // Debug.Log("sdas");
        
        if(eventData.pointerDrag != null)
        {
            
            

            if (eventData.pointerDrag.GetComponent<DragAndDrop>().id == id)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;

                mpCont.sayac++;



            }
           
                
            else
            {
                eventData.pointerDrag.GetComponent<DragAndDrop>().ResetPosition();
            }
            
   
        }
       
   



}
   

}
