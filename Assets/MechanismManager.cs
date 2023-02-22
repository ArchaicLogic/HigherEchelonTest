using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MechanismManager : MonoBehaviour
    ,IPointerClickHandler
    ,IDragHandler
    ,IPointerEnterHandler
    ,IPointerExitHandler
{
  [SerializeField] Image switchBar;
  [SerializeField] Button colorSwapButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    

    public void OnPointerClick(PointerEventData eventData)
    {
       
    
      
    }

    public void OnDrag(PointerEventData eventData)
    {
      
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
    public void FlipMyImage()
    {
        switchBar.transform.eulerAngles = new Vector3(0, 0, 135);
    }
}
