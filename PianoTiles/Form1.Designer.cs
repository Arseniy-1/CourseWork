namespace PianoTiles
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.HeartView1 = new System.Windows.Forms.PictureBox();
            this.HeartView3 = new System.Windows.Forms.PictureBox();
            this.HeartView2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HeartView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeartView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeartView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick_1);
            // 
            // HeartView1
            // 
            this.HeartView1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.HeartView1.Image = ((System.Drawing.Image)(resources.GetObject("HeartView1.Image")));
            this.HeartView1.InitialImage = ((System.Drawing.Image)(resources.GetObject("HeartView1.InitialImage")));
            this.HeartView1.Location = new System.Drawing.Point(12, 12);
            this.HeartView1.Name = "HeartView1";
            this.HeartView1.Size = new System.Drawing.Size(50, 50);
            this.HeartView1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HeartView1.TabIndex = 1;
            this.HeartView1.TabStop = false;
            // 
            // HeartView3
            // 
            this.HeartView3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.HeartView3.Image = ((System.Drawing.Image)(resources.GetObject("HeartView3.Image")));
            this.HeartView3.InitialImage = ((System.Drawing.Image)(resources.GetObject("HeartView3.InitialImage")));
            this.HeartView3.Location = new System.Drawing.Point(142, 12);
            this.HeartView3.Name = "HeartView3";
            this.HeartView3.Size = new System.Drawing.Size(50, 50);
            this.HeartView3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HeartView3.TabIndex = 2;
            this.HeartView3.TabStop = false;
            // 
            // HeartView2
            // 
            this.HeartView2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.HeartView2.Image = ((System.Drawing.Image)(resources.GetObject("HeartView2.Image")));
            this.HeartView2.InitialImage = ((System.Drawing.Image)(resources.GetObject("HeartView2.InitialImage")));
            this.HeartView2.Location = new System.Drawing.Point(77, 12);
            this.HeartView2.Name = "HeartView2";
            this.HeartView2.Size = new System.Drawing.Size(50, 50);
            this.HeartView2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HeartView2.TabIndex = 3;
            this.HeartView2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.InitialImage = null;
            this.pictureBox4.Location = new System.Drawing.Point(0, -3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(204, 77);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(204, 656);
            this.Controls.Add(this.HeartView1);
            this.Controls.Add(this.HeartView2);
            this.Controls.Add(this.HeartView3);
            this.Controls.Add(this.pictureBox4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeartView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeartView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeartView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox HeartView1;
        private System.Windows.Forms.PictureBox HeartView3;
        private System.Windows.Forms.PictureBox HeartView2;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

