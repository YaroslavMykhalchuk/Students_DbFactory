namespace Students_ProviderFactory
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxDBProviders = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.comboBoxQuery = new System.Windows.Forms.ComboBox();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDBProviders
            // 
            this.comboBoxDBProviders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDBProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDBProviders.FormattingEnabled = true;
            this.comboBoxDBProviders.Items.AddRange(new object[] {
            "SqlDbConnStr",
            "MyNpgSqlDb"});
            this.comboBoxDBProviders.Location = new System.Drawing.Point(12, 12);
            this.comboBoxDBProviders.Name = "comboBoxDBProviders";
            this.comboBoxDBProviders.Size = new System.Drawing.Size(575, 23);
            this.comboBoxDBProviders.TabIndex = 0;
            this.comboBoxDBProviders.SelectedIndexChanged += new System.EventHandler(this.comboBoxDBProviders_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 123);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(776, 315);
            this.dataGridView.TabIndex = 1;
            // 
            // comboBoxQuery
            // 
            this.comboBoxQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuery.FormattingEnabled = true;
            this.comboBoxQuery.Items.AddRange(new object[] {
            "Відображати всієї інформації з таблиці зі студентами та оцінками.",
            "Відображати ПІБ усіх студентів.",
            "Відображати усіх середніх оцінок.",
            "Показати ПІБ усіх студентів з мінімальною оцінкою, більшою, ніж зазначена.",
            "Показати назви усіх предметів із мінімальними середніми оцінками. Назви предметів" +
                " мають бути унікальними.",
            "Показати мінімальну середню оцінку.",
            "Показати максимальну середню оцінку.",
            "Показати кількість студентів з мінімальною середньою оцінкою з математики.",
            "Показати кількість студентів, в яких максимальна середня оцінка з математики.",
            "Показати кількість студентів у кожній групі.",
            "Показати середню оцінку групи."});
            this.comboBoxQuery.Location = new System.Drawing.Point(12, 71);
            this.comboBoxQuery.Name = "comboBoxQuery";
            this.comboBoxQuery.Size = new System.Drawing.Size(575, 23);
            this.comboBoxQuery.TabIndex = 3;
            this.comboBoxQuery.SelectedIndexChanged += new System.EventHandler(this.comboBoxQuery_SelectedIndexChanged);
            // 
            // buttonExecute
            // 
            this.buttonExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExecute.Location = new System.Drawing.Point(652, 65);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(124, 33);
            this.buttonExecute.TabIndex = 4;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.Location = new System.Drawing.Point(652, 6);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(124, 33);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.comboBoxQuery);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.comboBoxDBProviders);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox comboBoxDBProviders;
        private DataGridView dataGridView;
        private ComboBox comboBoxQuery;
        private Button buttonExecute;
        private Button buttonConnect;
    }
}