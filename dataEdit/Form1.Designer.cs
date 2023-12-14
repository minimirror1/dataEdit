
namespace dataEdit
{
    partial class Hikim
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.motionGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.fileDataGridView = new System.Windows.Forms.DataGridView();
            this.delayTextBox = new System.Windows.Forms.TextBox();
            this.delayBtn = new System.Windows.Forms.Button();
            this.scenarioOpen_Btn = new System.Windows.Forms.Button();
            this.scenarioSave_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.motionGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // motionGridView
            // 
            this.motionGridView.AllowUserToResizeRows = false;
            this.motionGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.motionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.motionGridView.Location = new System.Drawing.Point(12, 12);
            this.motionGridView.MultiSelect = false;
            this.motionGridView.Name = "motionGridView";
            this.motionGridView.RowTemplate.Height = 23;
            this.motionGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.motionGridView.Size = new System.Drawing.Size(776, 263);
            this.motionGridView.TabIndex = 0;
            this.motionGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.motionGridView_KeyDown);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(375, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "마지막에 추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LastAdd_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveBtn.Location = new System.Drawing.Point(713, 418);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "생성";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(10, 429);
            this.statusLabel.MaximumSize = new System.Drawing.Size(600, 12);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(38, 12);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "label1";
            // 
            // fileDataGridView
            // 
            this.fileDataGridView.AllowUserToResizeRows = false;
            this.fileDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileDataGridView.Location = new System.Drawing.Point(12, 281);
            this.fileDataGridView.MultiSelect = false;
            this.fileDataGridView.Name = "fileDataGridView";
            this.fileDataGridView.ReadOnly = true;
            this.fileDataGridView.RowTemplate.Height = 23;
            this.fileDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fileDataGridView.Size = new System.Drawing.Size(357, 136);
            this.fileDataGridView.TabIndex = 5;
            this.fileDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fileDataGridView_CellContentClick);
            // 
            // delayTextBox
            // 
            this.delayTextBox.Location = new System.Drawing.Point(375, 368);
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.Size = new System.Drawing.Size(100, 21);
            this.delayTextBox.TabIndex = 6;
            // 
            // delayBtn
            // 
            this.delayBtn.Location = new System.Drawing.Point(375, 395);
            this.delayBtn.Name = "delayBtn";
            this.delayBtn.Size = new System.Drawing.Size(75, 23);
            this.delayBtn.TabIndex = 7;
            this.delayBtn.Text = "휴식 추가";
            this.delayBtn.UseVisualStyleBackColor = true;
            this.delayBtn.Click += new System.EventHandler(this.delayBtn_Click);
            // 
            // scenarioOpen_Btn
            // 
            this.scenarioOpen_Btn.Location = new System.Drawing.Point(620, 281);
            this.scenarioOpen_Btn.Name = "scenarioOpen_Btn";
            this.scenarioOpen_Btn.Size = new System.Drawing.Size(75, 57);
            this.scenarioOpen_Btn.TabIndex = 8;
            this.scenarioOpen_Btn.Text = "시나리오\r\n불러오기";
            this.scenarioOpen_Btn.UseVisualStyleBackColor = true;
            this.scenarioOpen_Btn.Click += new System.EventHandler(this.scenarioOpen_Btn_Click);
            // 
            // scenarioSave_Btn
            // 
            this.scenarioSave_Btn.Location = new System.Drawing.Point(713, 281);
            this.scenarioSave_Btn.Name = "scenarioSave_Btn";
            this.scenarioSave_Btn.Size = new System.Drawing.Size(75, 57);
            this.scenarioSave_Btn.TabIndex = 9;
            this.scenarioSave_Btn.Text = "시나리오\r\n저장";
            this.scenarioSave_Btn.UseVisualStyleBackColor = true;
            this.scenarioSave_Btn.Click += new System.EventHandler(this.scenarioSave_Btn_Click);
            // 
            // Hikim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scenarioSave_Btn);
            this.Controls.Add(this.scenarioOpen_Btn);
            this.Controls.Add(this.delayBtn);
            this.Controls.Add(this.delayTextBox);
            this.Controls.Add(this.fileDataGridView);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.motionGridView);
            this.Name = "Hikim";
            this.Text = "HiKim";
            ((System.ComponentModel.ISupportInitialize)(this.motionGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView motionGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DataGridView fileDataGridView;
        private System.Windows.Forms.TextBox delayTextBox;
        private System.Windows.Forms.Button delayBtn;
        private System.Windows.Forms.Button scenarioOpen_Btn;
        private System.Windows.Forms.Button scenarioSave_Btn;
    }
}

