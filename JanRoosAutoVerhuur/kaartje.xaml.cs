namespace JanRoosAutoVerhuur;

public partial class Kaartje : ContentView
{
    public Kaartje()
    {
        InitializeComponent();
        SizeChanged += OnSizeChanged;
    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
        // Force square shape
        CardBorder.HeightRequest = Width;
    }
}
