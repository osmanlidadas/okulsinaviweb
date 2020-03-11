﻿namespace ErzurumOdmMvc.CKKarneModel
{
    public class TableModel
    {
        public string No { get; set; }
        public string SoruNo { get; set; }
        public string KazanimNo { get; set; }
        public string Kazanim { get; set; }
        public string IlPuani { get; set; }
        public string IlcePuani { get; set; }
        public string OkulPuani { get; set; }
        public string SubePuani { get; set; }
        public string Aciklama { get; set; }

        public TableModel(string no,string soruNo, string kazanimNo, string kazanim, string ilPuani, string ilcePuani, string okulPuani, string subePuani, string aciklama)
        {
            No = no;
            SoruNo = soruNo;
            KazanimNo = kazanimNo;
            Kazanim = kazanim;
            IlPuani = ilPuani;
            IlcePuani = ilcePuani;
            OkulPuani = okulPuani;
            SubePuani = subePuani;
            Aciklama = aciklama;
        }

        public TableModel()
        {
        }
    }
}
