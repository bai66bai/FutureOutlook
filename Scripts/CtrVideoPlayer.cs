
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class CtrVideoPlayer : MonoBehaviour, IPointerClickHandler
{
    public VideoPlayer videoPlayer; // 视频播放器组件

    private bool isPlaying = false; // 当前播放状态

    public Item item;

    private GameObject pause;


    private bool isShow = false;


    private Coroutine debounceCoroutine = null;
    private float debounceTime = 0.3f; // 防抖时间间隔


    // 用来触发的方法
    public void TriggerMethod()
    {
        if (debounceCoroutine != null)
        {
            StopCoroutine(debounceCoroutine);
        }
        debounceCoroutine = StartCoroutine(DebounceCoroutine());
    }

    // 防抖协程
    private IEnumerator DebounceCoroutine()
    {
        yield return new WaitForSeconds(debounceTime);
        TogglePlayPause();
        debounceCoroutine = null; // 重置协程
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
        // 确保视频一开始是暂停的
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
    /// 控制视频暂停播放
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

    //控制暂停图标显示
    private void PauseBtn(bool state)
    {
        pause.SetActive(state);
    }

    public void CtrlResetVideo()
    {
        // 暂停视频播放
        videoPlayer.Pause();

        // 将视频时间重置到第一帧
        videoPlayer.time = 0;

        // 更新视频帧
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
