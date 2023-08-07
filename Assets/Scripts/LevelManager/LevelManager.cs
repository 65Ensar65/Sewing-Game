using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int _levelIndex;

    [SerializeField] private bool IsFree;

    #region ForLevelSystem

    [SerializeField] private LevelScriptableObject[] levels;

    private LevelScriptableObject currentLevel;

    public LevelScriptableObject CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public int LevelIndex { get => PlayerPrefs.GetInt("Level"); set => PlayerPrefs.SetInt("Level", value); }

    private void Start()
    {
        levels = Resources.LoadAll<LevelScriptableObject>("Levels");
        LoadCurrentLevel();
    }

    public void OnPointerWin()
    {
        LevelIndex++;
        LoadCurrentLevel();
    }

    private void LoadCurrentLevel()
    {
        CurrentLevel = levels[LevelIndex % levels.Length];
        if (!IsFree)
        {
            // Clear existing level content if any
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            Instantiate(CurrentLevel.LevelPrefab, transform);
        }
    }

    #endregion

}
