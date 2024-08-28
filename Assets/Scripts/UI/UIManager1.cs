using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager2 : MonoBehaviour
{
    [Header ("Main Menu")]
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private AudioClip menuSound;

    #region Main Menu
    //Start Game
     public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    //Settings

    //Credits

   
    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }
    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion
}