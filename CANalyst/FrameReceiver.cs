using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CANalyst
{
    public class FrameReceiver
    {
        /// <summary>
        /// 接收缓冲区的数据帧数
        /// </summary>
        private UInt32 _receiveNum;
        public UInt32 ReceiveNum
        {
            get { return _receiveNum; }
            set { _receiveNum = value; }
        }

        /// <summary>
        /// 成功接收存储的数据帧的数量
        /// </summary>
        private int _receiveCount;
        public int ReceiveCount
        {
            get { return _receiveCount; }
            set { _receiveCount = value; }
        }

        /// <summary>
        /// 当前设备对象的引用
        /// </summary>
        private CurrentDevice currentDeviceInfo;

        /// <summary>
        /// 窗体的引用
        /// </summary>
        private FormMain _form1;


        /// <summary>
        /// dataRecoder的引用
        /// </summary>
        private DataRecorder _dataRecoder_REC;

        /// <summary>
        /// 接收数据定时器
        /// </summary>
        public System.Timers.Timer TimerReceive;

        /// <summary>
        /// 接收到的一帧数据
        /// </summary>
        private VCI_CAN_OBJ _receiveFrame;
        public VCI_CAN_OBJ ReceiveFrame
        {
            get { return _receiveFrame; }
            set { _receiveFrame = value; }
        }

        /// <summary>
        /// 存储can信息帧结构体的数组长度50
        /// </summary>
        static  UInt32 con_maxlen = 50;
        
        /// <summary>
        /// VCI_CAN_OBJ信息帧结构体的占用空间大小
        /// </summary>
        static  int size = Marshal.SizeOf(typeof(VCI_CAN_OBJ));

        /// <summary>
        /// 分配一个50个信息帧结构体大小的内存空间，返回pt为指向新分配的内存的指针
        /// </summary>
        IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VCI_CAN_OBJ)) * (Int32)con_maxlen);

        /// <summary>
        /// 接收到数据帧的时间
        /// </summary>
        private string _receiveTime;
        public string ReceiveTime
        {
            get { return _receiveTime; }
            set { _receiveTime = value; }
        }

        /// <summary>
        /// 构造方法，传入定时器的时间间隔,注册elapsed方法
        /// </summary>
        /// <param name="n">接收定时器时间间隔</param>
        public FrameReceiver(int n,FormMain f1,CurrentDevice dev,DataRecorder dr)
        {
            this._form1 = f1;
            this.currentDeviceInfo = dev;
            this._dataRecoder_REC = dr;
            
            this.TimerReceive = new Timer(n);
            this.TimerReceive.Elapsed += TimerReceive_Elapsed;
        }

        /// <summary>
        /// 接收定时器的elapsed事件注册的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TimerReceive_Elapsed(object sender, ElapsedEventArgs e)
        {
            //获取指定接收缓冲区接收到但尚未被读取的帧数
            this.ReceiveNum = CanDevice.VCI_GetReceiveNum(this.currentDeviceInfo.m_devtype, this.currentDeviceInfo.m_devind, this.currentDeviceInfo.m_canind);
            if (this.ReceiveNum == 0) return;

            
            //调用函数，从设备读取数据，读取出的数据从pt内存指针开始存
            this.ReceiveNum = CanDevice.VCI_Receive(this.currentDeviceInfo.m_devtype, this.currentDeviceInfo.m_devind, this.currentDeviceInfo.m_canind, pt, con_maxlen, 100);
            this.ReceiveTime = DateTime.Now.ToString("hh:mm:ss:fff");
            //遍历存储信息帧结构体的内存
            for (int i = 0; i < this.ReceiveNum; i++)
            {
                this.ReceiveFrame = (VCI_CAN_OBJ) Marshal.PtrToStructure((IntPtr)((UInt32)pt + i * Marshal.SizeOf(typeof(VCI_CAN_OBJ))), typeof(VCI_CAN_OBJ));
                //存储这帧数据
                this._dataRecoder_REC.AddRows(this.ReceiveFrame, this.ReceiveTime,"接收");
            }

            //释放以前从进程的非托管内存中分配的内存。
            //Marshal.FreeHGlobal(pt);
        }
    }
}
