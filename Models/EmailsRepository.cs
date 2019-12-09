﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceM9UF3.Models
{
    public class EmailsRepository
    {
        private static Contactes2Entities dataContext = new Contactes2Entities();

        public static List<email> GetEmailByName(string name)
        {
            return dataContext.emails.Where(x => x.email1.Contains(name)).ToList();
        }
        public static email UpdateEmail(int id, email t)
        {
            try
            {
                email t0 = dataContext.emails.Where(x => x.emailId == id).SingleOrDefault();
                if (t.email1 != null)
                    t0.email1 = t.email1;
                if (t.tipus != null)
                    t0.tipus = t.tipus;

                dataContext.SaveChanges();
                return GetEmail(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static email GetEmail(int id)
        {
            email t = dataContext.emails.Where(x => x.emailId == id).SingleOrDefault();
            return t;
        }

        public static email InsertEmail(email em)
        {
            try
            {
                dataContext.emails.Add(em);
                dataContext.SaveChanges();
                return GetEmail(em.emailId);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static void DeleteEmail(int id)
        {
            email c = dataContext.emails.Where(x => x.emailId == id).SingleOrDefault();
            if (c != null)
            {
                dataContext.emails.Remove(c);
                dataContext.SaveChanges();
            }
        }
    }
}