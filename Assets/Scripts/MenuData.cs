using UnityEngine;

public class MenuData : MonoBehaviour
{
    public static MenuData Instance;
    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int highscore;
    }
}
