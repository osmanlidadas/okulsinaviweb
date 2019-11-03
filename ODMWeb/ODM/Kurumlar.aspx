﻿<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Kurumlar.aspx.cs" Inherits="ODM.AdminKurumlar" %>

<%@ MasterType VirtualPath="MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
            <h1>Kurumlar</h1>
            <ol class="breadcrumb">
                <li><a href="Giris.aspx"><i class="fa fa-home"></i>Giriş</a></li>
                <li class="active">Kurumlar</li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <asp:PlaceHolder ID="phUyari" runat="server"></asp:PlaceHolder>
                    <div class="box">
                        <div class="box-header">
                            <div class="col-md-3">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlIlceler" AutoPostBack="True" OnSelectedIndexChanged="ddlIlceler_OnSelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="box box-warning">
                                        <table class="table table-bordered table-hover dataTable" role="grid">
                                            <thead>
                                                <tr role="row">
                                                    <th>#</th>
                                                    <th>Kurum Adı</th>
                                                    <th>İşlem</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptKurumlar" runat="server" OnItemCommand="rptKurumlar_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr role="row" class="odd">
                                                            <td><%#Eval("KurumKodu") %></td>
                                                            <td><%#Eval("KurumAdi") %></td>
                                                            <td>
                                                                <asp:LinkButton ID="lnkDuzenle" runat="server" CommandName="Duzenle" CommandArgument='<%#Eval("Id") %>'><i class="glyphicon glyphicon-edit"></i></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkSil" runat="server" CommandName="Sil" OnClientClick="return confirm('Silmek istediğinizden emin misiniz?');" CommandArgument='<%#Eval("Id") %>'><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="box box-comments">
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                <div class="nav-tabs-custom">

                                                    <div class="tab-content">
                                                        <div class="tab-pane active" id="tab_1">
                                                            <div class="box-header">
                                                                <h3 class="box-title">
                                                                    <asp:Literal ID="ltrKayitBilgi" Text="Yeni Kurum Kayıt Formu" runat="server"></asp:Literal></h3>
                                                            </div>
                                                            <asp:HiddenField ID="hfId" Value="0" runat="server" />
                                                            <div class="form-group">
                                                                <label class="col-sm-3 control-label">
                                                                    Kurum Kodu
                                                                    <asp:RequiredFieldValidator ControlToValidate="txtKurumKodu" ValidationGroup="form" ID="RequiredFieldValidator1" ForeColor="Red" Text="*" SetFocusOnError="true" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic"></asp:RequiredFieldValidator></label>
                                                                <div class="col-sm-9">
                                                                    <asp:TextBox ID="txtKurumKodu" CssClass="form-control" runat="server" placeholder="Kurum Kodu" ValidationGroup="form"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-3 control-label">
                                                                    Kurum Adı
                                                                    <asp:RequiredFieldValidator ControlToValidate="txtKurumAdi" ValidationGroup="form" ID="RequiredFieldValidator2" ForeColor="Red" Text="*" SetFocusOnError="true" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic"></asp:RequiredFieldValidator></label>
                                                                <div class="col-sm-9">
                                                                    <asp:TextBox ID="txtKurumAdi" CssClass="form-control" runat="server" placeholder="Kurum Adı" ValidationGroup="form"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-3 control-label">
                                                                    E-mail Adresi
                                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEpostaAdresi" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red"
                                                                       SetFocusOnError="True" ValidationGroup="form">*</asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEpostaAdresi" Display="Dynamic" ErrorMessage="RegularExpressionValidator"
                                                                        ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" form="iletisimMesaj">*</asp:RegularExpressionValidator></label>
                                                                <div class="col-sm-9">
                                                                    <asp:TextBox ID="txtEpostaAdresi" CssClass="form-control" runat="server" placeholder="E-posta Adresi" ValidationGroup="form"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-3 control-label">
                                                                    İlçe
                                                                    <asp:RequiredFieldValidator ControlToValidate="ddlIlce" ValidationGroup="form" ID="RequiredFieldValidator3" ForeColor="Red" Text="*" SetFocusOnError="true" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic"></asp:RequiredFieldValidator></label>
                                                                <div class="col-sm-9">
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlIlce" ValidationGroup="form"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-3 control-label">
                                                                    Kurum Türü
                                                                    <asp:RequiredFieldValidator ControlToValidate="ddlKurumTuru" ValidationGroup="form" ID="RequiredFieldValidator4" ForeColor="Red" Text="*" SetFocusOnError="true" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic"></asp:RequiredFieldValidator></label>
                                                                <div class="col-sm-9">
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlKurumTuru" ValidationGroup="form">
                                                                        <asp:ListItem Value="">Kurum türünü seçiniz</asp:ListItem>
                                                                        <asp:ListItem Value="Lise">Anadolu İmam Hatip Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="Lise">Anadolu Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="MeslekiLise">Anadolu Otelcilik ve Turizm Mes. Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="MeslekiLise">Anadolu Sağlık Meslek Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="MeslekiLise">Anadolu Ticaret Meslek Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="Anaokulu">Anaokulu</asp:ListItem>
                                                                        <asp:ListItem Value="MeslekiLise">Çok Programlı Anadolu Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="MeslekiLise">Endüstri Meslek Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="Lise">Fen Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="Lise">Güzel Sanatlar Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="HEM">Halk Eğitim Merkezi</asp:ListItem>
                                                                        <asp:ListItem Value="MEM">İl - İlçe Milli Eğitim Müdürlüğü</asp:ListItem>
                                                                        <asp:ListItem Value="İlkokul">İlkokul</asp:ListItem>
                                                                        <asp:ListItem Value="İlkokul">İlkokul (Görme - İşitme Engelliler)</asp:ListItem>
                                                                        <asp:ListItem Value="Lise">İmam Hatip Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="Ortaokul">İmam Hatip Ortaokulu</asp:ListItem>
                                                                        <asp:ListItem Value="MeslekiLise">Kız Meslek Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="Lise">Meslek Lisesi(İşitme Engelliler)</asp:ListItem>
                                                                        <asp:ListItem Value="HEM">Mesleki Eğitim Merkezi</asp:ListItem>
                                                                        <asp:ListItem Value="Kurum">Mesleki ve Teknik Eğitim Merkezi (ETÖGM)</asp:ListItem>
                                                                        <asp:ListItem Value="Ortaokul">Ortaokul</asp:ListItem>
                                                                        <asp:ListItem Value="Ortaokul">Ortaokul (Görme - İşitme Engelliler)</asp:ListItem>
                                                                        <asp:ListItem Value="Kurum">Özel Eğitim Uygulama Merkezi (I. II. III. Kademe)</asp:ListItem>
                                                                        <asp:ListItem Value="Kurum">Rehberlik ve Araştırma Merkezi</asp:ListItem>
                                                                        <asp:ListItem Value="MeslekiLise">Sağlık Meslek Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="Lise">Sosyal Bilimler Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="Lise">Spor Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="MeslekiLise">Ticaret Meslek Lisesi</asp:ListItem>
                                                                        <asp:ListItem Value="Kurum">Üstün veya Özel Yetenekliler</asp:ListItem>
                                                                        <asp:ListItem Value="Ortaokul">Yatılı Bölge Ortaokulu</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="box-footer">
                                                                <asp:Button ID="btnVazgec" CssClass="btn btn-default" runat="server" Text="Vazgeç" OnClick="btnVazgec_Click" />
                                                                <asp:Button ID="btnKaydet" CssClass="btn btn-primary pull-right" runat="server" ValidationGroup="form" Text="Kaydet" OnClick="btnKaydet_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

