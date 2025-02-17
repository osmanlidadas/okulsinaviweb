﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_Sinavlar.aspx.cs" Inherits="Okul_SinaviYonetim__Sinavlar" %>
 
<table class="table table-striped table-responsive-sm">
    <thead><tr>
        <th>#</th>
        <th>Sınav Adı</th>
        <th>Sınıf</th>
        <th>Durumu</th>
        <th>Detaylar</th>
        <th>İşlem</th>
    </tr></thead><tbody>
    <asp:Repeater ID="rptSinavlar" runat="server" OnItemDataBound="rptSinavlar_OnItemDataBound">
        <ItemTemplate>
            <tr>
                <th scope="row"><asp:Label ID="lblSira" runat="server" Text="Label"></asp:Label></th>
                <td><a href="OturumYonetim.aspx?SinavId=<%#Eval("Id") %>"><%#Eval("SinavAdi") %></a></td>
                <td><%#Eval("Sinif") %></td>
                <td><%#Eval("Aktif").ToInt32()==1?"Aktif":"Kapalı"%></td>
                <td>     
                    <a class="btn btn-default btn-sm" href="#" title="Sınav detayları" data-toggle="modal" data-target="#detay" data-id="<%#Eval("Id") %>"><i class="fas fa-align-justify"></i></a>
                </td>
                <td>
                    <a title="Oturum Ekle" class="btn btn-default btn-sm" href="OturumKayit.aspx?SinavId=<%#Eval("Id") %>"><i class="fa fa-plus"></i></a>
                    <a class="btn btn-default btn-sm" href="SinavKayit.aspx?id=<%#Eval("Id") %>"><i class="fa fa-edit"></i></a>
                    <a class="btn btn-default btn-sm" href="#" onclick="Sil(<%#Eval("Id") %>)"><i class="fa fa-trash-alt"></i></a>
                    <asp:HyperLink ToolTip="Sınavın kopyasını oluştur" CssClass="btn btn-default btn-sm" ID="hlSinavAktar" Visible="False" NavigateUrl='<%#string.Format("SinavAktar.aspx?SinavId={0}",Eval("Id")) %>' runat="server"><i class="far fa-object-ungroup"></i></asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater></tbody>
</table>
<script>
    $(function () {
        $('[data-toggle="title"]').tooltip();
    });
</script>