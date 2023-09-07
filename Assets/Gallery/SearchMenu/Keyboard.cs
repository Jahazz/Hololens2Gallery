using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keyboard : MonoBehaviour
{
    [field: SerializeField]
    private UnityEvent<string> OnKeyboardCommit;
    [field: SerializeField]
    private MixedRealityKeyboardPreview KeyboardPreview;

    private MixedRealityKeyboard VirutalKeyboard;

    public void ShowKeyboard (string initialText)
    {
        VirutalKeyboard.ShowKeyboard(initialText, false);
    }

    public void Initialize ()
    {
        VirutalKeyboard = gameObject.AddComponent<MixedRealityKeyboard>();
        VirutalKeyboard.DisableUIInteractionWhenTyping = true;
    }

    protected virtual void Awake ()
    {
        Initialize();
    }

    protected virtual void OnEnable ()
    {
        AttachToEvents();
    }

    protected virtual void OnDisable ()
    {
        DetachFromEvents();
    }

    protected virtual void Update ()
    {
        if (VirutalKeyboard != null && VirutalKeyboard.Visible == true)
        {
            KeyboardPreview.Text = VirutalKeyboard.Text;
            KeyboardPreview.CaretIndex = VirutalKeyboard.CaretIndex;
        }
    }

    protected virtual void AttachToEvents ()
    {
        VirutalKeyboard.OnCommitText.AddListener(CommitText);
        VirutalKeyboard.OnShowKeyboard.AddListener(ShowPreview);
        VirutalKeyboard.OnHideKeyboard.AddListener(HidePreview);
    }

    protected virtual void DetachFromEvents ()
    {
        VirutalKeyboard.OnCommitText.RemoveListener(CommitText);
        VirutalKeyboard.OnShowKeyboard.RemoveListener(ShowPreview);
        VirutalKeyboard.OnHideKeyboard.RemoveListener(HidePreview);
    }

    private void CommitText ()
    {
        OnKeyboardCommit.Invoke(VirutalKeyboard.Text);
    }

    private void ShowPreview ()
    {
        KeyboardPreview.gameObject.SetActive(true);
    }

    private void HidePreview ()
    {
        KeyboardPreview.gameObject.SetActive(false);
    }

}
