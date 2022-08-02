namespace ChisloIzm
{
    partial class examForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(examForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.timeTXT = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbAnswer = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.PictureBox();
            this.pn = new System.Windows.Forms.Panel();
            this.pbQuest = new System.Windows.Forms.PictureBox();
            this.pbTimer = new System.Windows.Forms.PictureBox();
            this.btnQuest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.pn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(624, 602);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 39);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // timeTXT
            // 
            this.timeTXT.Interval = 1000;
            this.timeTXT.Tick += new System.EventHandler(this.timeTXT_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 138);
            this.panel1.TabIndex = 54;
            // 
            // lbAnswer
            // 
            this.lbAnswer.AutoSize = true;
            this.lbAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAnswer.Location = new System.Drawing.Point(12, 54);
            this.lbAnswer.Name = "lbAnswer";
            this.lbAnswer.Size = new System.Drawing.Size(124, 17);
            this.lbAnswer.TabIndex = 2;
            this.lbAnswer.Text = "Введіть відповідь:";
            // 
            // txtAnswer
            // 
            this.txtAnswer.BackColor = System.Drawing.SystemColors.Info;
            this.txtAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAnswer.ForeColor = System.Drawing.Color.Blue;
            this.txtAnswer.Location = new System.Drawing.Point(15, 72);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(162, 26);
            this.txtAnswer.TabIndex = 3;
            // 
            // btnAnswer
            // 
            this.btnAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAnswer.Image = ((System.Drawing.Image)(resources.GetObject("btnAnswer.Image")));
            this.btnAnswer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnswer.Location = new System.Drawing.Point(15, 104);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(162, 37);
            this.btnAnswer.TabIndex = 4;
            this.btnAnswer.Text = "Відповідь";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(3, 3);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(100, 100);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // pn
            // 
            this.pn.AutoScroll = true;
            this.pn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn.Controls.Add(this.pb);
            this.pn.Location = new System.Drawing.Point(9, 154);
            this.pn.Name = "pn";
            this.pn.Size = new System.Drawing.Size(731, 442);
            this.pn.TabIndex = 49;
            this.pn.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_Paint);
            // 
            // pbQuest
            // 
            this.pbQuest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbQuest.Location = new System.Drawing.Point(183, 10);
            this.pbQuest.Name = "pbQuest";
            this.pbQuest.Size = new System.Drawing.Size(556, 137);
            this.pbQuest.TabIndex = 52;
            this.pbQuest.TabStop = false;
            // 
            // pbTimer
            // 
            this.pbTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTimer.Location = new System.Drawing.Point(639, 10);
            this.pbTimer.Name = "pbTimer";
            this.pbTimer.Size = new System.Drawing.Size(100, 22);
            this.pbTimer.TabIndex = 53;
            this.pbTimer.TabStop = false;
            // 
            // btnQuest
            // 
            this.btnQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnQuest.Image = ((System.Drawing.Image)(resources.GetObject("btnQuest.Image")));
            this.btnQuest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuest.Location = new System.Drawing.Point(15, 17);
            this.btnQuest.Name = "btnQuest";
            this.btnQuest.Size = new System.Drawing.Size(162, 38);
            this.btnQuest.TabIndex = 1;
            this.btnQuest.Text = "     Розпочати тест";
            this.btnQuest.UseVisualStyleBackColor = true;
            this.btnQuest.Click += new System.EventHandler(this.btnQuest_Click);
            // 
            // examForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 648);
            this.Controls.Add(this.btnQuest);
            this.Controls.Add(this.pbTimer);
            this.Controls.Add(this.pbQuest);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pn);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lbAnswer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "examForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестування";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.examForm_FormClosed);
            this.Load += new System.EventHandler(this.examForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.pn.ResumeLayout(false);
            this.pn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTimer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Timer timeTXT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbAnswer;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Panel pn;
        private System.Windows.Forms.PictureBox pbQuest;
        private System.Windows.Forms.PictureBox pbTimer;
        private System.Windows.Forms.Button btnQuest;
    }
}