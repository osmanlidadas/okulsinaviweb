﻿using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Services;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace OkulSinavi
{
    public partial class AdminKurumlarRoot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Master.Yetki().Contains("Root")) //root veya admin değil ise yönlendir
                    Response.Redirect("/Yonetim/Giris.aspx");

                IlcelerDb ilcelerDb = new IlcelerDb();
                ddlIlce.DataSource = ilcelerDb.KayitlariGetir();
                ddlIlce.DataValueField = "Id";
                ddlIlce.DataTextField = "IlceAdi";
                ddlIlce.DataBind();
                ddlIlce.Items.Insert(0, new ListItem("İlçe Seçiniz", ""));

                ddlIlceler.DataSource = ilcelerDb.KayitlariGetir();
                ddlIlceler.DataValueField = "Id";
                ddlIlceler.DataTextField = "IlceAdi";
                ddlIlceler.DataBind();
                ddlIlceler.Items.Insert(0, new ListItem("İlçe Seçiniz", ""));
            }
        }

        private void KayitlariListele()
        {
            int ilce = ddlIlceler.SelectedValue.ToInt32();
            KurumlarDb veriDb = new KurumlarDb();
            rptKurumlar.DataSource = veriDb.OkullariGetir(ilce);
            rptKurumlar.DataBind();
        }
        protected void rptKurumlar_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = e.CommandArgument.ToInt32();
            hfId.Value = id.ToString();
            KurumlarDb veriDb = new KurumlarDb();

            if (e.CommandName.Equals("Sil"))
            {
                if (id != 1262)
                {
                    veriDb.KayitSil(id);

                    KayitlariListele();
                    Master.UyariIslemTamam("Kayıt başarıyla silindi.", phUyari);
                    FormuTemizle();
                }
                else
                {
                    Master.UyariKirmizi("Bu kayıt silinemez.", phUyari);
                }
            }
            else if (e.CommandName.Equals("Duzenle"))
            {
                KurumlarInfo info = veriDb.KayitBilgiGetir(id);
                hfId.Value = info.Id.ToString();
                txtKurumAdi.Text = info.KurumAdi;
                txtKurumKodu.Text = info.KurumKodu;
                ddlIlce.SelectedValue = info.IlceId.ToString();
                ddlKurumTuru.SelectedItem.Text = info.KurumTuru;
                ddlKurumTuru.SelectedItem.Value = info.Tur;
                cbKapali.Checked = info.Kapali == 1;

                btnKaydet.Text = "Bilgileri Değiştir";
                ltrKayitBilgi.Text = string.Format("Kurum Bilgilerini Düzenleme Formu [{0}]", info.KurumAdi);
            }
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string kurumAdi = txtKurumAdi.Text;
            string kurumkodu = txtKurumKodu.Text;

            int ilce = ddlIlce.SelectedValue.ToInt32();
            string kurumTuru = ddlKurumTuru.SelectedValue;
            int id = hfId.Value.ToInt32();
            int kapali = cbKapali.Checked ? 1 : 0;

            KurumlarDb veriDb = new KurumlarDb();
            KurumlarInfo info = new KurumlarInfo
            {
                KurumAdi = kurumAdi,
                IlceId = ilce,
                KurumKodu = kurumkodu,
                KurumTuru = ddlKurumTuru.SelectedItem.Text,
                Tur = kurumTuru,
                Kapali = kapali
            };


            // Yeni bir kayıt ise.
            if (id == 0)
            {
                var kurumBilgi = veriDb.KayitBilgiGetir(kurumkodu);
                if (kurumBilgi.Id != 0)
                    Master.UyariTuruncu("Bu kurum kodu zaten mevcut. " + kurumBilgi.IlceAdi + " - " + kurumBilgi.KurumAdi + "" + (kurumBilgi.Kapali == 1 ? " (Kapalı)" : ""), phUyari);
                else
                {
                    veriDb.KayitEkle(info);
                    Master.UyariIslemTamam("Yeni bir kurum eklendi.", phUyari);
                    FormuTemizle();
                }
            }
            else
            {
                info.Id = id;
                veriDb.KayitGuncelle(info);
                Master.UyariIslemTamam("Kurum bilgileri güncellendi.", phUyari);
                FormuTemizle();
            }
            KayitlariListele();
        }
        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            FormuTemizle();
        }

        private void FormuTemizle()
        {
            ddlKurumTuru.Items.Insert(0, new ListItem("Kurum türünü seçiniz", ""));
            hfId.Value = "0";
            txtKurumKodu.Text = "";
            txtKurumAdi.Text = "";
            ddlKurumTuru.SelectedValue = "";
            ddlIlce.SelectedValue = "";
            btnKaydet.Text = "Kaydet";
            ltrKayitBilgi.Text = "Yeni Kurum Kayıt Formu";
        }

        protected void ddlIlceler_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            KayitlariListele();
        }
        [WebMethod]
        public static string OkullariListele(string ilce)
        {
            KurumlarDb veriDb = new KurumlarDb();
            List<KurumlarInfo> okullar = veriDb.OkullariDiziyeGetir(ilce.ToInt32());

            return JsonConvert.SerializeObject(okullar);
        }

        [WebMethod]
        public static string KurumTurleri()
        {
            KurumlarDb veriDb = new KurumlarDb();
            var turler = veriDb.KurumTurleri();

            return JsonConvert.SerializeObject(turler);
        }
    }
}