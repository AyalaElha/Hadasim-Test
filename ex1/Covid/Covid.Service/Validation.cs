using Covid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1 שדה חובה
//2 נכונות התאמה
//3 תקינות

namespace Covid.Service
{
    static class Validation
    {
        public static bool IsEnglishChar(char c)//TODO:לזמן
        {
            string EnglishTav = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (EnglishTav.IndexOf(c) == -1 && c != '\b' && c != ' ')
                return true;
            else
                return false;
        }
        public static bool IsNumberChar(char c)//TODO:לזמן
        {
            if ((c >= '0' && c <= '9') || c == '\b')
                return false;
            return true;
        }

        //בדיקה אם הטקסט באנגלית
        public static bool IsEnglish(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] < 'a' || s[i] > 'z') && (s[i] != ' '))
                    return false;
            }

            return true;
        }
        //בדיקת תקינות מייל
        public static bool IsMail(string s)
        {
            int t = 0, c = 0;
            for (int i = 0; i < s.Length; i++)
            {//בדיקה שאין אותיות בעברית
                if ((s[i] < 'א' || s[i] >= 'ת') && (s[i] == ' '))
                    return false;
                if (s[i] == '@')
                {
                    c++;
                    if (c > 1)
                        return false;
                }

            }
            if (!s.Contains("@"))//@ בדיקה אם יש 
                return false;
            if (s.IndexOf('@') == 0)// לא ראשון @ בדיקה  
                return false;
            for (int i = s.IndexOf('@'); i < s.Length; i++)
            {
                if (s[i] == '.')
                {
                    if (t == 0)
                    {
                        t++;
                        if (s.IndexOf("@") + 1 >= i)//בדיקה שיש אחרי שטרודל נקודה אבל לא ברצף
                            return false;
                        if (i == s.Length - 1)//בדיקה שהנקודה לא אחרונה
                            return false;
                    }
                }
            }
            if (t == 0)//בדיקה אם יש נקודה
                return false;
            return true;

        }

        //בדיקה אם הטקסט מספר  
        public static bool IsNum(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }

            return true;
        }
        //בדיקת תקינות טלפון  
        public static bool IsTel(string s)
        {

            if (s == "")
                return true;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            if (s.IndexOf('0') != 0 || s.Length != 9)
                return false;
            return true;
        }
        //בדיקת תקינות פלפון  
        public static bool IsPelepon(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            if (s.IndexOf('0') != 0 || s.Length != 10)
                return false;
            return true;
        }

        //בדיקת תקינות ת.ז
        public static bool CheckId(string d)
        {
            while (d.Length < 9)
            {
                d = "0" + d;
            }


            int s = 0, t;
            for (int i = 0; i < d.Length; i++)
            {
                if (i % 2 == 0)// הראשון זוגי להכפיל ב1  
                {
                    s += Convert.ToInt32(d[i].ToString());
                }
                if (i % 2 != 0)
                {
                    t = Convert.ToInt32(d[i].ToString()) * 2;
                    if (t < 10)
                        s += t;
                    else
                        s += t % 10 + t / 10;

                }
            }

            if (s % 10 == 0)
                return true;
            return false;

        }
         
        public static bool CheckProducer(Producer producer)
        {
            if((producer == null) ||(producer.Name != null))   return false;
            return IsEnglish(producer.Name);
        }
        public static bool CheckCovid(CovidDetails covidDetails)
        {
            return ((covidDetails.RecoveryD == null) || (covidDetails.PositiveD < covidDetails.RecoveryD));
        }

        public static bool CheckMember(Member member)
        { 
         if(member.Fname!=null&& IsEnglish(member.Fname))
         {
                if (member.Lname != null && IsEnglish(member.Lname))
                {
                     if (member.City != null && IsEnglish(member.City))
                      {
                    //               if (member.Street != null && IsEnglish(member.Street))
                    //               {
                                      if(member.IdentityNum!=null&& CheckId(member.IdentityNum))
                                      {
                         //   if (member.MobilePhone != null && IsPelepon(member.MobilePhone))
                            {
                         //       //                           if (IsTel(member.Phone))
                                //                           {
                                //                               if (IsNum(member.NumAdress.ToString()))
                                //                               {
                                //                                   if (member.BirthDay!=null&&member.BirthDay <= DateTime.Now)
                                return true;
         //                               }
         //                           }
                                }
                            }
                     }
                }
         }
             
            return false;
        }

    }
}
