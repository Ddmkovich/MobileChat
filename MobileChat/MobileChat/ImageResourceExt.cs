using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System.Reflection;

namespace MobileChat
{
    [ContentProperty(nameof(Source))]
    class ImageResourceExt : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExt).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}
