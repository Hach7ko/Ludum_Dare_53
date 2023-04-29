using Godot;

public partial class HUD : Control
{
	private void OnGamepad1PerformerSelected(string performer)
    {
        GetNode<Label>("Gamepad1Peformer").Text = "Gamepad1 will play:" + performer;
    }

    private void OnGamepad2PerformerSelected(string performer)
    {
        GetNode<Label>("Gamepad2Peformer").Text = "Gamepad2 will play:" + performer;
    }
//-----------------------------------------------------------------------------
    private void OnIsGameReadyToPlay(bool isGameReadyToPlay)
    {
        if(isGameReadyToPlay)
        {
            GetNode<Label>("PressToStart").Show();
        } else
        {
            GetNode<Label>("PressToStart").Hide();
        }
    }
}
