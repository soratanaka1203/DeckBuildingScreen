using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]private DeckBuildingManager _deckBuildingManager;
    [SerializeField]private Image iconImage;
   
    public void OnDrop(PointerEventData eventData)
    {
        CharacterIconUI characterIcon = eventData.pointerDrag.GetComponent<CharacterIconUI>();
        if (characterIcon != null)
        {
            AssignCharacter(characterIcon.characterData);
            // �h���b�O���i�����L�����ꗗ�j����폜
            characterIcon.gameObject.SetActive(false);
        }
    }

    private void AssignCharacter(CharacterData character)
    {
        _deckBuildingManager.AddPartyMembers(character);
        iconImage.sprite = character.myp;
        iconImage.enabled = true;
    }
}
