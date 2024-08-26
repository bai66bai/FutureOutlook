
using System.Collections;
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


    private Coroutine debounceCoroutine = null;
    private float debounceTime = 0.3f; // ����ʱ����


    // ���������ķ���
    public void TriggerMethod()
    {
        if (debounceCoroutine != null)
        {
            StopCoroutine(debounceCoroutine);
        }
        debounceCoroutine = StartCoroutine(DebounceCoroutine());
    }

    // ����Э��
    private IEnumerator DebounceCoroutine()
    {
        yield return new WaitForSeconds(debounceTime);
        TogglePlayPause();
        debounceCoroutine = null; // ����Э��
    }
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
        TriggerMethod();
        isShow = true;
    }
}
