using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ModbusRTU_TP1608
{
    public partial class UCChartLine : UserControl
    {
        public UCChartLine()
        {
            InitializeComponent();

            //网格设置
            this.chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;//隐藏竖线
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(100, 200, 200, 200);//横线颜色
            //X轴设置
            this.chart1.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Far;//轴标题对齐方式
            this.chart1.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 8);//图表标题字体
            this.chart1.ChartAreas[0].AxisX.TitleForeColor = Color.Black;//轴标题颜色
            //this.chart1.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Triangle;//轴箭头

            this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd\nHH:mm:ss";//时间格式
            this.chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;//时间间隔度量单位

            //Y轴
            this.chart1.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Far;//轴标题对齐方式
            this.chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;//标题水平
            this.chart1.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 8);//标题字体
            this.chart1.ChartAreas[0].AxisY.TitleForeColor = Color.Black;//轴标题颜色

            //this.chart1.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Triangle;//轴箭头
            this.chart1.ChartAreas[0].AxisY.MajorTickMark.Size = 0.5F;//刻度线长度
        }
    }
}
