﻿using System;

public partial class OkulSinavi_CevrimiciSinavYonetim_DemoGiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (YetkiKontrol())
            {
                Response.Redirect("Default.aspx");
            }

            OturumIslemleri oturum = new OturumIslemleri();
            KullanicilarInfo kInfo = oturum.OturumKontrol();
            TestOgrenci ogrenci = new TestOgrenci
            {
                OpaqId = "252525",
                KurumKodu = kInfo.KurumKodu.ToInt32(),
                Adi = "Demo",
                Soyadi = "Kullanıcı",
                Sinifi = 0,
                IlceAdi = "Erzurum"
            };
            Session["Ogrenci"] = ogrenci;
            Response.Redirect("/CevrimiciSinav/Sinavlar.aspx");
        }
    }
    private static bool YetkiKontrol()
    {
        OturumIslemleri oturum = new OturumIslemleri();
        KullanicilarInfo kInfo = oturum.OturumKontrol();
        bool yetkili = !kInfo.Yetki.Contains("Root") && !kInfo.Yetki.Contains("Admin")&& !kInfo.Yetki.Contains("Ogretmen");
        return yetkili;
    }
}