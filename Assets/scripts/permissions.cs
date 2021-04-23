using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class permissions : MonoBehaviour
{
    GameObject dialog = null;

    void Start()
    {
        perm();

    }
    public void perm()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
            dialog = new GameObject();
        }
#endif

    }
    void OnGUI()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            // The user denied permission to use the camera.
            // Display a message explaining why you need it with Yes/No buttons.
            // If the user says yes then present the request again
            // Display a dialog here.
            dialog.AddComponent<PermissionsRationaleDialog>();
            return;
        }
        else if (dialog != null)
        {
            Destroy(dialog);
        }
#endif

        // Now you can do things with the microphone
    }
}
