using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CANalyst
{
    /// <summary>
    /// 执行发送数据帧相关操作的类
    /// </summary>
    public class FrameTransmiter
    {
        /// <summary>
        /// FrameSender的构造方法,在构造方法中将主窗体的引用传递给FrameSender中的一个字段
        /// </summary>
        /// <param name="form1"></param>
        public FrameTransmiter(FormMain form1, DataRecorder dr,CurrentDevice dev)
        {
            this._form1 = form1;
            this._dataRecoder_FT = dr;
            this.currentDeviceInfo = dev;
        }

        /// <summary>
        /// 当前设备对象的引用
        /// </summary>
        public CurrentDevice currentDeviceInfo;

        /// <summary>
        /// 当前窗体的引用
        /// </summary>
        private FormMain _form1;

        /// <summary>
        /// dataRecoder的引用
        /// </summary>
        private DataRecorder _dataRecoder_FT;

        /// <summary>
        /// 数据传输标志,和定时器的使能状态相关联
        /// </summary>
        public bool TransmitFlag = false;

        /// <summary>
        /// 发送定时器
        /// </summary>
        public System.Timers.Timer TimerSend
        {
            set;
            get;
        }

        /// <summary>
        /// 一个线程锁对象
        /// </summary>
        private static readonly object lock_TimerSend_Elapsed = new object();

        /// <summary>
        /// 每次发送的帧数
        /// </summary>
        private int _frameCount;
        public int FrameCount
        {
            get { return _frameCount; }
            set { _frameCount = value > 0 ? value : 0; }
        }

        /// <summary>
        /// 传输数据帧的时间
        /// </summary>
        private string _transmitTime;
        public string TransmitTime
        {
            get { return _transmitTime; }
            set { _transmitTime = value; }
        }

        /// <summary>
        /// 成功传输数据帧的数量
        /// </summary>
        private int _transmitNum;
        public int TransmitNum
        {
            get { return _transmitNum; }
            set { _transmitNum = value; }
        }

        /// <summary>
        /// 发送次数,-1为无限次数
        /// </summary>
        private int _sendCount;
        public int SendCount
        {
            get { return _sendCount; }
            set { _sendCount = value >= 0 ? value : -1; }
        }

        /// <summary>
        /// 发送的can信息帧
        /// </summary>
        public VCI_CAN_OBJ TransmitCanFrame;

        /// <summary>
        /// 启动定时器， 执行发送数据函数
        /// </summary>
        public void TransmitFrame()
        {
            /// 如果发送次数或者发送帧数为0，则返回
            if (this.FrameCount == 0 || this.SendCount == 0) return;

            /// 发送次数和发送帧数符合发送条件

            //1.给定时器Elapsed事件注册委托
            this.TimerSend.Elapsed -= new System.Timers.ElapsedEventHandler(this.TimerSend_Elapsed);
            this.TimerSend.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerSend_Elapsed);

            //2.设置发送状态为true
            this.TransmitFlag = true;
            //3.设置btnSend的状态
            _form1.SetBtnSendEnableInvoke(false);
            //4.启动定时器
            this.TimerSend.Enabled = true;

        }


        /// <summary>
        /// 定时器Elapsed事件注册的委托所持有的方法
        /// 每当定时时间到，会异步执行该方法，需要加锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TimerSend_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (lock_TimerSend_Elapsed) //加锁，同一时间，只有唯一线程执行此代码，其余线程等待访问
            {
                if (!this.TimerSend.Enabled) return;

                if (CanDevice.VCI_Transmit(this.currentDeviceInfo.m_devtype, this.currentDeviceInfo.m_devind, this.currentDeviceInfo.m_canind, ref this.TransmitCanFrame, 1) == 0)
                {
                    ///如果数据帧传输失败：
                    //设置定时器的使能
                    this.TimerSend.Enabled = false;
                    //设置btnSend的状态
                    _form1.SetBtnSendEnableInvoke(true);
                    //设置发送状态为false
                    this.TransmitFlag = false;
                    MessageBox.Show("数据发送错误，实际发送帧数为0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    ///如果数据帧传输成功：
                    //1.获取传输时间
                    this.TransmitTime = DateTime.Now.ToString("hh:mm:ss:fff");
                    //2.如果为固定次数发送时，每传输成功1次，发送次数-1
                    if (this.SendCount != -1 && --this.SendCount == 0)
                    {
                        //设置定时器的使能
                        this.TimerSend.Enabled = false;
                        //设置btnSend的状态
                        _form1.SetBtnSendEnableInvoke(true);
                        //设置发送状态为false
                        this.TransmitFlag = false;
                       
                    }
                    else if (SendCount == -1)   //2.如果为无限循环发送，FrameCount == -1
                    {
                        
                    }
                   
                }
                ///执行至此时，有一帧数据传输成功了，传输数据数+1，存储这帧数据
                this.TransmitNum++;
                this._dataRecoder_FT.AddRows(this.TransmitCanFrame, this.TransmitTime,  "发送");
            }
        }

    }
}
