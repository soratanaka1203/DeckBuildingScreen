
using UnityEngine;

[CreateAssetMenu(menuName ="Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    public int characterID;
    public string characterName;
    public Sprite icon;
    public Sprite myp;
    public int cost;
}
