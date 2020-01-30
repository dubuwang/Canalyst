using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CANalyst
{
    /// <summary>
    /// 这是一个数据记录类，负责存储接收和发送的数据帧至datatable中
    /// </summary>
    public class DataRecorder
    {
        /// <summary>
        /// 声明一个自动实现属性：DataTable类的实例对象,用来存放接收和发送的数据信息
        /// </summary>
        public DataTable dataTable
        {
            set;
            get;
        }

        /// <summary>
        /// 存储的数据的序号
        /// </summary>
        private int _dataNum;
        public int DataNum
        {
            get { return _dataNum; }
            set { _dataNum = value; }
        }

        /// <summary>
        /// 声明一个数据更新标志
        /// </summary>
        private bool _dataUpdateFalg;
        public bool DataUpdateFalg
        {
            get { return _dataUpdateFalg; }
            set { _dataUpdateFalg = value; }
        }

        /// <summary>
        /// 声明一个存储监视数据的datatable
        /// </summary>
        public DataTable dataTableWatch
        {
            set;
            get;
        }
        /// <summary>
        /// 一个线程锁对象
        /// </summary>
        private static readonly object lock_Addrow = new object();
        
        /// <summary>
        /// 声明一个泛型list
        /// </summary>
        internal List<UInt32> listId = new List<uint>();
        
        /// <summary>
        /// 要存储的数据帧的引用
        /// </summary>
        private VCI_CAN_OBJ _recordFrame ;

        /// <summary>
        /// 构造方法，实例化dataTable，给dataTable添加列
        /// </summary>
        public DataRecorder()
        {
            this.dataTable = new DataTable();
            this.dataTableWatch = new DataTable();
            this.AddColumns();
            
        }

        /// <summary>
        /// 给DataTable添加列标题
        /// </summary>
        internal void AddColumns()
        {
            this.dataTable.Columns.Add("序号", typeof(string));
            this.dataTable.Columns.Add("传输方向", typeof(string));
            this.dataTable.Columns.Add("时间标识", typeof(string));
            this.dataTable.Columns.Add("名称", typeof(string));
            this.dataTable.Columns.Add("帧id(靠右对齐)", typeof(string));
            this.dataTable.Columns.Add("帧格式", typeof(string));
            this.dataTable.Columns.Add("帧类型", typeof(string));
            this.dataTable.Columns.Add("数据长度", typeof(string));
            this.dataTable.Columns.Add("数据(Hex)", typeof(string));

            this.dataTableWatch.Columns.Add("序号", typeof(string));
            this.dataTableWatch.Columns.Add("传输方向", typeof(string));
            this.dataTableWatch.Columns.Add("时间标识", typeof(string));
            this.dataTableWatch.Columns.Add("名称", typeof(string));
            this.dataTableWatch.Columns.Add("帧id(靠右对齐)", typeof(string));
            this.dataTableWatch.Columns.Add("帧格式", typeof(string));
            this.dataTableWatch.Columns.Add("帧类型", typeof(string));
            this.dataTableWatch.Columns.Add("数据长度", typeof(string));
            this.dataTableWatch.Columns.Add("数据(Hex)", typeof(string));
        }

        /// <summary>
        /// 将数据帧封装，添加到datatable中
        /// </summary>
        /// <param name="receiveByte"></param>
        unsafe internal void AddRows(VCI_CAN_OBJ frame, string time, string direction)
        {
            lock (lock_Addrow)
            {
                this._recordFrame = frame;
                DataRow row = this.dataTable.NewRow();

                row["序号"] = (++this.DataNum).ToString();
                row["传输方向"] = direction;
                row["时间标识"] = time;
                row["名称"] = null;
                row["帧id(靠右对齐)"] = "0x" + frame.ID.ToString("x8");
                row["帧格式"] = frame.RemoteFlag == 0 ? "数据帧" : "远程帧";
                row["帧类型"] = frame.RemoteFlag == 0 ? "标准帧" : "扩展帧";
                row["数据长度"] = frame.DataLen.ToString("D2");

                string data = null;

                fixed (VCI_CAN_OBJ* ptr = &this._recordFrame)
                    for (int i = 0; i < frame.DataLen - 1; i++)
                    {
                        data += ptr->Data[i].ToString("x2");
                        if (i < frame.DataLen - 2) data += " ";
                    }

                row["数据(Hex)"] = data;
                this.dataTable.Rows.Add(row);

                ///更新list和dataTableWatch
                if (listId.Contains(frame.ID))
                {
                    ///如果list中已经存储此frame的id，则应该在datatableframe的对应行中写入此数据
                    //将数据row中的序号修改为list的索引号,写入datatable
                    this.dataTableWatch.Rows[listId.IndexOf(frame.ID)]["序号"] = listId.IndexOf(frame.ID);
                    this.dataTableWatch.Rows[listId.IndexOf(frame.ID)]["传输方向"] = row["传输方向"];
                    this.dataTableWatch.Rows[listId.IndexOf(frame.ID)]["时间标识"] = row["时间标识"];
                    this.dataTableWatch.Rows[listId.IndexOf(frame.ID)]["名称"] = null;
                    this.dataTableWatch.Rows[listId.IndexOf(frame.ID)]["帧id(靠右对齐)"] = row["帧id(靠右对齐)"];
                    this.dataTableWatch.Rows[listId.IndexOf(frame.ID)]["帧格式"] = row["帧格式"];
                    this.dataTableWatch.Rows[listId.IndexOf(frame.ID)]["帧类型"] = row["帧类型"];
                    this.dataTableWatch.Rows[listId.IndexOf(frame.ID)]["数据长度"] = row["数据长度"];
                    this.dataTableWatch.Rows[listId.IndexOf(frame.ID)]["数据(Hex)"] = row["数据(Hex)"];
                }
                else
                {
                    ///如果list中未存储此frame的id，则进行存储，创建对应的新row

                    listId.Add(frame.ID);

                    DataRow dr = this.dataTableWatch.NewRow();
                    dr["序号"] = listId.IndexOf(frame.ID);
                    dr["传输方向"] = row["传输方向"];
                    dr["时间标识"] = row["时间标识"];
                    dr["名称"] = null;
                    dr["帧id(靠右对齐)"] = row["帧id(靠右对齐)"];
                    dr["帧格式"] = row["帧格式"];
                    dr["帧类型"] = row["帧类型"];
                    dr["数据长度"] = row["数据长度"];
                    dr["数据(Hex)"] = row["数据(Hex)"];

                    this.dataTableWatch.Rows.Add(dr);
                }

                this.DataUpdateFalg = true;
            }
            
        }

        /// <summary>
        /// Datatable生成Excel表格并返回路径
        /// </summary>
        /// <param name="m_DataTable">Datatable</param>
        /// <param name="s_FileName">文件名</param>
        /// <returns></returns>
        public string DataToExcel(System.Data.DataTable m_DataTable, string s_FileName)
        {
            //文件存放路径：绝对路径+文件名+后缀扩展名
            string FileName = s_FileName + ".xls";

            //存在则删除
            if (System.IO.File.Exists(FileName))
            {

                System.IO.File.Delete(FileName);

            }

            System.IO.FileStream objFileStream;

            System.IO.StreamWriter objStreamWriter;

            string strLine = "";
            //以指定的路径、文件操作模式、文件权限来实例化一个文件流
            objFileStream = new System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);

            //以指定的一个文件流和指定的编码来实例化一个StreaWriter流。
            //编码就是：以什么样的编码格式写入字节流-具体到streamwriter就是写入字符串时，先用
            //指定的编码将字符串编码成二进制字节，然后写入路径文件
            objStreamWriter = new System.IO.StreamWriter(objFileStream, Encoding.Unicode);

            for (int i = 0; i < m_DataTable.Columns.Count; i++)
            {
                // \t的ASCII码是 9
                strLine = strLine + m_DataTable.Columns[i].Caption.ToString() + Convert.ToChar(9);      //写列标题

            }

            objStreamWriter.WriteLine(strLine);

            strLine = "";

            for (int i = 0; i < m_DataTable.Rows.Count; i++)
            {

                for (int j = 0; j < m_DataTable.Columns.Count; j++)
                {

                    if (m_DataTable.Rows[i].ItemArray[j] == null)

                        strLine = strLine + " " + Convert.ToChar(9);                                    //写内容

                    else
                    {

                        string rowstr = "";

                        rowstr = m_DataTable.Rows[i].ItemArray[j].ToString();

                        if (rowstr.IndexOf("\r\n") > 0)

                            rowstr = rowstr.Replace("\r\n", " ");

                        if (rowstr.IndexOf("\t") > 0)

                            rowstr = rowstr.Replace("\t", " ");

                        strLine = strLine + rowstr + Convert.ToChar(9);

                    }

                }

                objStreamWriter.WriteLine(strLine);

                strLine = "";

            }

            objStreamWriter.Close();

            objFileStream.Close();

            return FileName;        //返回生成文件的绝对路径

        }

        /// <summary>
        /// DataTable生成csv文件
        /// </summary>
        /// <param name="m_DataTable"></param>
        /// <param name="s_FileName"></param>
        public void DataToCsv(System.Data.DataTable m_DataTable, string s_FileName)
        {
            //文件存放路径
            string fileName = s_FileName;

            string str = "";

            //创建一个文件流来写入数据
            StreamWriter strWriter = new StreamWriter(fileName, false, Encoding.Default);

            //将列标题写入字符串，以","分隔开，csv根据“,”分隔每列数据
            foreach (DataColumn column in this.dataTable.Columns)
            {
                str += column.ColumnName + ",";
            }
            //去掉最后一个","
            str = str.Substring(0, str.Length - 1);
            //写入列标题
            strWriter.WriteLine(str);

            //写入行数据
            for (int i = 0; i < this.dataTable.Rows.Count; i++)
            {
                str = "";
                for (int j = 0; j < this.dataTable.Columns.Count; j++)
                {
                    if (j > 0) str += ",";

                    str += this.dataTable.Rows[i][j].ToString().Replace(",", " ");

                }

                strWriter.WriteLine(str);
            }

            strWriter.Close();

        }

    }
}
