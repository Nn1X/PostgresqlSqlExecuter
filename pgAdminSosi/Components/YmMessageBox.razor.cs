using Microsoft.AspNetCore.Components;
using System;

namespace pgAdminSosi.Components
{
    public enum YmMessageBoxIcon
    {
        Info,
        Success,
        Question,
        Warning,
        Error
    }

    //TODO: переписать в виде сервиса
    public partial class YmMessageBox
    {
        [Parameter]
        public string MessageCssClass { get; set; }
        public Action OkClickAction { get; set; }

        private bool Visible { get; set; }
        private string Title { get; set; }
        private string Message { get; set; }
        private string IconClass { get; set; }

        private static string MessageBoxIconToIconClass(YmMessageBoxIcon icon) => icon switch
        {
            YmMessageBoxIcon.Info => "bi bi-info-circle-fill text-info",
            YmMessageBoxIcon.Question => "bi bi-question-circle-fill text-primary",
            YmMessageBoxIcon.Success => "bi bi-check-circle-fill text-success",
            YmMessageBoxIcon.Warning => "bi bi-exclamation-circle-fill text-warning",
            YmMessageBoxIcon.Error => "bi bi-x-circle-fill text-danger",
            _ => throw new ArgumentOutOfRangeException(nameof(icon), $"Неожиданное значение: {icon}"),
        };

        private void OnOkClick()
        {
            if(OkClickAction != null) 
                OkClickAction.Invoke();

            Visible = false;
        }

        public void Show(string title, string message, Action onOkClick = null)
        {
            Title = title;
            Message = message;
            Visible = true;
            IconClass = null;
            OkClickAction = onOkClick;

            StateHasChanged();
        }

        public void Show(string title, string message, YmMessageBoxIcon icon, Action onOkClick = null)
        {
            Title = title;
            Message = message;
            Visible = true;
            IconClass = MessageBoxIconToIconClass(icon);
            OkClickAction = onOkClick;

            StateHasChanged();
        }

        public void Hide()
        {
            Visible = false;

            StateHasChanged();
        }
    }
}
