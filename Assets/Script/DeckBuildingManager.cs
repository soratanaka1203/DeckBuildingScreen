using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeckBuildingManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI costCounterUI;
    [SerializeField] private GameObject CostOverMesage;
    public List<CharacterIconUI> partyMembers = new List<CharacterIconUI>();

    // Start is called before the first frame update
    void Start()
    {
        CostOverMesage.SetActive(false);
    }

    public void AddPartyMembers(CharacterIconUI data)
    {
        partyMembers.Add(data);
        if (CheckTotalCost()) costCounterUI.color = Color.red;
    }

    private bool CheckTotalCost()
    {
        int totalCost = 0;
        foreach (var member in partyMembers)
        {
            totalCost += member.cost;
        }

        UpdateCostCounter(totalCost);

        return totalCost > 10;   
    }

    private void UpdateCostCounter(int totalCost)
    {
        costCounterUI.text = $"コスト合計値：{totalCost}";
    }

    public void OnDecisionButton() 
    {
        if (CheckTotalCost()) CostOverMesage.SetActive(true);  
    }
}
