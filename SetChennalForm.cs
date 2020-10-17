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

    public partial class SetChennalForm : Form
    {
        public Chennal chennal;
        public SetChennalForm()
        {
            InitializeComponent();
            
        }

        private void SetChennalForm_Load(object sender, EventArgs e)
        {
            //打开改窗口时加载显示的数据
            textBox_chennalName.Text = DataCollectionForm.currRightDownChennal;//通道名称
            chennal = new ChennalManage().GetByName(textBox_chennalName.Text);
            textBox_chennalID.Text = chennal.chennalID.ToString();//通道ID
            comboBox_Waring.Text = chennal.stopWaring;//报警
            comboBox_label.Text = chennal.chennalLabel;//监测项
            comboBox_Unit.Text = chennal.chennalUnit;//单位
            comboBox_decimal_places.Text = chennal.decimalPlaces.ToString();//小数位
            comboBox_chennalType.Text = chennal.chennalType;//类型
            textBox_adjustment.Text = chennal.adjustment.ToString("f2");//调整，保留两位小数
            textBox_lowerLimit.Text = chennal.lowerLimit.ToString("f2");//下限
            textBox_upperLimit.Text = chennal.upperLimit.ToString("f2");//上限
            textBox_lLowerLimit.Text = chennal.lLowerLimit.ToString("f2");//
            textBox_uUpperLimit.Text = chennal.uUpperLimit.ToString("f2");//
            textBox_smallRange.Text = chennal.smallRange.ToString("f2");//
            textBox_largeRange.Text = chennal.largeRange.ToString("f2");//
            comboBox_sensorType.Text = chennal.sensorType;//传感器类型
            textBox_sensorName.Text = chennal.sensorName;//传感器名称
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //对通道进行配置后，跟新数据库字段和设备管理页面
            //1.检查输入的内容
            if (checkForm(textBox_chennalName.Text.Trim(), comboBox_label.Text.Trim(), comboBox_Unit.Text.Trim(), textBox_adjustment.Text.Trim(), textBox_lowerLimit.Text.Trim(), textBox_upperLimit.Text.Trim(), textBox_lLowerLimit.Text.Trim(), textBox_uUpperLimit.Text.Trim(), textBox_smallRange.Text.Trim(), textBox_largeRange.Text.Trim(), comboBox_sensorType.Text.Trim(), textBox_sensorName.Text.Trim()))
            {
                if (textBox_chennalName.Text.Trim().Equals(chennal.chennalName) && comboBox_label.Text.Trim().Equals(chennal.chennalLabel) && comboBox_Unit.Text.Trim().Equals(chennal.chennalUnit) && comboBox_Waring.Text.Trim().Equals(chennal.stopWaring) && comboBox_Unit.Text.Trim().Equals(chennal.chennalUnit) && comboBox_decimal_places.Text.Trim().Equals(chennal.decimalPlaces.ToString()) && comboBox_chennalType.Text.Trim().Equals(chennal.chennalType) && textBox_adjustment.Text.Trim().Equals(chennal.adjustment.ToString()) && textBox_lowerLimit.Text.Trim().Equals(chennal.lowerLimit.ToString()) && textBox_upperLimit.Text.Trim().Equals(chennal.upperLimit.ToString()) && textBox_lLowerLimit.Text.Trim().Equals(chennal.lLowerLimit.ToString()) && textBox_uUpperLimit.Text.Trim().Equals(chennal.uUpperLimit.ToString()) && textBox_smallRange.Text.Trim().Equals(chennal.smallRange.ToString()) && textBox_largeRange.Text.Trim().Equals(chennal.largeRange.ToString()) && comboBox_sensorType.Text.Trim().Equals(chennal.sensorType) && textBox_sensorName.Text.Trim().Equals(chennal.sensorName))
                {
                    //没做任何更改，直接关闭即可
                    this.Close();
                }
                else
                {
                    double num;
                    string chennalName = textBox_chennalName.Text.Trim();//通道名称
                    //string sensorId = System.Guid.NewGuid().ToString("N");
                    string stopWaring = comboBox_Waring.Text.Trim();
                    string chennalLabel = comboBox_label.Text.Trim();//监测项
                    string chennalUnit = comboBox_Unit.Text.Trim();//监测单位
                    int decimalPlaces = int.Parse(comboBox_decimal_places.Text.Trim());
                    string chennalType = comboBox_chennalType.Text.Trim();
                    double.TryParse(textBox_adjustment.Text.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num);
                    double adjustment = num;
                    double.TryParse(textBox_lowerLimit.Text.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num);
                    double lowerLimit = num;
                    double.TryParse(textBox_upperLimit.Text.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num);
                    double upperLimit = num;
                    double.TryParse(textBox_lLowerLimit.Text.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num);
                    double lLowerLimit = num;
                    double.TryParse(textBox_uUpperLimit.Text.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num);
                    double uUpperLimit = num;
                    double.TryParse(textBox_smallRange.Text.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num);
                    double smallRange = num;
                    double.TryParse(textBox_largeRange.Text.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num);
                    double largeRange = num;
                    string sensorType = comboBox_sensorType.Text.Trim();//传感器类型
                    string sensorTableName = "";
                    switch (comboBox_sensorType.Text.Trim())
                    {
                        case "CO2浓度":
                            sensorTableName = "sensor_co2";
                            break;
                        case "CO浓度":
                            sensorTableName = "sensor_co";
                            break;
                        case "温度":
                            sensorTableName = "sensor_temp";
                            break;
                        case "PM10浓度":
                            sensorTableName = "sensor_pm10";
                            break;
                    }
                    string sensorId = stopWaring;
                    string sensorName = textBox_sensorName.Text.Trim();//传感器名称
                    string updateBy = "管理员";
                    DateTime updateTime = DateTime.Now;
                    //更新通道以上字段
                    new ChennalManage().UpdateByDeviceIdAndChennalId(chennal.deviceID, chennal.chennalID, chennalName, stopWaring, chennalLabel, chennalUnit, decimalPlaces, chennalType, adjustment, lowerLimit, upperLimit, lLowerLimit, uUpperLimit, smallRange, largeRange, sensorId, sensorType, sensorName, sensorTableName, updateBy, updateTime);
                    //更新设备配置树treeView1的相应节点（这方法相当于从数据库获取刷新一遍）
                    DataCollectionForm.dataCollectionForm.treeView1_InitFromDB();
                    this.Close();
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool checkForm(string chennalName, string label, string unit, string adjustment, string lowerLimit, string upperLimit, string lLowerLimit, string uUpperLimit, string smallRange, string largeRange, string sensorType, string sensorName)
        {
            double num;
            if (chennalName == "")
            {
                MessageBox.Show("请输入通道名称！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (label == "")
            {
                MessageBox.Show("请选择或输入监测项！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (unit == "")
            {
                MessageBox.Show("请选择或输入单位！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (adjustment == "" || double.TryParse(adjustment, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num) == false)//没输入或输入不是数字
            {
                MessageBox.Show("调整值输入有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (lowerLimit == "" || double.TryParse(lowerLimit, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num) == false)//没输入或输入不是数字
            {
                MessageBox.Show("下限值输入有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (upperLimit == "" || double.TryParse(upperLimit, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num) == false)//没输入或输入不是数字
            {
                MessageBox.Show("上限值输入有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (lLowerLimit == "" || double.TryParse(lLowerLimit, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num) == false)//没输入或输入不是数字
            {
                MessageBox.Show("下下限值输入有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (uUpperLimit == "" || double.TryParse(uUpperLimit, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num) == false)//没输入或输入不是数字
            {
                MessageBox.Show("上上限值输入有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (smallRange == "" || double.TryParse(smallRange, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num) == false)//没输入或输入不是数字
            {
                MessageBox.Show("小量程输入有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (largeRange == "" || double.TryParse(largeRange, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num) == false)//没输入或输入不是数字
            {
                MessageBox.Show("大量程输入有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (upperLimit == "" || double.TryParse(upperLimit, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num) == false)//没输入或输入不是数字
            {
                MessageBox.Show("上限值输入有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!chennal.chennalName.Equals(chennalName) && new ChennalManage().GetByDeviceIdAndName(chennal.deviceID, chennalName) != null)
            {
                MessageBox.Show("通道名称已被使用！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (sensorType == "")
            {
                MessageBox.Show("请选择传感器类型！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (sensorName == "")
            {
                MessageBox.Show("请输入传感器名称！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        
    }
}
