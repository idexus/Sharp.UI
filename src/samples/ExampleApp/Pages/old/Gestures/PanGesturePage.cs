namespace ExampleApp;

using Sharp.UI;

public class PanGesturePage : ContentPage
{
    double x, y;

    protected override View Build()
    {
        return new Grid
		{
			new Image("dotnet_bot.png", out var image)
				.SizeRequest(150,150)
                .GestureRecognizers(new GestureRecognizer[]
                {
                    new PanGestureRecognizer()
                        .OnPanUpdated((e, args) =>
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
                        })
                })
        };
	}
}
