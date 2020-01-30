namespace CANalyst
{
    public partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStartCan = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.初始化CAN参数 = new System.Windows.Forms.GroupBox();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTime1 = new System.Windows.Forms.TextBox();
            this.txtTime0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccMask = new System.Windows.Forms.TextBox();
            this.txtAccCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCanIndex = new System.Windows.Forms.ComboBox();
            this.cboDevIndex = new System.Windows.Forms.ComboBox();
            this.cboDeviceType = new System.Windows.Forms.ComboBox();
            this.lblCanIndex = new System.Windows.Forms.Label();
            this.lblDevIndex = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFrameID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSendCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSendInterval = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFrameCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboSendType = new System.Windows.Forms.ComboBox();
            this.cboFrameFormat = new System.Windows.Forms.ComboBox();
            this.cboFrameType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timerDisplay = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnScroll = new System.Windows.Forms.Button();
            this.btnAutoScroll = new System.Windows.Forms.Button();
            this.btnWatch = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.初始化CAN参数.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnStartCan);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.初始化CAN参数);
            this.groupBox1.Controls.Add(this.cboCanIndex);
            this.groupBox1.Controls.Add(this.cboDevIndex);
            this.groupBox1.Controls.Add(this.cboDeviceType);
            this.groupBox1.Controls.Add(this.lblCanIndex);
            this.groupBox1.Controls.Add(this.lblDevIndex);
            this.groupBox1.Controls.Add(this.lblDevice);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(971, 252);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备参数";
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = true;
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(791, 179);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(144, 40);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "复位Can";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStartCan
            // 
            this.btnStartCan.AutoSize = true;
            this.btnStartCan.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartCan.Location = new System.Drawing.Point(791, 120);
            this.btnStartCan.Name = "btnStartCan";
            this.btnStartCan.Size = new System.Drawing.Size(144, 40);
            this.btnStartCan.TabIndex = 20;
            this.btnStartCan.Text = "启动Can";
            this.btnStartCan.UseVisualStyleBackColor = true;
            this.btnStartCan.Click += new System.EventHandler(this.btnStartCan_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.Location = new System.Drawing.Point(791, 37);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(144, 40);
            this.btnConnect.TabIndex = 19;
            this.btnConnect.Text = "连接设备";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // 初始化CAN参数
            // 
            this.初始化CAN参数.Controls.Add(this.cboMode);
            this.初始化CAN参数.Controls.Add(this.cboFilter);
            this.初始化CAN参数.Controls.Add(this.label6);
            this.初始化CAN参数.Controls.Add(this.label5);
            this.初始化CAN参数.Controls.Add(this.txtTime1);
            this.初始化CAN参数.Controls.Add(this.txtTime0);
            this.初始化CAN参数.Controls.Add(this.label4);
            this.初始化CAN参数.Controls.Add(this.label3);
            this.初始化CAN参数.Controls.Add(this.txtAccMask);
            this.初始化CAN参数.Controls.Add(this.txtAccCode);
            this.初始化CAN参数.Controls.Add(this.label2);
            this.初始化CAN参数.Controls.Add(this.label1);
            this.初始化CAN参数.Location = new System.Drawing.Point(36, 92);
            this.初始化CAN参数.Name = "初始化CAN参数";
            this.初始化CAN参数.Size = new System.Drawing.Size(700, 143);
            this.初始化CAN参数.TabIndex = 6;
            this.初始化CAN参数.TabStop = false;
            this.初始化CAN参数.Text = "初始化CAN参数";
            // 
            // cboMode
            // 
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Items.AddRange(new object[] {
            "正常",
            "只听"});
            this.cboMode.Location = new System.Drawing.Point(581, 83);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(70, 32);
            this.cboMode.TabIndex = 17;
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Items.AddRange(new object[] {
            "单滤波",
            "双滤波"});
            this.cboFilter.Location = new System.Drawing.Point(581, 39);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(70, 32);
            this.cboFilter.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(506, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "模式：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(468, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "滤波方式：";
            // 
            // txtTime1
            // 
            this.txtTime1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTime1.Location = new System.Drawing.Point(414, 84);
            this.txtTime1.MaxLength = 2;
            this.txtTime1.Name = "txtTime1";
            this.txtTime1.Size = new System.Drawing.Size(38, 31);
            this.txtTime1.TabIndex = 14;
            // 
            // txtTime0
            // 
            this.txtTime0.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTime0.Location = new System.Drawing.Point(414, 40);
            this.txtTime0.MaxLength = 2;
            this.txtTime0.Name = "txtTime0";
            this.txtTime0.Size = new System.Drawing.Size(38, 31);
            this.txtTime0.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(288, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "定时器1：0x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(288, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "定时器0：0x";
            // 
            // txtAccMask
            // 
            this.txtAccMask.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAccMask.Location = new System.Drawing.Point(150, 84);
            this.txtAccMask.MaxLength = 8;
            this.txtAccMask.Name = "txtAccMask";
            this.txtAccMask.Size = new System.Drawing.Size(110, 31);
            this.txtAccMask.TabIndex = 10;
            // 
            // txtAccCode
            // 
            this.txtAccCode.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAccCode.Location = new System.Drawing.Point(150, 40);
            this.txtAccCode.MaxLength = 8;
            this.txtAccCode.Name = "txtAccCode";
            this.txtAccCode.Size = new System.Drawing.Size(110, 31);
            this.txtAccCode.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(35, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "屏蔽码：0x";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(35, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "验收码：0x";
            // 
            // cboCanIndex
            // 
            this.cboCanIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCanIndex.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboCanIndex.FormattingEnabled = true;
            this.cboCanIndex.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cboCanIndex.Location = new System.Drawing.Point(617, 42);
            this.cboCanIndex.Name = "cboCanIndex";
            this.cboCanIndex.Size = new System.Drawing.Size(70, 32);
            this.cboCanIndex.TabIndex = 5;
            // 
            // cboDevIndex
            // 
            this.cboDevIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDevIndex.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboDevIndex.FormattingEnabled = true;
            this.cboDevIndex.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cboDevIndex.Location = new System.Drawing.Point(409, 42);
            this.cboDevIndex.Name = "cboDevIndex";
            this.cboDevIndex.Size = new System.Drawing.Size(70, 32);
            this.cboDevIndex.TabIndex = 4;
            // 
            // cboDeviceType
            // 
            this.cboDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeviceType.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboDeviceType.FormattingEnabled = true;
            this.cboDeviceType.Location = new System.Drawing.Point(106, 42);
            this.cboDeviceType.Name = "cboDeviceType";
            this.cboDeviceType.Size = new System.Drawing.Size(174, 32);
            this.cboDeviceType.TabIndex = 3;
            // 
            // lblCanIndex
            // 
            this.lblCanIndex.AutoSize = true;
            this.lblCanIndex.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCanIndex.Location = new System.Drawing.Point(506, 45);
            this.lblCanIndex.Name = "lblCanIndex";
            this.lblCanIndex.Size = new System.Drawing.Size(105, 25);
            this.lblCanIndex.TabIndex = 2;
            this.lblCanIndex.Text = "Can通道：";
            // 
            // lblDevIndex
            // 
            this.lblDevIndex.AutoSize = true;
            this.lblDevIndex.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevIndex.Location = new System.Drawing.Point(315, 45);
            this.lblDevIndex.Name = "lblDevIndex";
            this.lblDevIndex.Size = new System.Drawing.Size(88, 25);
            this.lblDevIndex.TabIndex = 1;
            this.lblDevIndex.Text = "索引号：";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice.Location = new System.Drawing.Point(31, 45);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(69, 25);
            this.lblDevice.TabIndex = 0;
            this.lblDevice.Text = "类型：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(36, 623);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1030, 222);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送数据帧";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.Controls.Add(this.btnPause);
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Controls.Add(this.txtData);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtFrameID);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Location = new System.Drawing.Point(286, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(685, 105);
            this.panel3.TabIndex = 23;
            // 
            // btnPause
            // 
            this.btnPause.AutoSize = true;
            this.btnPause.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPause.Location = new System.Drawing.Point(463, 51);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(144, 40);
            this.btnPause.TabIndex = 23;
            this.btnPause.Text = "停止";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = true;
            this.btnSend.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(463, 10);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(144, 40);
            this.btnSend.TabIndex = 22;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtData.Location = new System.Drawing.Point(133, 56);
            this.txtData.MaxLength = 23;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(253, 31);
            this.txtData.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(21, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 25);
            this.label10.TabIndex = 21;
            this.label10.Text = "数据(Hex)：";
            // 
            // txtFrameID
            // 
            this.txtFrameID.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFrameID.Location = new System.Drawing.Point(133, 15);
            this.txtFrameID.MaxLength = 23;
            this.txtFrameID.Name = "txtFrameID";
            this.txtFrameID.Size = new System.Drawing.Size(253, 31);
            this.txtFrameID.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(20, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 25);
            this.label15.TabIndex = 7;
            this.label15.Text = "帧ID(Hex)：";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.Controls.Add(this.txtSendCount);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtSendInterval);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtFrameCount);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(286, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 57);
            this.panel2.TabIndex = 22;
            // 
            // txtSendCount
            // 
            this.txtSendCount.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSendCount.Location = new System.Drawing.Point(548, 15);
            this.txtSendCount.MaxLength = 8;
            this.txtSendCount.Name = "txtSendCount";
            this.txtSendCount.Size = new System.Drawing.Size(101, 31);
            this.txtSendCount.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(435, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 25);
            this.label9.TabIndex = 21;
            this.label9.Text = "发送次数：";
            // 
            // txtSendInterval
            // 
            this.txtSendInterval.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSendInterval.Location = new System.Drawing.Point(348, 15);
            this.txtSendInterval.MaxLength = 4;
            this.txtSendInterval.Name = "txtSendInterval";
            this.txtSendInterval.Size = new System.Drawing.Size(67, 31);
            this.txtSendInterval.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(196, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "发送间隔(ms)：";
            // 
            // txtFrameCount
            // 
            this.txtFrameCount.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFrameCount.Location = new System.Drawing.Point(133, 15);
            this.txtFrameCount.MaxLength = 2;
            this.txtFrameCount.Name = "txtFrameCount";
            this.txtFrameCount.Size = new System.Drawing.Size(47, 31);
            this.txtFrameCount.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(20, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "每次帧数：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.cboSendType);
            this.panel1.Controls.Add(this.cboFrameFormat);
            this.panel1.Controls.Add(this.cboFrameType);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(17, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 168);
            this.panel1.TabIndex = 20;
            // 
            // cboSendType
            // 
            this.cboSendType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSendType.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboSendType.FormattingEnabled = true;
            this.cboSendType.Items.AddRange(new object[] {
            "正常发送",
            "单次正常发送",
            "自发自收",
            "单次自发自收"});
            this.cboSendType.Location = new System.Drawing.Point(118, 106);
            this.cboSendType.Name = "cboSendType";
            this.cboSendType.Size = new System.Drawing.Size(120, 32);
            this.cboSendType.TabIndex = 21;
            // 
            // cboFrameFormat
            // 
            this.cboFrameFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrameFormat.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboFrameFormat.FormattingEnabled = true;
            this.cboFrameFormat.Items.AddRange(new object[] {
            "数据帧",
            "远程帧"});
            this.cboFrameFormat.Location = new System.Drawing.Point(118, 62);
            this.cboFrameFormat.Name = "cboFrameFormat";
            this.cboFrameFormat.Size = new System.Drawing.Size(120, 32);
            this.cboFrameFormat.TabIndex = 20;
            // 
            // cboFrameType
            // 
            this.cboFrameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrameType.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboFrameType.FormattingEnabled = true;
            this.cboFrameType.Items.AddRange(new object[] {
            "标准帧",
            "扩展帧"});
            this.cboFrameType.Location = new System.Drawing.Point(118, 18);
            this.cboFrameType.Name = "cboFrameType";
            this.cboFrameType.Size = new System.Drawing.Size(120, 32);
            this.cboFrameType.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(5, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 25);
            this.label13.TabIndex = 19;
            this.label13.Text = "发送方式：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(24, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 25);
            this.label12.TabIndex = 7;
            this.label12.Text = "帧类型：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(24, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 25);
            this.label11.TabIndex = 18;
            this.label11.Text = "帧格式：";
            // 
            // timerDisplay
            // 
            this.timerDisplay.Tick += new System.EventHandler(this.timerDisplay_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView1.Location = new System.Drawing.Point(36, 312);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1190, 305);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridView1_CellValueNeeded);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(141, 271);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 35);
            this.btnSave.TabIndex = 22;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = true;
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(36, 270);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 36);
            this.btnClear.TabIndex = 23;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnScroll
            // 
            this.btnScroll.AutoSize = true;
            this.btnScroll.BackColor = System.Drawing.SystemColors.Control;
            this.btnScroll.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScroll.Location = new System.Drawing.Point(371, 271);
            this.btnScroll.Name = "btnScroll";
            this.btnScroll.Size = new System.Drawing.Size(109, 35);
            this.btnScroll.TabIndex = 24;
            this.btnScroll.TabStop = false;
            this.btnScroll.Text = "手动滚屏";
            this.btnScroll.UseVisualStyleBackColor = false;
            this.btnScroll.Click += new System.EventHandler(this.btnScroll_Click);
            // 
            // btnAutoScroll
            // 
            this.btnAutoScroll.AutoSize = true;
            this.btnAutoScroll.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAutoScroll.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAutoScroll.Location = new System.Drawing.Point(256, 271);
            this.btnAutoScroll.Name = "btnAutoScroll";
            this.btnAutoScroll.Size = new System.Drawing.Size(109, 35);
            this.btnAutoScroll.TabIndex = 25;
            this.btnAutoScroll.TabStop = false;
            this.btnAutoScroll.Text = "自动滚屏";
            this.btnAutoScroll.UseVisualStyleBackColor = false;
            this.btnAutoScroll.Click += new System.EventHandler(this.btnAutoScroll_Click);
            // 
            // btnWatch
            // 
            this.btnWatch.AutoSize = true;
            this.btnWatch.BackColor = System.Drawing.SystemColors.Control;
            this.btnWatch.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWatch.Location = new System.Drawing.Point(486, 271);
            this.btnWatch.Name = "btnWatch";
            this.btnWatch.Size = new System.Drawing.Size(109, 35);
            this.btnWatch.TabIndex = 26;
            this.btnWatch.TabStop = false;
            this.btnWatch.Text = "监视数据";
            this.btnWatch.UseVisualStyleBackColor = false;
            this.btnWatch.Click += new System.EventHandler(this.btnWatch_Click);
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "传输方向";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "时间标识";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "名称";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "帧id(靠右对齐)";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "帧格式";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "帧类型";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 80;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "数据长度";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 80;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column9.HeaderText = "数据(Hex)";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1293, 884);
            this.Controls.Add(this.btnWatch);
            this.Controls.Add(this.btnAutoScroll);
            this.Controls.Add(this.btnScroll);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "FormMain";
            this.Text = "Can分析仪";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.初始化CAN参数.ResumeLayout(false);
            this.初始化CAN参数.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboCanIndex;
        private System.Windows.Forms.ComboBox cboDevIndex;
        private System.Windows.Forms.ComboBox cboDeviceType;
        private System.Windows.Forms.Label lblCanIndex;
        private System.Windows.Forms.Label lblDevIndex;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.GroupBox 初始化CAN参数;
        private System.Windows.Forms.TextBox txtAccCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccMask;
        private System.Windows.Forms.TextBox txtTime1;
        private System.Windows.Forms.TextBox txtTime0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboFrameType;
        private System.Windows.Forms.ComboBox cboSendType;
        private System.Windows.Forms.ComboBox cboFrameFormat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSendCount;
        private System.Windows.Forms.TextBox txtSendInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFrameCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFrameID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStartCan;
        public System.Windows.Forms.Button btnPause;
        public System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Timer timerDisplay;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnScroll;
        private System.Windows.Forms.Button btnAutoScroll;
        private System.Windows.Forms.Button btnWatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}

