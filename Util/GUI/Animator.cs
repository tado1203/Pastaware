public class Animator
{
    private float Progress = 0f;

    public bool IsMaximum()
    {
        return Progress >= 1f;
    }

    public bool IsMinimum()
    {
        return Progress <= 0f;
    }

    public void IncreaseProgress(float value)
    {
        Progress += value;
        if (IsMaximum())
        {
            Progress = 1f;
        }
    }

    public void DecreaseProgress(float value)
    {
        Progress -= value;
        if (IsMinimum())
        {
            Progress = 0f;
        }
    }

    public float GetProgress()
    {
        return Progress;
    }
}