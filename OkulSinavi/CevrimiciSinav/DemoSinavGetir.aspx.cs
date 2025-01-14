﻿using System;
using System.Collections.Generic;
using System.Linq;

public partial class Sinav_DemoSinavGetir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Ogrenci"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        TestOgrenci ogrenci = (TestOgrenci)Session["Ogrenci"];//oturum bilgisi
        if (ogrenci.OpaqId != "252525")
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {
            int soruNo = 0;
            int oturumId = 0;
            if (Request.QueryString["t"] != "")
                if (Request.QueryString["t"].IsInteger())
                    oturumId = Request.QueryString["t"].ToInt32();

            if (Request.QueryString["s"] != "")
                if (Request.QueryString["s"].IsInteger())
                    soruNo = Request.QueryString["s"].ToInt32();

            if (oturumId != 0 && soruNo != 0)
            {
                Session["SoruNo"] = soruNo; //önceki sonraki butonlar için.

                var test = CacheHelper.SorulariGetir(oturumId).FirstOrDefault(x => x.SoruNo == soruNo);

                int soruSayisi = TestSoruSayisi(oturumId, test.BransId);

                if (soruNo != soruSayisi) //sonraki butonunun gizlenme işlemi
                {
                    phSonraki.Visible = true;
                }

                if (soruNo <= soruSayisi)
                {
                    // var sonuc = testCevapDb.KayitBilgiGetir(oturumId, ogrenci.OpaqId);
                    Session["DogruCevap"] = test.Cevap;

                    ddlBranslar.DataSource = CacheHelper.SinavdakiBranslar(oturumId);
                    ddlBranslar.DataValueField = "Id";
                    ddlBranslar.DataTextField = "BransAdi";
                    ddlBranslar.DataBind();
                    ddlBranslar.SelectedValue = test.BransId.ToString();

                    var tx = CacheHelper.SorulariGetir(oturumId);

                    List<SoruSayisi> soruList = new List<SoruSayisi>();
                    int i = 1;
                    foreach (var t in tx)
                    {
                        if (t.BransId == test.BransId)
                        {
                            // bool bosmu = sonuc.Cevap.Substring(t.SoruNo - 1, 1) == " ";
                            bool buSoru = t.SoruNo == soruNo;
                            soruList.Add(new SoruSayisi(i, t.SoruNo, false, buSoru));
                            i++;
                        }
                    }

                    rptSoruSayisi.DataSource = soruList;
                    rptSoruSayisi.DataBind();

                    string soruNoStr = "Soru:" + test.SoruNo + "/" + soruSayisi;
                    ltrSoruNo2.Text = ltrSoruNo.Text = soruNoStr;

                    if (test.Soru.Contains("<"))
                    {
                        ltrSoru.Text = test.Soru;
                        imgSoru.Visible = false;
                    }
                    else
                    {
                        imgSoru.ImageUrl = test.Soru;
                        imgSoru.Attributes.Add("style", "cursor: zoom-in;");

                        ltrSoru.Visible = false;
                    }
                }
                else
                {
                    if (soruNo > soruSayisi)//son soruyu geçmiş ise.
                        Response.Redirect("SinavBitir.aspx?t=" + oturumId);
                    else
                        Response.Redirect("Error.aspx");
                }
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        }
    }

    private int TestSoruSayisi(int oturumId, int bransId)
    {
        int soruSayisi;
        if (Session["SoruSayisi"] == null)
        {
            TestSorularDb sorularDb = new TestSorularDb();
            Session["SoruSayisi"] = soruSayisi = sorularDb.SoruSayisi(oturumId, bransId);
        }
        else
        {
            soruSayisi = Session["SoruSayisi"].ToInt32();
        }

        return soruSayisi;
    }
}