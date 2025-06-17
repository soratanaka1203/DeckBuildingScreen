using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CharacterIconUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image iconImage;
    [SerializeField]private TextMeshProUGUI costText;
    [SerializeField]private TextMeshProUGUI hpText;

    public CharacterData characterData;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Transform originalParent;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void Setup(CharacterData data)
    {
        characterData = data;
        iconImage.sprite = data.icon;
        costText.text = "�R�X�g�F" + data.cost;
        hpText.text = "HP:" + data.hp;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root); // UI�̈�ԏ��
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / transform.root.GetComponent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero; // ���ɖ߂��i�܂��̓X���b�g���œ������j
    }
}

