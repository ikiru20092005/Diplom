using System.Drawing;

namespace CoreStoreCRM.Forms
{
    public partial class KnowledgeBaseForm : Form
    {
        private Color PrimaryBlue = Color.FromArgb(0, 120, 212);
        private Color DarkGray = Color.FromArgb(64, 64, 64);
        private Color LightGray = Color.FromArgb(240, 240, 240);

        public KnowledgeBaseForm()
        {
            InitializeComponent();
        }

        private void KnowledgeBaseForm_Load(object sender, EventArgs e)
        {
            this.Text = "CoreStore CRM - База знаний";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(900, 700);
            this.BackColor = LightGray;
            this.Font = new Font("Segoe UI", 10);

            InitializeUI();
            LoadKnowledgeBase();
        }

        private void InitializeUI()
        {
            // Создаем панель заголовка
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 60;
            headerPanel.BackColor = PrimaryBlue;

            Label titleLabel = new Label();
            titleLabel.Text = "Часто задаваемые вопросы";
            titleLabel.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Padding = new Padding(20);
            titleLabel.Dock = DockStyle.Left;

            headerPanel.Controls.Add(titleLabel);
            this.Controls.Add(headerPanel);

            // Создаем TreeView для категорий
            TreeView treeView = new TreeView();
            treeView.Dock = DockStyle.Left;
            treeView.Width = 250;
            treeView.BackColor = Color.White;
            treeView.Font = new Font("Segoe UI", 10);
            treeView.NodeMouseClick += TreeView_NodeMouseClick;
            this.Controls.Add(treeView);

            // Создаем RichTextBox для контента
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "contentTextBox";
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.ReadOnly = true;
            richTextBox.BackColor = Color.White;
            richTextBox.Font = new Font("Segoe UI", 11);
            this.Controls.Add(richTextBox);

            // Добавляем категории в TreeView
            TreeNode category1 = new TreeNode("О компании");
            category1.Nodes.Add(new TreeNode("Кто мы?"));
            category1.Nodes.Add(new TreeNode("История"));
            category1.Nodes.Add(new TreeNode("Лицензии и сертификаты"));

            TreeNode category2 = new TreeNode("Товары");
            category2.Nodes.Add(new TreeNode("Гарантия на товары"));
            category2.Nodes.Add(new TreeNode("Возврат товара"));
            category2.Nodes.Add(new TreeNode("Доставка"));

            TreeNode category3 = new TreeNode("Аккаунт");
            category3.Nodes.Add(new TreeNode("Как создать аккаунт?"));
            category3.Nodes.Add(new TreeNode("Как изменить пароль?"));
            category3.Nodes.Add(new TreeNode("Как восстановить пароль?"));

            TreeNode category4 = new TreeNode("Технические вопросы");
            category4.Nodes.Add(new TreeNode("Какие браузеры поддерживаются?"));
            category4.Nodes.Add(new TreeNode("Контактная информация"));

            treeView.Nodes.Add(category1);
            treeView.Nodes.Add(category2);
            treeView.Nodes.Add(category3);
            treeView.Nodes.Add(category4);

            // Устанавливаем обработчик для отображения контента
            TreeView = treeView;
        }

        public TreeView TreeView { get; set; }

        private void LoadKnowledgeBase()
        {
            // Демо контент - в реальном приложении это будет из БД
        }

        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RichTextBox contentBox = this.Controls["contentTextBox"] as RichTextBox;
            if (contentBox == null) return;

            // Очищаем предыдущий контент
            contentBox.Clear();

            // Определяем контент на основе выбранного узла
            string nodeText = e.Node.Text;
            string content = GetKnowledgeContent(nodeText);

            contentBox.Text = content;
        }

        private string GetKnowledgeContent(string topic)
        {
            return topic switch
            {
                "Кто мы?" => "CoreStore CRM - это платформа для управления отношениями с клиентами, специализирующаяся на продаже ноутбуков и периферийных устройств. Мы предоставляем интегрированное решение для обработки заказов, управления обращениями клиентов и аналитики продаж.",

                "История" => "CoreStore CRM была основана в 2023 году с целью упростить управление продажами и взаимодействием с клиентами. За короткое время мы стали ведущим решением в своей категории.",

                "Лицензии и сертификаты" => "CoreStore CRM имеет все необходимые лицензии для работы с данными клиентов. Наша платформа соответствует стандартам безопасности информации и защиты данных.",

                "Гарантия на товары" => "Все товары в CoreStore имеют гарантию производителя. Стандартная гарантия составляет 2 года с момента покупки. При выходе товара из строя в течение гарантийного срока вы можете обратиться в наш отдел обслуживания.",

                "Возврат товара" => "Товар можно вернуть в течение 14 дней с момента покупки, если он находится в оригинальной упаковке и не использовался. Процесс возврата: 1) Создайте обращение 2) Отправьте товар 3) Получите возврат средств.",

                "Доставка" => "Мы предоставляем доставку по всей России. Стандартная доставка занимает 5-7 рабочих дней. Срочная доставка доступна в крупных городах (1-2 дня). Доставка рассчитывается на основании веса товара и расстояния.",

                "Как создать аккаунт?" => "Для создания аккаунта: 1) Нажмите на кнопку 'Регистрация' 2) Введите ваше имя, email и номер телефона 3) Установите пароль 4) Подтвердите регистрацию. Ваш аккаунт готов!",

                "Как изменить пароль?" => "Для изменения пароля: 1) Перейдите в 'Профиль' 2) Нажмите 'Изменить пароль' 3) Введите текущий пароль 4) Введите новый пароль дважды 5) Сохраните изменения.",

                "Как восстановить пароль?" => "Если вы забыли пароль: 1) На странице входа нажмите 'Забыли пароль?' 2) Введите ваш email 3) Проверьте почту на наличие письма со ссылкой восстановления 4) Перейдите по ссылке и установите новый пароль.",

                "Какие браузеры поддерживаются?" => "CoreStore CRM поддерживает все современные браузеры: Chrome, Firefox, Safari, Edge. Рекомендуется использовать последние версии браузеров для лучшей совместимости и безопасности.",

                "Контактная информация" => "Email: support@corestorecrm.ru\nТелефон: +7 (495) 123-45-67\nАдрес: г. Москва, ул. Примерная, д. 1\nОперативное время: Пн-Пт 9:00-18:00 (МСК)",

                _ => "Информация по этой теме не найдена. Пожалуйста, свяжитесь с поддержкой."
            };
        }
    }
}
