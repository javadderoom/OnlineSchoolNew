using System;
using System.Collections.Generic;
using DataAccess.Repository;
using Highsoft.Web.Mvc.Charts;
using System.Data;

namespace WebPages.Controllers
{
    public partial class ClassChartt : System.Web.UI.UserControl
    {
        public int lgid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            vReportExamsRepository rep = new vReportExamsRepository();
            vLessonGroupRepository lgr = new vLessonGroupRepository();

            List<List<decimal?>> datalist = new List<List<decimal?>>();
            List<decimal?> ll;
            List<string> studentsList = new List<string>();
            List<string> studentsNames = new List<string>();
            // string year = lgr.GetLastestYear();
            studentsList = lgr.GetStudentCodeOfLessonGroup(lgid);
            studentsNames = lgr.GetStudentNameOfLessonGroup(lgid);
            int studentCount = studentsList.Count;

            List<string> s = new List<string>() { "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "فروردین", "اردیبهشت", "خرداد" };

            //.ConvertAll(new Converter<decimal?, decimal>())

            for (int i = 0; i < studentCount; i++)
            {
                ll = new List<decimal?>();
                ll = rep.GetAvgOfStudentPerMonth(studentsList[i]);
                datalist.Add(ll);
            }
            List<decimal?> l;
            List<List<LineSeriesData>> liststudentdata = new List<List<LineSeriesData>>();
            List<LineSeriesData> studentData;

            for (int i = 0; i < datalist.Count; i++)
            {
                l = new List<decimal?>();
                l = datalist[i];
                studentData = new List<LineSeriesData>();
                l.ForEach(p => studentData.Add(new LineSeriesData { Y = (double)p }));
                liststudentdata.Add(studentData);
            }

            LineSeries ss;

            List<Series> ser = new List<Series>();

            for (int i = 0; i < datalist.Count; i++)
            {
                ss = new LineSeries();
                ss.Name = studentsNames[i];
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