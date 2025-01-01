using UnityEngine;

public class LoadVideoWebGL : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer; // הקומפוננטה של VideoPlayer
    [SerializeField] private string VideoName; // שם הקובץ של הסרטון

    void Start()
    {
        // בנה את הנתיב לסרטון לפי הפלטפורמה
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, VideoName);
        
        // בדיקת הפלטפורמה
        #if UNITY_WEBGL
        // WebGL משתמש ב-URL ישיר (למשל, HTTP)
        videoPlayer.url = videoPath;
        Debug.Log("WebGL Video Path: " + videoPath);
        #else
        // עבור פלטפורמות אחרות, יש להוסיף "file://" לפני הנתיב
        videoPlayer.url = "file://" + videoPath;
        Debug.Log("Local Video Path: " + "file://" + videoPath);
        #endif

        // הכנת הסרטון
        videoPlayer.Prepare();

        // נגן את הסרטון כאשר הוא מוכן
        videoPlayer.prepareCompleted += (vp) => {
            vp.Play();
            Debug.Log("Video started playing.");
        };
    }
}
