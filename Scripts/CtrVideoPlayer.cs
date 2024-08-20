
using UnityEngine;
using UnityEngine.Video;

public class CtrVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer; // ��Ƶ���������


    private bool isPlaying = false; // ��ǰ����״̬

    private GameObject pause;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
        pause = GameObject.Find("Pause");
        videoPlayer.loopPointReached += (vp) =>
        {
            videoPlayer.time = 0;
            PauseBtn(true);
            isPlaying = false;
        };
        // ȷ����Ƶһ��ʼ����ͣ��
        videoPlayer.Pause();
        isPlaying = false;

    }
    /// <summary>
    /// ������Ƶ��ͣ����
    /// </summary>
    public void TogglePlayPause()
    {
        if (isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
        isPlaying = !isPlaying;

        PauseBtn(!isPlaying);
    }

    //������ͣͼ����ʾ
    private void PauseBtn(bool state)
    {
        pause.SetActive(state);
    }
}
