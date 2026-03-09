using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuData : MonoBehaviour
{
    public static MenuData Instance;
    public TextMeshProUGUI BestScore;
    public TMP_InputField PlayerName;
    public string Name;
    public string SavedName;
    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
           Name = PlayerName.text;
        }
    }
    [System.Serializable]
    class SaveData
    {
        public int highscore;
        public string name;
    }
    public void SaveHighscore(int points)
    {
        SavedName = Name;
        SaveData data = new SaveData();
        data.highscore = points;
        data.name = SavedName;
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("savefile", json);
    }
    public int LoadHighscore()
    {
        string json = PlayerPrefs.GetString("savefile", "");
        if (json != "")
        {
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            if (BestScore != null)
                //for some reason the SavedName value is diplayed as blank in the menu and in the main scene after the game is relaunched
                BestScore.text = $"Best Score : {SavedName} : {data.highscore}";
            return data.highscore;
        }
        return 0;
    }
}
