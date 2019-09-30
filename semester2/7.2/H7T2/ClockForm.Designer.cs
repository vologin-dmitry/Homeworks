namespace H7T2
{
    partial class Clock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clock));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Time = new System.Windows.Forms.Label();
            this.TimeZone = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.Time, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.TimeZone, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.Date, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(19, 18, 19, 18);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(396, 162);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // Time
            // 
            this.Time.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Time.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.Time, 2);
            this.Time.Location = new System.Drawing.Point(19, 0);
            this.Time.Margin = new System.Windows.Forms.Padding(19, 0, 19, 0);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(358, 89);
            this.Time.TabIndex = 0;
            this.Time.Text = "time";
            this.Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeZone
            // 
            this.TimeZone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TimeZone.AutoSize = true;
            this.TimeZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TimeZone.Location = new System.Drawing.Point(26, 100);
            this.TimeZone.Name = "TimeZone";
            this.TimeZone.Size = new System.Drawing.Size(146, 51);
            this.TimeZone.TabIndex = 1;
            this.TimeZone.Text = "(UTC+03:00) Москва, Санкт-Петербург, Волгоград";
            this.TimeZone.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Date
            // 
            this.Date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Date.Location = new System.Drawing.Point(263, 110);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(67, 31);
            this.Date.TabIndex = 2;
            this.Date.Text = "date";
            this.Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(39F, 76F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 162);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.MaximumSize = new System.Drawing.Size(750, 235);
            this.MinimumSize = new System.Drawing.Size(410, 190);
            this.Name = "Clock";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label TimeZone;
        private System.Windows.Forms.Label Date;
    }
}

