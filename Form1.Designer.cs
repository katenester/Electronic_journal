
namespace DBkp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учетПосещенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учетПреподавателейИДисциплинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учетУспеваемостиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рейтингСтудентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокНеуспевающихСтудентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.учетToolStripMenuItem,
            this.запросыToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // учетToolStripMenuItem
            // 
            this.учетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.учетПосещенияToolStripMenuItem,
            this.учетПреподавателейИДисциплинToolStripMenuItem,
            this.учетУспеваемостиToolStripMenuItem});
            this.учетToolStripMenuItem.Name = "учетToolStripMenuItem";
            this.учетToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.учетToolStripMenuItem.Text = "Учет";
            // 
            // учетПосещенияToolStripMenuItem
            // 
            this.учетПосещенияToolStripMenuItem.Name = "учетПосещенияToolStripMenuItem";
            this.учетПосещенияToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.учетПосещенияToolStripMenuItem.Text = "Учет посещения";
            this.учетПосещенияToolStripMenuItem.Click += new System.EventHandler(this.учетПосещенияToolStripMenuItem_Click);
            // 
            // учетПреподавателейИДисциплинToolStripMenuItem
            // 
            this.учетПреподавателейИДисциплинToolStripMenuItem.Name = "учетПреподавателейИДисциплинToolStripMenuItem";
            this.учетПреподавателейИДисциплинToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.учетПреподавателейИДисциплинToolStripMenuItem.Text = "Учет преподавателей и дисциплин";
            this.учетПреподавателейИДисциплинToolStripMenuItem.Click += new System.EventHandler(this.учетПреподавателейИДисциплинToolStripMenuItem_Click);
            // 
            // учетУспеваемостиToolStripMenuItem
            // 
            this.учетУспеваемостиToolStripMenuItem.Name = "учетУспеваемостиToolStripMenuItem";
            this.учетУспеваемостиToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.учетУспеваемостиToolStripMenuItem.Text = "Учет успеваемости";
            this.учетУспеваемостиToolStripMenuItem.Click += new System.EventHandler(this.учетУспеваемостиToolStripMenuItem_Click);
            // 
            // запросыToolStripMenuItem
            // 
            this.запросыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.рейтингСтудентовToolStripMenuItem,
            this.списокНеуспевающихСтудентовToolStripMenuItem});
            this.запросыToolStripMenuItem.Name = "запросыToolStripMenuItem";
            this.запросыToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.запросыToolStripMenuItem.Text = "Запросы";
            // 
            // рейтингСтудентовToolStripMenuItem
            // 
            this.рейтингСтудентовToolStripMenuItem.Name = "рейтингСтудентовToolStripMenuItem";
            this.рейтингСтудентовToolStripMenuItem.Size = new System.Drawing.Size(332, 26);
            this.рейтингСтудентовToolStripMenuItem.Text = "Рейтинг студента по дисциплинам";
            this.рейтингСтудентовToolStripMenuItem.Click += new System.EventHandler(this.рейтингСтудентовToolStripMenuItem_Click);
            // 
            // списокНеуспевающихСтудентовToolStripMenuItem
            // 
            this.списокНеуспевающихСтудентовToolStripMenuItem.Name = "списокНеуспевающихСтудентовToolStripMenuItem";
            this.списокНеуспевающихСтудентовToolStripMenuItem.Size = new System.Drawing.Size(332, 26);
            this.списокНеуспевающихСтудентовToolStripMenuItem.Text = "Учебный рейтинг";
            this.списокНеуспевающихСтудентовToolStripMenuItem.Click += new System.EventHandler(this.списокНеуспевающихСтудентовToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "БД для электронного журнала";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учетПосещенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учетПреподавателейИДисциплинToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учетУспеваемостиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запросыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рейтингСтудентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокНеуспевающихСтудентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

