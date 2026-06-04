using CoreStoreCRM.Forms;
using CoreStoreCRM.DataAccess;

namespace CoreStoreCRM
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show("Не удается подключиться к базе данных. Проверьте строку подключения.", 
                    "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new MainForm());
        }
    }
}