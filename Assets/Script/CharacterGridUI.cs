using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class CharacterGridUI : MonoBehaviour
{
    public Transform gridParent; // Grid Layout Group�������I�u�W�F�N�g
    public GameObject characterIconPrefab;
    public List<CharacterData> ownedCharacters; // �������Ă���L����

    private List<Transform> children = new List<Transform>();// �q�I�u�W�F�N�g�̃��X�g

    void Start()
    {
        PopulateGrid();
        // �q�I�u�W�F�N�g�̃��X�g���擾
        foreach (Transform child in gridParent)
        {
            children.Add(child);
        }
    }

    private void PopulateGrid()
    {
        foreach (var character in ownedCharacters)
        {
            GameObject iconObj = Instantiate(characterIconPrefab, gridParent);
            iconObj.GetComponent<CharacterIconUI>().Setup(character);
        }
    }

    [SerializeField] TextMeshProUGUI sortButtonText;
    int pressCount = 0;
    public void OnSortButton()
    {
        switch (pressCount)
        {
            case 0:
                sortButtonText.text = "�\�[�g�F�R�X�g��";
                SortByCost();
                pressCount++;
                break;
            case 1: SortByHP();
                sortButtonText.text = "�\�[�g�FHP��";
                pressCount--;
                break;
        }       
    }

    public void SortByCost()
    {
        Sort((a, b) => a.characterData.cost.CompareTo(b.characterData.cost));
    }

    public void SortByHP()
    {
        Sort((a, b) => a.characterData.hp.CompareTo(b.characterData.hp));
    }

    private void Sort(System.Comparison<CharacterIconUI> comparison)
    {
        List<CharacterIconUI> characters = new List<CharacterIconUI>();

        foreach (Transform child in gridParent)
        {
            CharacterIconUI view = child.GetComponent<CharacterIconUI>();
            if (view != null)
            {
                characters.Add(view);
            }
        }

        characters.Sort(comparison);

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].transform.SetSiblingIndex(i);
        }
    }
}
