using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Input;

namespace v2rayN.Desktop.Controls;

[TemplatePart(ElementDropDownButton, typeof(PathIcon))]
public class AutoCompleteBox : Avalonia.Controls.AutoCompleteBox
{
    private const string ElementDropDownButton = "PART_DropDownButton";

    private PathIcon? _dropDownButton;

    public PathIcon? DropDownButton
    {
        get => _dropDownButton;
        set
        {
            if (_dropDownButton != null)
            {
                _dropDownButton.Tapped -= OnDropDownButtonTapped;
            }

            _dropDownButton = value;

            if (_dropDownButton != null)
            {
                _dropDownButton.Tapped += OnDropDownButtonTapped;
            }
        }
    }

    static AutoCompleteBox()
    {
        MinimumPrefixLengthProperty.OverrideDefaultValue<AutoCompleteBox>(0);
    }

    public AutoCompleteBox()
    {
        SetCurrentValue(FilterModeProperty, AutoCompleteFilterMode.None);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {

        if (e.NameScope.Find<PathIcon>(ElementDropDownButton) is PathIcon button)
        {
            DropDownButton = button;
        }

        base.OnApplyTemplate(e);
    }

    private void OnDropDownButtonTapped(object? sender, TappedEventArgs e)
    {
        if (sender is PathIcon button && Equals(button, DropDownButton))
        {
            SetCurrentValue(IsDropDownOpenProperty, !IsDropDownOpen);
        }
    }

    public void Clear()
    {
        SetCurrentValue(SelectedItemProperty, null);
    }
}
