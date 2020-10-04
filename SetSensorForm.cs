using ModbusRTU_TP1608.Entiry;
using ModbusRTU_TP1608.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusRTU_TP1608
{
    public partial class SetSensorForm : Form
    {
        public RTUChennal chennal;
        public SetSensorForm()
        {
            InitializeComponent();
            
        }

        private void SetSensorForm_Load(object sender, EventArgs e)
        {
            chennal = new RTUChennalManage().GetByName(F_Main.currRightDownChennal);
            textBox_sensorUnit.Text = chennal.chennalUnit;
            if (chennal.sensorTableName != null && chennal.sensorID != null)
            {
                Sensor sensor = new SensorManage().GetByTableNameAndId(chennal.sensorTableName, chennal.sensorID);
                textBox_sensorName.Text = sensor.sensorName;
                comboBox_sensorType.SelectedIndex = int.Parse(sensor.sensorType);
                textBox_sensorLabel.Text = sensor.sensorLabel;

            }
        }

        private void button_addSensorType_Click(object sender, EventArgs e)
        {

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (checkForm(textBox_sensorName.Text.Trim(), comboBox_sensorType.Text.Trim(), textBox_sensorLabel.Text.Trim()))//都填了
            {
                
                //获取数据库表名称
                string tableName = TableNameUtil.GetTableNameByType(comboBox_sensorType.SelectedIndex);
                Sensor sensor = new Sensor();
                sensor.sensorName = textBox_sensorName.Text.Trim();//传感器名称
                sensor.sensorType = comboBox_sensorType.SelectedIndex.ToString();//类型
                sensor.sensorLabel = textBox_sensorLabel.Text.Trim();//监测项
                sensor.sensorValue = "0.00";//监测值先设为0.00
                sensor.sensorUnit = textBox_sensorUnit.Text.Trim();//监测单位
                sensor.sensorExternal = 0;//外部构件标志
                sensor.sensorPx = null;//px
                sensor.sensorPy = null;//py
                sensor.sensorPz = null;//pz
                sensor.createBy = "苏金领";
                sensor.createTime = DateTime.Now;

                //如果通道有传感器id，那么之前配置过传感器，此时有两个操作
                //1.类型没改--》更新
                //2.改了类型--》换表插入，删除原表的记录
                if (chennal.sensorTableName != null && chennal.sensorID != null)
                {
                    Sensor sensor1 = new SensorManage().GetByTableNameAndId(chennal.sensorTableName, chennal.sensorID);
                    if (textBox_sensorName.Text.Trim().Equals(sensor1.sensorName) && comboBox_sensorType.SelectedIndex == int.Parse(sensor1.sensorType) && textBox_sensorLabel.Text.Trim().Equals(sensor1.sensorLabel))
                    {
                        //未做任何更改，直接关闭即可
                        this.Close();
                    }
                    else
                    {
                        //1.类型没改(表名称不变)--》原表更新
                        if (chennal.sensorTableName.Equals(tableName))
                        {
                            sensor.updateBy = "通道重新配置传感器（非类型）";
                            sensor.updateTime = DateTime.Now;
                            new SensorManage().UpdateByTableNameAndId(chennal.sensorTableName, chennal.sensorID, sensor);
                            this.Close();
                        }
                        //2.改了类型--》换表插入，删除原表的记录
                        else
                        {
                            //删除原表的记录
                            new SensorManage().DeleteByTableNameAndId(chennal.sensorTableName, chennal.sensorID);
                            //插入新表
                            //设置id（读数据库，看现在有几个）
                            List<Sensor> sensors = new SensorManage().GetListFromTable(tableName);
                            //sensor.id = "" + (sensors.Count + 1);//id
                            sensor.sensorId = "" + (sensors.Count + 1);//id
                            sensor.updateBy = "通道更换传感器类型";
                            sensor.updateTime = DateTime.Now;
                            sensor = new SensorManage().InsertByTableName(tableName, sensor);
                            //更新通道的传感器id和传感器数据库表名称
                            string updateBy = "通道更换传感器类型";
                            DateTime updateTime = DateTime.Now;
                            new RTUChennalManage().UpdateSensorIdAndTableNameByDeviceIdAndChennalId(chennal.deviceID, chennal.chennalID, sensor.sensorId, tableName, updateBy, updateTime);
                            this.Close();
                        }
                    }
                }
                else
                {
                    //如果通道没有传感器id，那么之前没配置过传感器，直接插入数据库
                    //设置id（读数据库，看现在有几个）
                    List<Sensor> sensors = new SensorManage().GetListFromTable(tableName);
                    //sensor.id = "" + (sensors.Count + 1);//id
                    sensor.sensorId = "" + (sensors.Count + 1);//id
                    sensor.updateBy = "通道刚配置传感器";
                    sensor.updateTime = DateTime.Now;
                    sensor = new SensorManage().InsertByTableName(tableName, sensor);
                    //更新通道的传感器id和传感器数据库表名称
                    string updateBy = "通道刚配置传感器";
                    DateTime updateTime = DateTime.Now;
                    new RTUChennalManage().UpdateSensorIdAndTableNameByDeviceIdAndChennalId(chennal.deviceID, chennal.chennalID, sensor.sensorId, tableName, updateBy, updateTime);
                    this.Close();
                }
                
            }
        }

        public bool checkForm(string sensorName, string sensortype, string sensorLabel)
        {
            if (sensorName == "")
            {
                MessageBox.Show("请输入传感器名称！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (sensortype == "")
            {
                MessageBox.Show("请选择传感器类型！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (sensorLabel == "")
            {
                MessageBox.Show("请输入监测项！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
