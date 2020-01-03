<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Student.Master" AutoEventWireup="true" CodeBehind="StudentStatsDetail.aspx.cs" Inherits="VirtualExam.Page.StudentStatsDetail" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Style/Student.css" rel="stylesheet" />

    <div class="student-stats-detail">

        
        <div class="detailTitle">
            <div class="detailNumber" >
                <p>Question Reply</p>
            </div>
            <div class="detailName" >
                  <p>Lesson Stats</p>
            </div>
            <div class="detailLink">
                  <p>Link</p>
            </div>
              
        </div>
              
        </div>

        <div class="detailContents">

           <div class="replys">
              <p class="replyTitle"><b>Cevap Anahtarı :</b></p>
                     <asp:DataList ID="dataUserReply" Width="100%" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">

                        <ItemTemplate>
                          
                  <%# Eval("trueReplyName")%>
                           
                         </ItemTemplate>
                    </asp:DataList> 
               
            
               <p class="replyTitle"><b>Kullanıcı Cevapları : </b></p>
                     <asp:DataList ID="dataTrueReply" Width="100%" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <ItemTemplate>
                            <%# Eval("trueReplyName")%>
                         </ItemTemplate>
                    </asp:DataList> 
                
           </div>
            
             <div class="subjects" >
                  <asp:DataList ID="dataSubject" Width="100%" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <ItemTemplate>
                          <div>
                                 <%# Eval("subjectName")%>  &nbsp;&nbsp;&nbsp;  <%# Eval("count")%>  
                           </div>
                                  
                                    
                         
                         </ItemTemplate>
                    </asp:DataList> 
            </div>
            <div class="result">
            <div>    <div class="with color3">&nbsp;</div> <div class="float">Toplam Soru Sayısı</div></div>
              <div>    <div class="with color2">&nbsp;</div> <div class="float">Doğru Soru Sayısı</div></div>
                <div>    <div class="with color1">&nbsp;</div> <div class="float">Yanlış Soru Sayısı</div></div>
<div class="score"> Test Puanı: <asp:Label ID="lblScore" runat="server" Text=""></asp:Label></div>
        </div>
          
  <div class="chart">
        <asp:Chart ID="Chart1" runat="server" Palette="Chocolate" Width="350px">
        <Series>
            <asp:Series Name="Konu" Color="AppWorkspace" YValuesPerPoint="2"></asp:Series>
         
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"> 
                
                
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

        <asp:Chart ID="Chart2" runat="server" Palette="Chocolate" Width="350px">
        <Series>
          
            <asp:Series Name="Doğru" Color="ForestGreen" YValuesPerPoint="2"></asp:Series>
            
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"> 
                
                
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

        <asp:Chart ID="Chart3" runat="server" Palette="Chocolate" Width="350px">
        <Series>
           
            <asp:Series Name="Yanlış" Color="Red" YValuesPerPoint="2" YValueType="Double"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"> 
                
                
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
  </div>
    </div>




</asp:Content>
