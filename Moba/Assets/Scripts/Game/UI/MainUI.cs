using PiPei;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    // Use this for initialization
    public void Start()
    {
        WindowManager.Add((int)WindowId.Match, "match", typeof(MatchWindow), typeof(PiPeiBinder), typeof(UIMatch));

        WindowManager.Open((int)WindowId.Match);
    }

    // Update is called once per frame
    public void Update()
    {
    }
}
