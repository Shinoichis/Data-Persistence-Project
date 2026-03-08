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
        SaveData data = new SaveData();
        data.highscore = points;
        data.name = Name;
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("savefile", json);
    }
    public int LoadHighscore()
    {
        string json = PlayerPrefs.GetString("savefile", "");
        if (json != "")
        {
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestScore.text = $"Best Score : {data.name} : {data.highscore}";
            return data.highscore;
        }
        return 0;
    }
}
