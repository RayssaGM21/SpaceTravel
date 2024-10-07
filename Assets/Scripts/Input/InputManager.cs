public class InputManager
{
    private PlayerControls playerControls;

    public float Movement =>
        playerControls.GamePlay.Movement.ReadValue<float>();
           

    public InputManager()
    {
        playerControls = new PlayerControls();
        playerControls.GamePlay.Enable();

    }
}
