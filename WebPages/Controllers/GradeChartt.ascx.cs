using System;
using System.Collections.Generic;
using DataAccess.Repository;
using Highsoft.Web.Mvc.Charts;

namespace WebPages.Controllers
{
    public partial class GradeChartt : System.Web.UI.UserControl
    {
        public int grade { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            vReportExamsRepository rep = new vReportExamsRepository();
            vLessonGroupRepository lgr = new vLessonGroupRepository();
            ////////////// لیست لیست دیتای اولیه //////////////////
            List<List<decimal?>> datalist = new List<List<decimal?>>();
            //////////////////////// لیست دیتای اولیه////////////////////////////
            List<decimal?> ll;
            ////////////////////// لیست کلاس ها//////////////
            List<string> classes = new List<string>();
            string year = lgr.GetLastestYear();
            classes = lgr.GetClassesOfGrade(grade, year);
            ///////////////////////// تعداد کلاس ////////////
            int classCount = classes.Count;
            /////////////////ماه ها //////////////////
            List<string> s = new List<string>() { "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "فروردین", "اردیبهشت", "خرداد" };
            /////////////////////////////////////
            //.ConvertAll(new Converter<decimal?, decimal>())
            ////////////////// پر کردن لیست لیست دیتا اولیه//////////////////
            for (int i = 0; i < classCount; i++)
            {
                ll = new List<decimal?>();
                ll = rep.GetAvgOfClassPerMonth(classes[i]);
                datalist.Add(ll);
            }
            ///////////////تبدیل دیتای اولیه به دیتای چارت/////////////////
            List<decimal?> l;
            List<List<LineSeriesData>> liststudentdata = new List<List<LineSeriesData>>();
            List<LineSeriesData> studentData;

            for (int i = 0; i < datalist.Count; i++)
            {
                l = datalist[i];
                studentData = new List<LineSeriesData>();
                l.ForEach(p => studentData.Add(new LineSeriesData { Y = (double)p }));
                liststudentdata.Add(studentData);
            }
            ///////////// دادن دیتا به چارت  /////////////////////////////
            LineSeries ss;

            List<Series> ser = new List<Series>();

            for (int i = 0; i < datalist.Count; i++)
            {
                ss = new LineSeries();
                ss.Name = classes[i];
                ss.Data = liststudentdata[i];

                ser.Add(ss);
            }

            Highcharts higcharts = new Highcharts
            {
                Title = new Title
                {
                    Text = "نمودار پیشرفت",
                    X = -20
                },
                Subtitle = new Subtitle
                {
                    Text = "میانگین نمرات ماهانه کلاس",
                    X = -20
                },
                XAxis = new List<XAxis>
                {
                new XAxis
                {
                    Categories = s
                }
            },
                YAxis = new List<YAxis>
                {
                new YAxis
                {
                    Title = new YAxisTitle
                    {
                        Text = "نمره"
                    },
                    PlotLines = new List<YAxisPlotLines>                    {
                        new YAxisPlotLines
                        {
                            Value = 0,
                            Width = 1,
                            Color = "#808080"
                        }
                    }
                }
            },
                Tooltip = new Tooltip
                {
                    ValueSuffix = ""
                },
                Legend = new Legend
                {
                    Layout = LegendLayout.Vertical,
                    Align = LegendAlign.Right,
                    VerticalAlign = LegendVerticalAlign.Middle,
                    BorderWidth = 0
                },
                Series = ser
            };

            //Title t = new Title();
            //t.Text = "Monthly Average Temperature";
            //t.X = -20;
            //higcharts.Title = t;

            //Subtitle sub = new Subtitle();
            //sub.Text = "Source: WorldClimate.com";
            //sub.X = -20;

            HighsoftNamespace Highsoft = new HighsoftNamespace();

            //string result = Highsoft.Highcharts(higcharts, "chart").ToHtmlString(); //For version 5.0.6326 or older
            string result = Highsoft.GetHighcharts(higcharts, "chart").ToHtmlString(); //For version 5.0.6327 or newer

            Response.Write(result);
        }
    }
}