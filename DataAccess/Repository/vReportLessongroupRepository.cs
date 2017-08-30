﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Web.Configuration;
using System.Configuration;

namespace DataAccess.Repository
{
    public class vReportLessongroupRepository
    {
        private SchoolDBEntities db = new SchoolDBEntities();
        private Connection conn;

        public vReportLessongroupRepository()
        {
            conn = new Connection();
        }

        public decimal? getAverageLessonGroup(int id)
        {
            //var query =
            //    from r in db.vReportLessongroups
            //    where r.LGID == id
            //    select r;

            //query.GroupBy(n => new { n.SessionID, n.SessionDate }).Select(p => new { p.Key.SessionID, p.Key.SessionDate, p.Average(s => s.Nomre) });
            //var query =
            //from r in db.vReportLessongroups
            //where r.LGID == id
            //group r.Nomre by new
            //{
            //    r.SessionID,
            //    r.SessionDate
            //} into gs
            //select new
            //{
            //    sessionID = gs.Key.SessionID,
            //    sessionDate = gs.Key.SessionDate,
            //    avg = gs.Average(),
            //};

            //return query.Average(p => p.avg);

            decimal? query = (
            from r in db.vReportLessongroups
            where r.LGID == id
            select r.Nomre).Average();

            return query;
        }
    }
}