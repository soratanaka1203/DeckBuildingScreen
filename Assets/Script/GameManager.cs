using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterDatabase characterDatabase;
    [SerializeField] PlayerCharacterCollection playerCollection;
    [SerializeField] private CharacterGridUI characterGridUI;

    private int initialCharacterCount = 20;

    void Awake()
    {
        playerCollection.InitializeRandomCharacters(characterDatabase, initialCharacterCount);
        characterGridUI.ownedCharacters = playerCollection.ownedCharacters;
    }
}
