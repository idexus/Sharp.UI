using System;
namespace Sharp.UI
{
    public static class Transformations
    {
        public static Color ColorTransform(Color fromColor, Color toColor, double t)
        {
            return Color.FromRgba(fromColor.Red + t * (toColor.Red - fromColor.Red),
                               fromColor.Green + t * (toColor.Green - fromColor.Green),
                               fromColor.Blue + t * (toColor.Blue - fromColor.Blue),
                               fromColor.Alpha + t * (toColor.Alpha - fromColor.Alpha));
        }

        public static double DoubleTransform(double from, double to, double t)
        {
            return from + t * (to - from);
        }

        public static Size SizeTransform(Size from, Size to, double t)
        {
            return new Size(from.Width + t * (to.Width - from.Width), from.Height + t * (to.Height - from.Height));
        }

        public static Task<bool> AnimateAsync<T>(VisualElement element, string name, Func<double, T> transform, Action<T> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();
            element.Animate<T>(name, transform, callback, 16, length, easing, (value, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }
    }
}