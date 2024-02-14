using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{                                                       // to figure out the start and the end of the user's touch
    private Image joyStickBG;
    private Image joyStick;
    private Vector2 posInput;
    // Start is called before the first frame update
    void Start()
    {
        joyStickBG = GetComponent<Image>();
        joyStick = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joyStickBG.rectTransform, eventData.position, eventData.pressEventCamera, out posInput))
        {
            posInput.x = posInput.x / (joyStickBG.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (joyStickBG.rectTransform.sizeDelta.y);
            Debug.Log(posInput.x.ToString() + "/" + posInput.y.ToString());

            // normalize
            if(posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }

            // joystick move
            joyStick.rectTransform.anchoredPosition = new Vector2(posInput.x * (joyStickBG.rectTransform.sizeDelta.x / 3), posInput.y * (joyStickBG.rectTransform.sizeDelta.y / 3)); //makin kecil angka yang dibagi makin jauh jarak center
        }
    }

    //These two voids are mechanism for the what is it.. tombol tengah gerak? to like pindah to tengah u know
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        joyStick.rectTransform.anchoredPosition = Vector2.zero;
    }

    // buat kirim signal movement variable mechanism ke playa sekerip
    public float inputHorizontal()
    {
        if (posInput.x != 0)
            return posInput.x;
        else
            return Input.GetAxis("Horizontal");
    }
    public float inputVertical()
    {
        if (posInput.y != 0)
            return posInput.y;
        else
            return Input.GetAxis("Vertical");
    }
}
