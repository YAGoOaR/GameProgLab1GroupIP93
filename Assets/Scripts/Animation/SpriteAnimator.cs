using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] Sprite[] frameArray;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] float duration = 5;

    [SerializeField] bool animating = false;
    [SerializeField] bool loop = false;

    float timer;
    int currentFrame;

    public delegate void callback();
    public delegate void listener(int frame);

    callback callBack;
    listener onFrame;

    public listener OnFrame { set => onFrame = value; }

    public Sprite[] FrameArray
    {
        get => frameArray;
        set => frameArray = value;
    }

    public bool Loop
    {
        get => loop;
        set => loop = value;
    }

    private float Framerate
    {
        get => duration / frameArray.Length;
    }

    public int Frames { get => frameArray.Length; }

    public int Frame
    {
        set
        {
            if (value > 1 || value < 0) return;
            currentFrame = value;
            spriteRenderer.sprite = frameArray[currentFrame];
        }
    }

    public bool isAnimating { get => animating; }

    public void PlayAnimation(Sprite[] frameArr, float duration, callback onLoopEnd = null)
    {
        onFrame = null;
        frameArray = frameArr;
        animating = true;
        currentFrame = 0;
        this.duration = duration;
        timer = Framerate;
        callBack = onLoopEnd;
    }

    public void PlayDefaultAnimation()
    {
        onFrame = null;
        animating = true;
        currentFrame = 0;
        timer = Framerate;
    }

    public void StopAnimation()
    {
        animating = false;
    }

    private void Start()
    {
        if (spriteRenderer != null) return;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!animating) return;
        timer += Time.deltaTime;
        float maxtime = Framerate;
        if(timer >= maxtime)
        {
            timer -= maxtime;
            currentFrame++;
            if (currentFrame >= Frames)
            {
                animating = loop;
                currentFrame = 0;
                timer = maxtime;
                if(callBack != null)
                {
                    callBack();
                }
            }
            if (onFrame != null)
            {
                onFrame(currentFrame);
            }
            spriteRenderer.sprite = frameArray[currentFrame];
        }
    }
}
