namespace Sharp.UI.Example;

public class PanGesturePage : ContentPage
{
    double x, y;
    private Image image;

    public PanGesturePage()
	{
		Content = new Grid
		{
			new Image("dotnet_bot.png", out image)
				.SizeRequest(100,100)
				.GestureRecognizers(new GestureRecognizer[]
				{
					new PanGestureRecognizer().OnPanUpdated(OnUpdated)
				})
		};
	}

    private void OnUpdated(PanGestureRecognizer sender, PanUpdatedEventArgs args)
    {
        switch (args.StatusType)
        {
            case GestureStatus.Running:
                image.TranslationX = x + args.TotalX;
                image.TranslationY = y + args.TotalY;
                break;

            case GestureStatus.Completed:
                x = image.TranslationX;
                y = image.TranslationY;
                break;
        }
    }
}
