using Microsoft.Extensions.Logging;

namespace CondoSphere.Mobile.Behaviors
{
    public class ImageLoadingBehavior : Behavior<Image>
    {
        private ILogger<ImageLoadingBehavior> _logger;

        protected override void OnAttachedTo(Image bindable)
        {
            base.OnAttachedTo(bindable);
            // Get the logger service
            _logger = IPlatformApplication.Current.Services.GetService<ILogger<ImageLoadingBehavior>>();

            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.Loaded += OnImageLoaded;
            bindable.Unloaded += OnImageUnloaded;
        }

        protected override void OnDetachingFrom(Image bindable)
        {
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable.Loaded -= OnImageLoaded;
            bindable.Unloaded -= OnImageUnloaded;
            base.OnDetachingFrom(bindable);
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            var image = sender as Image;
            if (image == null || image.Source == null) return;

            LogImageSource("BindingContextChanged", image.Source);
        }

        private void OnImageLoaded(object sender, EventArgs e)
        {
            var image = sender as Image;
            if (image == null) return;

            // The 'IsLoading' property tells us if the load was successful or not.
            string status = image.IsLoading ? "FAILED" : "SUCCESS";
            _logger?.LogInformation("--- IMAGE LOAD EVENT ---");
            _logger?.LogInformation($"[ImageLoadingBehavior] OnImageLoaded: Status = {status}");
            LogImageSource("OnImageLoaded", image.Source);
            _logger?.LogInformation("------------------------");
        }

        private void OnImageUnloaded(object sender, EventArgs e)
        {
            _logger?.LogInformation("[ImageLoadingBehavior] Image Unloaded.");
        }

        private void LogImageSource(string eventName, ImageSource source)
        {
            if (source is UriImageSource uriSource)
            {
                _logger?.LogInformation($"[ImageLoadingBehavior] {eventName}: UriImageSource = {uriSource.Uri}");
            }
            else if (source is FileImageSource fileSource)
            {
                _logger?.LogInformation($"[ImageLoadingBehavior] {eventName}: FileImageSource = {fileSource.File}");
            }
            else if (source is StreamImageSource)
            {
                _logger?.LogInformation($"[ImageLoadingBehavior] {eventName}: Source is a StreamImageSource.");
            }
            else
            {
                _logger?.LogInformation($"[ImageLoadingBehavior] {eventName}: Source is of type {source.GetType().Name}");
            }
        }
    }
}