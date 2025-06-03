using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Character Database")]
public class CharacterDatabase : ScriptableObject
{
    public List<CharacterData> characterList;
}
