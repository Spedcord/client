using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using System;

namespace SpedcordClient.Localizer
{
    public class LocalizeExtension : MarkupExtension
    {
        public LocalizeExtension(string key)
        {
            this.Key = key;
        }

        public string Key { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var keyToUse = Key;

            var binding = new ReflectionBindingExtension($"[{keyToUse}]")
            {
                Mode = BindingMode.OneWay,
                Source = Localizer.Instance,
            };

            return binding.ProvideValue(serviceProvider);
        }
    }
}
