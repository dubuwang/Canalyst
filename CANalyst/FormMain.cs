using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace CANalyst
{
    partial class FormMain : Form
    {

        /// <summary>
        /// Form1的构造方法
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表示当前连接的设备
        /// </summary>
        public CurrentDevice currentDevice = new CurrentDevice();

        /// <summary>
        /// 声明一个执行发送数据帧的对象
        /// </summary>
        FrameTransmiter frameTransmiter;

        /// <summary>
        /// 声明一个执行接收数据的对象
        /// </summary>
        FrameReceiver frameReceiver;

        /// <summary>
        /// 声明一个保存数据的对象
        /// </summary>
        DataRecorder dataRecoder;

        /// <summary>
        /// 声明一个自动滚屏标志，初始为true
        /// </summary>
        bool scrollAuto = true;

        /// <summary>
        /// 声明一个监视数据标志，初始为false
        /// </summary>
        bool watchFlag = false;
        /// <summary>
        /// 窗体加载事件的注册函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //实例化dataRecoder
            dataRecoder = new DataRecorder();

            //实例化frameTransmiter，将窗体引用、dataRecoder的引用、当前设备的引用传递进去
            frameTransmiter = new FrameTransmiter(this, this.dataRecoder, this.currentDevice);

            //实例化frameReceiver
            frameReceiver = new FrameReceiver(100, this, this.currentDevice, this.dataRecoder);

            cboCanIndex.SelectedIndex = 0;
            cboDevIndex.SelectedIndex = 0;

            #region 初始化设备类型下拉框中的内容
            int tempindex = 0;
            //清空设备类型下拉框的选项
            cboDeviceType.Items.Clear();
            //向类型下拉框的指定索引位置添加设备名称
            tempindex = cboDeviceType.Items.Add("PCI5121");
            //将设备名称对应的常量值赋值给 设备类型数组中的索引下标的元素
            currentDevice.m_arrdevtype[tempindex] = CanDevice.VCI_PCI5121;

            tempindex = cboDeviceType.Items.Add("PCI9810");
            currentDevice.m_arrdevtype[tempindex] = CanDevice.VCI_PCI9810;

            tempindex = cboDeviceType.Items.Add("USBCAN1");
            currentDevice.m_arrdevtype[tempindex] = CanDevice.VCI_USBCAN1;

            tempindex = cboDeviceType.Items.Add("USBCAN2");
            currentDevice.m_arrdevtype[tempindex] = CanDevice.VCI_USBCAN2;

            tempindex = cboDeviceType.Items.Add("USBCAN2A");
            currentDevice.m_arrdevtype[tempindex] = CanDevice.VCI_USBCAN2A;

            tempindex = cboDeviceType.Items.Add("PCI9820");
            currentDevice.m_arrdevtype[tempindex] = CanDevice.VCI_PCI9820;

            tempindex = cboDeviceType.Items.Add("PCI5110");
            currentDevice.m_arrdevtype[tempindex] = CanDevice.VCI_PCI5110;

            cboDeviceType.SelectedIndex = 3;
            #endregion

            txtAccCode.Text = "00000000";
            txtAccMask.Text = "FFFFFFFF";

            txtTime0.Text = "00";
            txtTime1.Text = "1C";

            cboFilter.SelectedIndex = 0;
            cboMode.SelectedIndex = 0;

            cboFrameType.SelectedIndex = 0;
            cboFrameFormat.SelectedIndex = 0;
            cboSendType.SelectedIndex = 0;

        }

        /// <summary>
        /// 连接设备按钮点击事件的注册函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (currentDevice.m_bOpen == 1)
            {
                ///如果设备打开标志为1，即设备打开则执行关闭设备
                //1.先判断是否处于数据发送中
                if (frameTransmiter.TransmitFlag)
                {
                    //有数据在发送，弹窗提示，返回
                    MessageBox.Show("请先停止数据发送", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //2.没有数据在发送，则执行关闭设备
                if (CanDevice.VCI_CloseDevice(currentDevice.m_devtype, currentDevice.m_devind) == 1)
                {

                    //设备关闭成功，将设备打开标志位置0
                    currentDevice.m_bOpen = 0;
                    //使能接收定时器为false
                    this.frameReceiver.TimerReceive.Enabled = false;
                    //复位can
                    CanDevice.VCI_ResetCAN(currentDevice.m_devtype, currentDevice.m_devtype, currentDevice.m_devind);
                    //传输数据次数清空
                    frameTransmiter.TransmitNum = 0;
                    //发送次数清空
                    frameTransmiter.SendCount = 0;
                    //接收数据数清空
                    dataRecoder.DataNum = 0;
                    //设置按钮状态
                    btnStartCan.Enabled = true;
                    btnReset.Enabled = false;
                    //清空dataRecorder中的数据存储区datatable和datatablewatch和listid
                    dataRecoder.dataTable.Clear();
                    dataRecoder.dataTableWatch.Clear();
                    dataRecoder.listId.Clear();
                    //使能循环显示定时器为false
                    timerDisplay.Enabled = false;
                    //清空dataGridview1
                    dataGridView1.Rows.Clear();
                }
                else
                {
                    //设备关闭失败，弹窗
                    MessageBox.Show("设备关闭失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                //如果设备打开标志为0，即设备关闭则打开设备
                //1.设置当前设备参数
                currentDevice.m_devtype = currentDevice.m_arrdevtype[cboDeviceType.SelectedIndex];
                currentDevice.m_devind = (UInt32)cboDevIndex.SelectedIndex;
                currentDevice.m_canind = (UInt32)cboCanIndex.SelectedIndex;

                //2.调用设备打开函数，打开设备
                if (CanDevice.VCI_OpenDevice(currentDevice.m_devtype, currentDevice.m_devind, 0) == 0)
                {
                    //设备打开失败，弹窗提示
                    MessageBox.Show("打开设备失败,请检查设备类型和设备索引号是否正确", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                try
                {
                    //3.实例化currentDevice中的结构体成员config
                    currentDevice.m_devConfig = new VCI_INIT_CONFIG();
                    //4.将验收码文本框中的文本以16进制数字字符串的形式转换为32位无符号整数，再赋值给初始化can配置结构体的对应成员
                    currentDevice.m_devConfig.AccCode = Convert.ToUInt32(txtAccCode.Text.Trim(), 16);
                    //5.将屏蔽码文本框中的文本。。。
                    currentDevice.m_devConfig.AccMask = Convert.ToUInt32(txtAccMask.Text.Trim(), 16);
                    //6.将定时器0的文本框中的文本以16进制数字字符串形式转换成8位无符号整数，再赋值给初始化can配置结构体的成员
                    currentDevice.m_devConfig.Timing0 = Convert.ToByte(txtTime0.Text.Trim(), 16);
                    //7.将定时器1
                    currentDevice.m_devConfig.Timing1 = Convert.ToByte(txtTime1.Text.Trim(), 16);
                }
                catch
                {
                    MessageBox.Show("can参数设置错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //8.将模式下拉框选择项的索引号强制转换为字节数据，赋值给初始化can配置结构体的成员
                currentDevice.m_devConfig.Mode = (byte)cboMode.SelectedIndex;
                //9.将滤波方式下拉框。。。
                currentDevice.m_devConfig.Filter = (byte)cboFilter.SelectedIndex;

                //12.调用初始化can配置函数,初始化当前连接的设备
                if (CanDevice.VCI_InitCAN(currentDevice.m_devtype, currentDevice.m_devind, currentDevice.m_devind, ref currentDevice.m_devConfig) == 0)
                {
                    MessageBox.Show("初始化can配置错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //13.设备打开成功，将设备打开标志位置1
                currentDevice.m_bOpen = 1;
            }

            //通过设备打开标志，设置按钮文本
            btnConnect.Text = currentDevice.m_bOpen == 1 ? "关闭设备" : "连接设备";
        }

        private void btnStartCan_Click(object sender, EventArgs e)
        {
            if (currentDevice.m_bOpen == 0) return;

            if (CanDevice.VCI_StartCAN(currentDevice.m_devtype, currentDevice.m_devind, currentDevice.m_canind) == 0)
            {
                MessageBox.Show("启动can失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                btnStartCan.Enabled = false;
                btnReset.Enabled = true;
                //使能循环显示定时器
                timerDisplay.Enabled = true;
                //使能接收定时器
                this.frameReceiver.TimerReceive.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (currentDevice.m_bOpen == 0) return;
            if (frameTransmiter.TransmitFlag)
            {
                //有数据在发送，弹窗提示，返回
                MessageBox.Show("请先停止数据发送", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //使能接收定时器为false
            this.frameReceiver.TimerReceive.Enabled = false;

            CanDevice.VCI_ResetCAN(currentDevice.m_devtype, currentDevice.m_devind, currentDevice.m_canind);
            btnStartCan.Enabled = true;
            btnReset.Enabled = false;

            //使能循环显示定时器false
            timerDisplay.Enabled = false;

        }

        /// <summary>
        /// 发送按钮点击事件注册函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void btnSend_Click(object sender, EventArgs e)
        {
            if (currentDevice.m_bOpen == 0 || btnStartCan.Enabled == true)
            {
                MessageBox.Show("请先连接设备并启动can", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            #region 初始化frameSender中的TimerSend，设置其周期
            int interval;
            try
            {
                interval = Convert.ToInt32(txtSendInterval.Text.Trim());
            }
            catch
            {
                MessageBox.Show("发送间隔输入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (interval <= 0)
            {
                MessageBox.Show("发送间隔须大于0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frameTransmiter.TimerSend = new System.Timers.Timer();
            frameTransmiter.TimerSend.Interval = interval;
            #endregion

            #region 设置frameSender的发送次数和发送帧数
            try
            {
                frameTransmiter.SendCount = Convert.ToInt32(txtSendCount.Text.Trim());
                frameTransmiter.FrameCount = Convert.ToInt32(txtFrameCount.Text.Trim());
                frameTransmiter.SendCount = Convert.ToInt32(txtSendCount.Text.Trim());
            }
            catch
            {
                MessageBox.Show("发送次数或发送帧数输入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            #endregion

            #region 填充frameSender中要发送的信息帧结构体
            //设置标准帧或扩展帧
            frameTransmiter.TransmitCanFrame.ExternFlag = (byte)cboFrameType.SelectedIndex;
            //设置数据帧或远程帧
            frameTransmiter.TransmitCanFrame.RemoteFlag = (byte)cboFrameFormat.SelectedIndex;
            //设置发送方式
            frameTransmiter.TransmitCanFrame.SendType = (byte)cboSendType.SelectedIndex;

            //设置帧id,将帧id文本框中的文本以16进制数字字符串的形式转换为uint32
            try
            {
                frameTransmiter.TransmitCanFrame.ID = Convert.ToUInt32(txtFrameID.Text.Trim(), 16);
            }
            catch
            {
                MessageBox.Show("帧id错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //获取 字符数据数组
            string[] strData = txtData.Text.Trim().Split(' ');
            //设置数据长度
            frameTransmiter.TransmitCanFrame.DataLen = (byte)strData.Length;

            fixed (VCI_CAN_OBJ* ptr = &frameTransmiter.TransmitCanFrame)
                for (int i = 0; i < 8; i++)
                {
                    try
                    {
                        if (i < frameTransmiter.TransmitCanFrame.DataLen)
                        {
                            ptr->Data[i] = Convert.ToByte(strData[i], 16);
                        }
                        else
                        {
                            ptr->Data[i] = 0;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("数据输入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            #endregion

            #region frameSender调用其传输数据函数，发送数据

            //frameSender调用其传输数据的函数
            frameTransmiter.TransmitFrame();

            #endregion





            #region fixed关键字 指针用法
            ////声明了一个指向VCI_CAN_OBJ类型的指针，&获取frameSender.SendCanFrame的地址并赋值给指针
            //fixed (VCI_CAN_OBJ* temp = &frameSender.SendCanFrame)
            //{
            //    // ->:用于指向结构体、C++中的class等含有子数据的指针 用来取子数据
            //    //    访问指针指向的类型对象里面的成员

            //    temp->Data[0] = 11;     //表示用temp指针访问其指向结构体中的数据Data[0]

            //    temp->Data[1] = 11;

            //    temp->Data[2] = 11;

            //    temp->Data[3] = 11;

            //}

            ////声明了一个指向byte类型的指针bytePtr，将Data指针存放的地址赋值给bytePtr
            //fixed (byte* bytePtr = frameSender.SendCanFrame.Data)
            //{
            //    *bytePtr = (byte)11;
            //}
            #endregion


        }

        /// <summary>
        /// 设置btnSend控件的Enabled的invoke方法
        /// </summary>
        /// <param name="b"></param>
        public void SetBtnSendEnableInvoke(bool b)
        {
            //声明一个Action委托，指向一个匿名方法，该匿名方法操作btnSend的属性
            //Action只能持有无返回值的方法
            Action a = delegate()
            {
                btnSend.Enabled = b;
                btnPause.Enabled = !b;
            };

            this.Invoke(a);
        }

        /// <summary>
        /// 停止发送按钮点击事件的注册函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (frameTransmiter.TransmitFlag == true)
            {
                //设置定时器的状态
                frameTransmiter.TimerSend.Enabled = false;
                //设置定时器的发送状态
                frameTransmiter.TransmitFlag = false;
                //设置按钮状态
                btnSend.Enabled = true;
                btnPause.Enabled = false;
            }
        }


        /// <summary>
        /// 窗体关闭前事件的注册函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frameTransmiter.TransmitFlag)
            {
                MessageBox.Show("关闭前请先停止发送数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            else
            {
                this.frameReceiver.TimerReceive.Enabled = false;

                CanDevice.VCI_ResetCAN(currentDevice.m_devtype, currentDevice.m_devind, currentDevice.m_canind);
                CanDevice.VCI_CloseDevice(currentDevice.m_devtype, currentDevice.m_devind);

                this.Dispose();
                Application.Exit();
            }
        }

        /// <summary>
        /// 显示数据定时器，每隔200ms发生，执行绑定行数相等，自动滚屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerDisplay_Tick(object sender, EventArgs e)
        {
            //如果datatable中有行数据，且数据有更新
            if (this.dataRecoder.dataTable.Rows.Count > 0 && this.dataRecoder.DataUpdateFalg == true)
            {
                if (this.watchFlag == false) //未开启监视数据，滚动数据显示
                {
                    //绑定行数相等
                    dataGridView1.RowCount = dataRecoder.dataTable.Rows.Count;
                    if (scrollAuto) //是否自动滚屏
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Index;
                    }
                }
                else //开启了监视数据，监视数据显示
                {

                    dataGridView1.RowCount = dataRecoder.dataTableWatch.Rows.Count;
                    dataGridView1.Refresh();
                }

                this.dataRecoder.DataUpdateFalg = false;
            }
        }

        /// <summary>
        /// 该事件在控件dataGirdView刷新，需要为单元格填充数据时发生，其参数e返回当前单元格的行和列，根据行和列，获取需要的值，赋给e的Value属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

            try
            {
                if (this.watchFlag) //开启监视数据，则绑定监视数据表
                {
                    //判断列索引
                    switch (e.ColumnIndex)
                    {
                        case 0: //序号列
                            e.Value = dataRecoder.dataTableWatch.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 1: //传输方向列
                            e.Value = dataRecoder.dataTableWatch.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 2: //时间列
                            e.Value = dataRecoder.dataTableWatch.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 3: //名称列
                            e.Value = dataRecoder.dataTableWatch.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 4: //帧id列
                            e.Value = dataRecoder.dataTableWatch.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 5: //帧格式列
                            e.Value = dataRecoder.dataTableWatch.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 6: //帧类型列
                            e.Value = dataRecoder.dataTableWatch.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 7: //数据长度列
                            e.Value = dataRecoder.dataTableWatch.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 8: //数据列
                            e.Value = dataRecoder.dataTableWatch.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        default:
                            break;
                    }
                }
                else //未开启监视数据，则绑定记录数据表
                {

                    switch (e.ColumnIndex)
                    {
                        case 0: //序号列
                            e.Value = dataRecoder.dataTable.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 1: //传输方向列
                            e.Value = dataRecoder.dataTable.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 2: //时间列
                            e.Value = dataRecoder.dataTable.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 3: //名称列
                            e.Value = dataRecoder.dataTable.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 4: //帧id列
                            e.Value = dataRecoder.dataTable.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 5: //帧格式列
                            e.Value = dataRecoder.dataTable.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 6: //帧类型列
                            e.Value = dataRecoder.dataTable.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 7: //数据长度列
                            e.Value = dataRecoder.dataTable.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        case 8: //数据列
                            e.Value = dataRecoder.dataTable.Rows[e.RowIndex][e.ColumnIndex].ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
                //当清空datatable中的数据时，会抛异常

            }
        }

        /// <summary>
        /// 清空按钮，点击后清空datatable和datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dataRecoder.dataTable.Rows.Count > 0)
            {
                //传输数据次数清空
                frameTransmiter.TransmitNum = 0;
                //发送次数清空
                frameTransmiter.SendCount = 0;
                //接收数据数清空
                dataRecoder.DataNum = 0;

                //清空dataRecorder中的数据存储区datatable和datatableWatch和listid
                dataRecoder.dataTable.Clear();
                dataRecoder.dataTableWatch.Clear();
                dataRecoder.listId.Clear();
                //清空dataGridview1
                dataGridView1.Rows.Clear();
            }
        }

        /// <summary>
        /// 保存按钮点击事件，点击后将数据存至csv文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                //打开一个保存文件框，获取选择要保存的地址和文件名称
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //点击保存按钮后获取输入文件名的绝对地址
                    string path = sfd.FileName;

                    //调用生成csv文件方法
                    this.dataRecoder.DataToCsv(dataRecoder.dataTable, path);

                }
            }
        }

        /// <summary>
        /// 手动滚屏按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScroll_Click(object sender, EventArgs e)
        {
            scrollAuto = false;
            this.btnScroll.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAutoScroll.BackColor = System.Drawing.SystemColors.Control;
        }

        /// <summary>
        /// 自动滚屏按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoScroll_Click(object sender, EventArgs e)
        {
            scrollAuto = true;
            this.btnScroll.BackColor = System.Drawing.SystemColors.Control;
            this.btnAutoScroll.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        /// <summary>
        /// 监视数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWatch_Click(object sender, EventArgs e)
        {
            if (watchFlag)
            {
                this.watchFlag = false;
                this.btnWatch.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                this.watchFlag = true;
                this.btnWatch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            }
        }


    }
}
