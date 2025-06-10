
using UnityEngine;

[CreateAssetMenu(menuName ="Character/CharacterData")]
public class CharacterIconUI : ScriptableObject
{
    public int characterID;
    public string characterName;
    public Sprite icon;
    public Sprite myp;
    public int hp;
    public int cost;
}
