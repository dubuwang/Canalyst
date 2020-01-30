using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CANalyst
{
    /// <summary>
    /// 当前连接的can设备
    /// </summary>
    public class CurrentDevice
    {
        #region 当前设备属性

        /// <summary>
        /// 当前设备类型号：初始类型为USBCAN2
        /// </summary>
        public UInt32 m_devtype = 4;

        /// <summary>
        /// 当前设备打开标志，打开为1
        /// </summary>
        public UInt32 m_bOpen = 0;

        /// <summary>
        /// 当前设备索引号，0表示只有1台设备
        /// </summary>
        public UInt32 m_devind = 0;

        /// <summary>
        /// 当前设备can通道号
        /// </summary>
        public UInt32 m_canind = 0;

        /// <summary>
        /// 存储can信息帧结构体的数组，长度50
        /// </summary>
        public VCI_CAN_OBJ[] m_recobj = new VCI_CAN_OBJ[50];

        /// <summary>
        /// 存储 设备类型常量值 的数组，数组的索引下标为类型下拉框的索引号
        /// </summary>
        public UInt32[] m_arrdevtype = new UInt32[8];

        /// <summary>
        /// 当前设备的初始化配置
        /// </summary>
        public VCI_INIT_CONFIG m_devConfig;
        #endregion

        
    }
}
