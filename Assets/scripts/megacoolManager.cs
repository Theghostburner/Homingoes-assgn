using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megacoolManager : MonoBehaviour
{
    // Start is called before the first frame update
    public permissions permi;
    void Start()
    {
        Megacool.Instance.ReceivedShareOpened += (MegacoolReceivedShareOpenedEvent megacoolEvent) => {
            Debug.Log("Got event: " + megacoolEvent);
            if (megacoolEvent.IsFirstSession)
            {
                // This device has received a share and installed the
                // app for the first time
                Debug.Log("Installed from a referral from " + megacoolEvent.SenderUserId);
            }
        };
        Megacool.Instance.SentShareOpened += (MegacoolSentShareOpenedEvent megacoolEvent) => {
            Debug.Log("Got event: " + megacoolEvent);
            if (megacoolEvent.IsFirstSession)
            {
                // A share sent from this device has been opened, and
                // the receiver installed the app for the first time
                Debug.Log(megacoolEvent.ReceiverUserId + " installed the app from our referral");
            }
        };
        // Initialize the Megacool SDK. The callbacks must be
        // registered before this.
        Megacool.Instance.Start();
        Megacool.Instance.CaptureMethod = MegacoolCaptureMethod.BLIT;
    }

    public void startRec()
    {
       // permi.perm();
        Megacool.Instance.StartRecording();

    }
    public void stopRec()
    {
        Megacool.Instance.StopRecording();
    }
    public void share()
    {
        Megacool.Instance.Share();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
