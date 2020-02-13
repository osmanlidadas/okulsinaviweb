﻿using System;
using System.Globalization;

namespace ErzurumOdmMvc.Common.Library
{
    public static class StringIslemleri
    {
        public static string ToTemizMetin(this string s)
        {
            s = ToTemizMetin(s, false);
            return s;
        }
        public const string SatirSonu = "<br />";

        public static string ToTemizMetin(this string s, bool satirSonu)
        {
            if (string.IsNullOrEmpty(s))
                return "";
            s = s.Replace("<", "&lt;");
            s = s.Replace(">", "&gt;");
            s = s.Replace("script", "scr_ipt");
            s = s.Replace("'", "");
            s = s.Replace("\"", "'");
            s = s.Replace("&", "-");

            if (satirSonu)
                s = s.Replace(Environment.NewLine, SatirSonu);
            s = s.Trim();
            return s;
        }
        public static string IlkHarfleriBuyut(this string metin)
        {
            try
            {
                metin = metin.ToLower();
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                return textInfo.ToTitleCase(metin);
            }
            catch (Exception)
            {
                return metin;
            }
        }
        public static string SoldanMetinAl(this string metin, int uzunluk)
        {
            try
            {
                return metin.Length < uzunluk ? metin : metin.Substring(0, uzunluk);
            }
            catch (Exception)
            {
                return metin;
            }
        }

        /// <summary>
        /// Aralarında virgül bulunan dizide key değerini alıp value değişkenini bulan meetod 
        /// </summary>
        /// <param name="ayarlarStr">cinsiyet=kiz,yas=18 gibi olmalı</param>
        /// <returns>Boş ise - döndür</returns>
        public static string ValueDegerGetir(string ayarlarStr, string key)
        {
            string[] ayariBol = ayarlarStr.Split(',');

            string value = "-";
            foreach (var s in ayariBol)
            {
                var ayar = s.Split('=');
                string k = ayar[0];
                string v = ayar[1];
                if (k == key)
                {
                    return v;
                }

            }
          

            return value;
        }
    }
}