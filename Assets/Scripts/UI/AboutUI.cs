using UnityEngine;
using UnityEngine.InputSystem;

public class AboutUI : MonoBehaviour
{
    private bool isSpaceButtonPressed = false;
    public void BackButton()
    {
        SceneController.Instance.MainMenuScene();

        isSpaceButtonPressed = false;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !isSpaceButtonPressed)
        {
            BackButton();
            isSpaceButtonPressed = true;
        }
    }
}
