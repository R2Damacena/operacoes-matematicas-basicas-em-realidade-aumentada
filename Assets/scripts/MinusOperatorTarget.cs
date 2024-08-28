using UnityEngine;
using Vuforia;

public class MinusOperatorTarget : MonoBehaviour
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
            mathOperationManager.SetOperation("-");
        }
        else
        {
            mathOperationManager.SetOperation(null);
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
