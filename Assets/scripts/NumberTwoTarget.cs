using UnityEngine;
using Vuforia;

public class NumberTwoTarget : MonoBehaviour
{
    private ObserverBehaviour mObserverBehaviour;
    public MathOperationManager mathOperationManager;

    void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            mathOperationManager.SetNumber2(2, transform);
        }
        else
        {
            mathOperationManager.SetNumber2(null, null);
        }
    }

    void Update()
    {
        if (mObserverBehaviour && (mObserverBehaviour.TargetStatus.Status == Status.TRACKED || mObserverBehaviour.TargetStatus.Status == Status.EXTENDED_TRACKED))
        {
            mathOperationManager.Evaluate();
        }
    }

    void OnDestroy()
    {
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}
