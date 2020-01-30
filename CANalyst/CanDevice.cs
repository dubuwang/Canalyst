using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CANalyst
{
    #region can设备数据结构定义

    /// <summary>
    /// 1.ZLGCAN系列接口卡信息的数据类型。
    /// 此结构体包含Can系列接口卡的设备信息
    /// </summary>
    public struct VCI_BOARD_INFO
    {
        public UInt16 hw_Version;   //硬件版本号
        public UInt16 fw_Version;   //固件版本号
        public UInt16 dr_Version;   //驱动程序版本号
        public UInt16 in_Version;   //接口库版本号
        public UInt16 irq_Num;      //板卡所使用的中断号
        public byte can_Num;        //表示有几路can通道

        //MarshalAs属性指示如何在托管代码和非托管代码之间封送数据
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] str_Serial_Num;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] str_hw_Type;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Reserved;
    }

    /// <summary>
    /// 2.定义CAN信息帧的数据类型。
    /// 此结构体VCI_Transmit 和 VCI_Receive 函数中被用来传送CAN 信息帧。
    /// </summary>
    unsafe public struct VCI_CAN_OBJ  //使用不安全代码
    {
        public uint ID;//报文id
        public uint TimeStamp;//接收到信息帧时的时间标识，从can控制器初始化开始计时
        public byte TimeFlag;//是否使用时间标识，TimeFlag 和 TimeStamp 只在此帧为接收帧时有意义。
        public byte SendType;//发送方式，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收，只在此帧为发送帧时有意义。
        public byte RemoteFlag;//，帧类型：是否是远程帧
        public byte ExternFlag;//帧格式：是否是扩展帧
        public byte DataLen;//数据长度(<=8)，

        //使用fixed关键字创建了带有固定大小缓冲区,大小为8个byte
        //若要访问数组的元素，应使用 fixed 语句建立指向第一个元素的指针，将Data实例固定到内存中的特定位置
        // Data是一个指针变量，指向该固定大小缓冲区的首地址
        public fixed byte Data[8];//报文的数据

        public fixed byte Reserved[3];//系统保留

    }

    /// <summary>
    /// 3.定义CAN控制器状态的数据类型。
    /// VCI_CAN_STATUS结构体包含Can控制器状态信息，结构体将在VCI_ReadCanStatus函数中被填充
    /// </summary>
    public struct VCI_CAN_STATUS
    {
        public byte ErrInterrupt;
        public byte regMode;
        public byte regStatus;
        public byte regALCapture;
        public byte regECCapture;
        public byte regEWLimit;
        public byte regRECounter;
        public byte regTECounter;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Reserved;
    }

    ///<summary>
    /// 4.定义错误信息的数据类型。
    /// VCI_ERR_INFO结构体用于装载VCI库运行时产生的错误信息，结构体将在VCI_ReadErrInfo函数中被填充
    ///</summary>
    public struct VCI_ERR_INFO
    {
        public UInt32 ErrCode;
        public byte Passive_ErrData1;
        public byte Passive_ErrData2;
        public byte Passive_ErrData3;
        public byte ArLost_ErrData;
    }

    /// <summary>
    /// 5.定义初始化CAN配置的数据类型
    /// 此结构体定义了初始化CAN的配置，将在VCI_InitCan函数中被填充
    /// </summary>
    public struct VCI_INIT_CONFIG
    {
        public UInt32 AccCode;  //验收码
        public UInt32 AccMask;  //屏蔽码
        public UInt32 Reserved; //保留
        public byte Filter;     //滤波方式
        public byte Timing0;    //定时器0，用来设置can波特率
        public byte Timing1;    //定时器1，用来设置can波特率    
        public byte Mode;       //模式
    }

    #endregion

    /// <summary>
    /// Can设备接口，这个类定义了与can硬件设备通讯的函数接口
    /// </summary>
    public class CanDevice
    {
       
        #region can设备对应的类型常量值
        public const int VCI_PCI5121 = 1;
        public const int VCI_PCI9810 = 2;
        public const int VCI_USBCAN1 = 3;
        public const int VCI_USBCAN2 = 4;
        public const int VCI_USBCAN2A = 4;
        public const int VCI_PCI9820 = 5;
        public const int VCI_CAN232 = 6;
        public const int VCI_PCI5110 = 7;
        public const int VCI_CANLITE = 8;
        public const int VCI_ISA9620 = 9;
        public const int VCI_ISA5420 = 10;
        public const int VCI_PC104CAN = 11;
        public const int VCI_CANETUDP = 12;
        public const int VCI_CANETE = 12;
        public const int VCI_DNP9810 = 13;
        public const int VCI_PCI9840 = 14;
        public const int VCI_PC104CAN2 = 15;
        public const int VCI_PCI9820I = 16;
        public const int VCI_CANETTCP = 17;
        public const int VCI_PEC9920 = 18;
        public const int VCI_PCI5010U = 19;
        public const int VCI_USBCAN_E_U = 20;
        public const int VCI_USBCAN_2E_U = 21;
        public const int VCI_PCI5020U = 22;
        public const int VCI_EG20T_CAN = 23;
        public const int VCI_PCIE9120I = 27;
        public const int VCI_PCIE9110I = 28;
        public const int VCI_PCIE9140I = 29;
        #endregion

        //#region 当前设备属性

        ///// <summary>
        ///// 当前设备类型号：初始类型为USBCAN2
        ///// </summary>
        //public UInt32 m_devtype = 4;

        ///// <summary>
        ///// 设备打开标志，打开为1
        ///// </summary>
        //public UInt32 m_bOpen = 0;

        ///// <summary>
        ///// 当前设备索引号，0表示只有1台设备
        ///// </summary>
        //public UInt32 m_devind = 0;

        ///// <summary>
        ///// 当前设备can通道号
        ///// </summary>
        //public UInt32 m_canind = 0;

        ///// <summary>
        ///// 存储can信息帧结构体的数组，长度50
        ///// </summary>
        //public VCI_CAN_OBJ[] m_recobj = new VCI_CAN_OBJ[50];

        ///// <summary>
        ///// 存储设备类型常量值的数组，数组的索引下标为类型下拉框的索引号
        ///// </summary>
        //public UInt32[] m_arrdevtype = new UInt32[8];

        //#endregion

        #region can设备函数定义

        /// <summary>
        /// 打开设备
        /// </summary>
        /// <param name="DeviceType">设备类型号</param>
        /// <param name="DeviceInd">设备索引号，当只有一个usbcan时为0</param>
        /// <param name="Reserved">此参数无意义</param>
        /// <returns></returns>
        [DllImport("controlcan.dll")]   //从非托管的Dll中导出函数
        public static extern UInt32 VCI_OpenDevice(UInt32 DeviceType, UInt32 DeviceInd, UInt32 Reserved);
        
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_CloseDevice(UInt32 DeviceType, UInt32 DeviceInd);
        
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_InitCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_INIT_CONFIG pInitConfig);
        
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadBoardInfo(UInt32 DeviceType, UInt32 DeviceInd, ref VCI_BOARD_INFO pInfo);
        
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadErrInfo(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_ERR_INFO pErrInfo);
        
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadCANStatus(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_STATUS pCANStatus);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_GetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);
        
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_SetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);

        /// <summary>
        /// 获取指定接收缓冲区接收到但尚未被读取的帧数
        /// </summary>
        /// <param name="DeviceType"></param>
        /// <param name="DeviceInd"></param>
        /// <param name="CANInd"></param>
        /// <returns></returns>
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_GetReceiveNum(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        
        /// <summary>
        /// 清空指定缓冲区
        /// </summary>
        /// <param name="DeviceType"></param>
        /// <param name="DeviceInd"></param>
        /// <param name="CANInd"></param>
        /// <returns></returns>
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ClearBuffer(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        
        /// <summary>
        /// 启动can
        /// </summary>
        /// <param name="DeviceType">设备类型</param>
        /// <param name="DeviceInd">设备索引</param>
        /// <param name="CANInd">can通道号</param>
        /// <returns></returns>
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_StartCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        
        /// <summary>
        /// 复位can
        /// </summary>
        /// <param name="DeviceType"></param>
        /// <param name="DeviceInd"></param>
        /// <param name="CANInd"></param>
        /// <returns></returns>
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_ResetCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);

        /// <summary>
        /// 返回实际发送的帧数
        /// </summary>
        /// <param name="DeviceType">设备类型号</param>
        /// <param name="DeviceInd">设备索引号</param>
        /// <param name="CANInd">第几路can</param>
        /// <param name="pSend">要发送的数据帧数组的首指针</param>
        /// <param name="Len">要发送的数据帧数组的长度</param>
        /// <returns>实际发送的帧数</returns>
        [DllImport("controlcan.dll")]
        public static extern UInt32 VCI_Transmit(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pSend, UInt32 Len);

        /// <summary>
        /// 此函数从指定的设备读取数据
        /// </summary>
        /// <param name="DeviceType">设备类型号</param>
        /// <param name="DeviceInd">设备索引号</param>
        /// <param name="CANInd">第几路can</param>
        /// <param name="pReceive">用来接收数据帧数组的首指针</param>
        /// <param name="Len">用来接收数据帧数组的长度</param>
        /// <param name="WaitTime">等待超时时间</param>
        /// <returns>实际读取到的帧数</returns>
        [DllImport("controlcan.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, IntPtr pReceive, UInt32 Len, Int32 WaitTime);
        //CharSet定义在结构中的字符串成员在结构被传给DLL时的排列方式。可以是Unicode、Ansi或Auto。
        //由于存在多种非托管字符串类型而仅存在一种托管字符串类型，所以必须使用字符集来指定如何将托管字符串封送到非托管代码
        //IntPr：用于表示指针或句柄的平台特定类型
        //IntPr用在：C#调用WIN32 API时，C#调用C/C++写的DLL时。用于传递参数
        
        #endregion

    }
}
