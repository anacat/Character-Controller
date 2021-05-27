using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler //interface que nos permite verificar quando o rato entra num objecto da UI 
{
    public UnityEvent OnHighlighted;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(OnHighlighted != null)
        {
            OnHighlighted.Invoke();
        }
    }
}
