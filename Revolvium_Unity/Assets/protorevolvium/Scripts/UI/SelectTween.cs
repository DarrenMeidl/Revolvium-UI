using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// Base Code Source: https://www.youtube.com/watch?v=u3YdlUW1nx0&list=WL&index=4&t=613s&ab_channel=SasquatchBStudios
public class SelectTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
{
    [Header("Text Animation")]
    [SerializeField] private Color defaultTextColor = Color.black;
    [SerializeField] private Color highlightedTextColor = Color.white;

    [Header("Button Animation")]
    //[SerializeField] private Color defaultButtonColor = Color.white;
    //[SerializeField] private Color highlightedButtonColor = Color.black;
    [SerializeField] private float _moveAmount = 0f;
    [SerializeField] private float _moveTime = 0.17f;
    [Range(0f, 2f), SerializeField] private float _scaleAmount = 1.2f;
    [SerializeField] private bool expandHorizontally = true;

    private TextMeshProUGUI text;
    private Vector3 _startPos;
    private Vector2 _startScale;
    private RectTransform _rectTransform;
    //private Button _button;
    void Awake()
    { // before the game starts, save our inital Rect Transform width & height
        if (GetComponentInChildren<RectTransform>(true) != null) // ensures the RectTransform component is found in inactive children
            _rectTransform = GetComponentInChildren<RectTransform>(true);
        _startScale = _rectTransform.sizeDelta;

        //UnityEngine.ColorUtility.TryParseHtmlString("#981756", out highlightedButtonColor); // hard-code specific colour
    }
    void OnEnable()
    {
        if (GetComponentInChildren<RectTransform>(true) != null) // ensures the RectTransform component is found in inactive children
            _rectTransform = GetComponentInChildren<RectTransform>(true);

        _startPos = transform.position;
        _rectTransform.sizeDelta = _startScale; // reset our size upon enable

        if (GetComponentInChildren<TextMeshProUGUI>(true) != null) // ensures the text component is found in inactive children
            text = GetComponentInChildren<TextMeshProUGUI>(true);

        text.color = defaultTextColor;
    }
    private IEnumerator MoveButton(bool startingAnimation)
    {
        Vector3 endPosition;
        Vector2 endScale;

        float elapsedTime = 0f;
        while(elapsedTime < _moveTime)
        {
            elapsedTime += Time.deltaTime;

            if (startingAnimation)
            {
                if (expandHorizontally)
                {
                    endPosition = _startPos + new Vector3(_moveAmount, 0f, 0f);
                    endScale = new Vector2(_startScale.x * _scaleAmount, _startScale.y);
                }
                else
                {
                    endPosition = _startPos + new Vector3(0f, _moveAmount, 0f);
                    endScale = new Vector2(_startScale.x, _startScale.y * _scaleAmount);
                }                
            }

            else
            {                
                endPosition = _startPos;
                endScale = _startScale;               
            }

            // Calculate the lerped amounts
            Vector3 lerpedPos = Vector3.Lerp(transform.position, endPosition, (elapsedTime / _moveTime));
            Vector2 lerpedScale = Vector2.Lerp(_rectTransform.sizeDelta, endScale, (elapsedTime / _moveTime));

            // apply position and scale
            transform.position = lerpedPos;
            _rectTransform.sizeDelta = lerpedScale;

            yield return null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
        text.color = highlightedTextColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.selectedObject = null;
        text.color = defaultTextColor;
    }

    public void OnSelect(BaseEventData eventData)
    {
        StartCoroutine(MoveButton(true));
        text.color = highlightedTextColor;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        StartCoroutine(MoveButton(false));
        text.color = defaultTextColor;
    }

    public void OnSubmit(BaseEventData eventData)
    {
        eventData.selectedObject = null; // deselect object on click
    }
}