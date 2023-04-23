using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace pgAdminSosi.Components
{
    public partial class EditConnectionForm
    {
        [Parameter]
        public string ConnectionString { get; set; }
        [Parameter]
        public Action<string> ChangeConnectionAction { get; set; }
        private YmMessageBox _messageBox;

        private bool Visible { get; set; }

        private void OnOkClick()
        {
            Regex regex = new Regex(@"Host=\S+;\s?Port=\S+;\s?User\sId=\S+;\s?Password=\S+;\s?Database=\S+;\s?");

            if(!regex.IsMatch(ConnectionString ?? string.Empty))
            {
                _messageBox.Show("Ошибка", "Строка подключения должна соответствовать регулярному выражению: " +
                    "\"Host=\\S+;\\s?Port=\\S+;\\s?User\\sId=\\S+;\\s?Password=\\S+;\\s?Database=\\S+;\\s?\"");
                return;            
            }
            ChangeConnectionAction.Invoke(ConnectionString);
            Visible = false;
        }

        public void Show()
        {
            Visible = true;

            StateHasChanged();
        }

        public void Hide()
        {
            Visible = false;

            StateHasChanged();
        }
    }
}
