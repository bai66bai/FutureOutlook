
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class CtrVideoPlayer : MonoBehaviour, IPointerClickHandler
{
    public VideoPlayer videoPlayer; // ��Ƶ���������

    private bool isPlaying = false; // ��ǰ����״̬

    public Item item;

    private GameObject pause;


    private bool isShow = false;
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

    private void Update()
    {
        if (transform.parent.localPosition != item.XLoclpostion && isShow)
        {
            CtrlResetVideo();
            isShow = false;
        }
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

    public void CtrlResetVideo()
    {
        // ��ͣ��Ƶ����
        videoPlayer.Pause();

        // ����Ƶʱ�����õ���һ֡
        videoPlayer.time = 0;

        // ������Ƶ֡
        videoPlayer.frame = 0;

        pause.SetActive(true);

        isPlaying = false;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        TogglePlayPause();
        isShow = true;
    }
}
